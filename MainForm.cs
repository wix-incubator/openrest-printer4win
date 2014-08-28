using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using Microsoft.Win32;
using com.openrest.v1_1;
using com.openrest.packages;
using System.Diagnostics;
using System.Threading;

namespace OpenRest
{
    public partial class MainForm : Form
    {
        private Boolean loggedIn = false;
        private Boolean connectionStatus;
        private Boolean printing = false;
        private System.Timers.Timer refreshTimer;
        private String accessToken = null;

        private static string REGISTRY_NAME = "HKEY_CURRENT_USER\\Software\\OpenRest";
        private static string USERNAME = "username";
        private static string PASSWORD = "password";
        private static string PRINTED = "printed";

        private WebBrowser browser = new WebBrowser();
        private com.openrest.v1_1.OpenrestClient client = new com.openrest.v1_1.OpenrestClient(new System.Uri("https://api.openrest.com/v1.1"));

        private static readonly DateTime EPOCH = new DateTime(1970,1,1,0,0,0);

        private List<String> printed = new List<String>();
        private List<Order> toPrint = new List<Order>();
        private long ordersSince = 0;

        public MainForm()
        {
            InitializeComponent();

            // Setup refresh timer
            refreshTimer = new System.Timers.Timer(2000);
            refreshTimer.Elapsed += new ElapsedEventHandler(refreshTimer_Elapsed);

            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);

            String s = (String)Registry.GetValue(REGISTRY_NAME, PRINTED, "");

            if (s == null)
            {
                s = "";
            }
            printed = s.Split(new char[] { ',' }).ToList();
        }

        void refreshTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (!loggedIn) return;

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                QueryOrdersRequest request = new QueryOrdersRequest();

                request.accessToken = accessToken;
                request.distributorId = "us.openrest.com";
                if (ordersSince == 0)
                {
                    request.limit = 10;
                }
                else
                {
                    request.since = ordersSince;
                }

                request.status = "new";
                request.fields = new List<String>{"id", "status", "modified", "locale"};

                OrdersResponse response;
                try
                {
                    response = client.Request<OrdersResponse>(request);
                }
                catch (OpenrestException e2)
                {
                    ConnectionStatus.Text = "Connection: × (" + e2.ErrorMessage + ")";
                    connectionStatus = false;
                    notifyIcon.ShowBalloonTip(5000, "OpenRest", "Connection Error! "+e2.ErrorMessage, ToolTipIcon.Error);
                    return;
                }
                catch (Exception e2)
                {
                    ConnectionStatus.Text = "Connection: ×";
                    connectionStatus = false;
                    notifyIcon.ShowBalloonTip(5000, "OpenRest", "Connection Error!", ToolTipIcon.Error);
                    return;
                }
                ConnectionStatus.Text = "Connection: ✓";
                if (!connectionStatus)
                {
                    notifyIcon.ShowBalloonTip(5000, "OpenRest", "Connected.", ToolTipIcon.Info);
                }
                connectionStatus = true;

                foreach (Order order in response.results)
                {
                    long orderModified = order.modified.Value;

                    if (orderModified > ordersSince)
                    {
                        ordersSince = orderModified + 1;
                    }

                    toPrint.Add(order);
                }

                printNext();
            }));
        }

        private void printNext()
        {
            if (toPrint.Count == 0) return;
            if (printing) return;

            printing = true;

            Order order = toPrint[0];
            toPrint.RemoveAt(0);

            if (printed.Contains(order.id))
            {
                printing = false;
                printNext();
                return;
            }

            notifyIcon.ShowBalloonTip(5000, "OpenRest", "Printing: "+order.id, ToolTipIcon.Info);
            GetOrderRequest request = new GetOrderRequest();
            request.fields = new List<String> { "id", "restaurantId", "created", "submitAt", "properties", "orderItems", "received", "user", "delivery", "contact", "platform", "source", "developer", "payments", "price", "ref", "status", "modified", "locale", "html" };
            request.accessToken = accessToken;
            request.orderId = order.id;
            request.viewMode = "restaurant";
            request.anonymize = true;
            request.printCsc = false;
            request.locale = order.locale;
            request.printHeader = true;
            request.embed = true;
            request.printConfirmation = false;

            try
            {
                order = client.Request<Order>(request);
            }
            catch (OpenrestException e2)
            {
                ConnectionStatus.Text = "Connection: × (" + e2.ErrorMessage + ")";
                connectionStatus = false;

                notifyIcon.ShowBalloonTip(5000, "OpenRest", "Print Error! " + e2.ErrorMessage, ToolTipIcon.Error);

                toPrint.Add(order);
                delayPrintNext();
                return;
            }
            catch (Exception e2)
            {
                ConnectionStatus.Text = "Connection: ×";
                connectionStatus = false;

                notifyIcon.ShowBalloonTip(5000, "OpenRest", "Print Error! "+e2.Message, ToolTipIcon.Error);

                toPrint.Add(order); 
                printing = false;
                delayPrintNext();
                return;
            }

            browser.DocumentText = order.html;
            printed.Add(order.id);
            Registry.SetValue(REGISTRY_NAME, PRINTED, string.Join(",", printed.ToArray()));
        }

        void delayPrintNext()
        {
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                Thread.Sleep(5000);
                this.BeginInvoke(new MethodInvoker(delegate()
               {
                   printing = false;
                   printNext();
               }));
            };
            worker.RunWorkerAsync();
        }

        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Print();
            printing = false;
            printNext();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();

            worker.DoWork += delegate
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    String username = (String)Registry.GetValue(REGISTRY_NAME, USERNAME, "");
                    String password = (String)Registry.GetValue(REGISTRY_NAME, PASSWORD, "");

                    String[] conf = null;

                    if (System.IO.File.Exists("OpenRest.cfg"))
                    {
                        conf = System.IO.File.ReadAllLines("OpenRest.cfg");
                    }

                    if (conf != null)
                    {
                        if ((username == null) || (username == ""))
                        {
                            username = conf[0];
                        }

                        if ((password == null) || (password == ""))
                        {
                            if (conf.Length > 1)
                            {
                                password = conf[1];
                            }
                        }
                    }

                    textBox1.Text = username;
                    textBox2.Text = password;

                    if ((username != null) && (password != null) && (username != "") && (password != ""))
                    {
                        Connect_Click(null, null);
                    }
                    else
                    {
                        this.WindowState = FormWindowState.Normal;
                        Show();
                    }
                }));
            };

            worker.RunWorkerAsync();

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState) {
                Hide();
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void close_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            GetRolesRequest request = new GetRolesRequest();
            
            accessToken = "spice|" + username + "|" + password;
            request.accessToken = accessToken;
            loginError.Text = "";

            notifyIcon.ShowBalloonTip(5000, "OpenRest", "Connecting...", ToolTipIcon.Info);

            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += delegate
            {
                this.BeginInvoke(new MethodInvoker(delegate()
                {
                    try
                    {
                        RolesResponse response = client.Request<RolesResponse>(request);

                        if (response.roles.Count == 0)
                        {
                            loginError.Text = "Error logining in. Please check username and password.";
                            this.Show();
                            this.WindowState = FormWindowState.Normal;
                            return;
                        }
                    }
                    catch (OpenrestException e2)
                    {
                        loginError.Text = "Error logining in. Please check username and password.";
                        this.Show();
                        this.WindowState = FormWindowState.Normal; 
                        return;
                    }
                    catch (Exception e2)
                    {
                        loginError.Text = "Connection problem. " + e2.Message;
                        this.Show();
                        this.WindowState = FormWindowState.Normal; 
                        return;
                    }

                    Registry.SetValue(REGISTRY_NAME, USERNAME, username);
                    Registry.SetValue(REGISTRY_NAME, PASSWORD, password);

                    ordersSince = 0;
                    toPrint.RemoveRange(0, toPrint.Count);

                    loginpanel.Hide();
                    loggedinpanel.Show();
                    loggedIn = true;
                    refreshTimer.Stop();
                    refreshTimer.Start();
                    printing = false;
                    printNext();
                }));
            };
            worker.RunWorkerAsync();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Registry.SetValue(REGISTRY_NAME, USERNAME, "");
            Registry.SetValue(REGISTRY_NAME, PASSWORD, "");

            textBox2.Text = "";

            loggedIn = false;
            loggedinpanel.Hide();
            loginpanel.Show();
        }

        private void Printers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Registry.SetValue(REGISTRY_NAME, REGISTRY_PRINTER_NAME, Printers.SelectedItem); 
        }

        private void ConfigurePrinter_Click(object sender, EventArgs e)
        {
            browser.ShowPrintDialog();
        }

        private void OpenSite_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("chrome", "https://apps.openrest.com/");
            }
            catch (Exception e2)
            {
                try
                {
                    Process.Start("firefox", "https://apps.openrest.com/");
                }
                catch (Exception e3)
                {
                    try
                    {
                        Process.Start("https://apps.openrest.com/");
                    }
                    catch (Exception e4)
                    {
                    }
                }
            }
        }
    }
}
