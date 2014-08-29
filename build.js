var _ = require("underscore");
var fs = require("fs");
var argv = require("minimist")(process.argv.slice(2));
var spawn = require('spawn-cmd').spawn;
var vm = require("vm");
var FormData = require('form-data');
var request = require('request');

function _include(path) {
    var code = fs.readFileSync(path);
    vm.runInThisContext(code, path);
}

XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
_include("http-1.0.1.js");
_include("packages4js-client-1.0.0.js");

function exec(cmd, params, callback) {
    var _exec = spawn(cmd, params);
    _exec.stdout.on("data", function(data) {
            console.log(""+data);
    });

    _exec.stderr.on("data", function(data) {
            console.log(""+data);
    });
    _exec.on("close", function(code) {
            console.log("done = "+code);
            callback(code);
    });
}

var MSBUILD = "\\Windows\\Microsoft.NET\\Framework\\v4.0.30319\\MSBuild.exe";
var ILMerge = "ILMerge.exe"

if (!argv.version) {
    console.log("Usage: build.js --version=[version num]");
    process.exit(1);
}

var mainform = (""+fs.readFileSync("MainForm.cs")).replace(/\r/g, "").split("\n");

_.each(mainform, function(line, index) {
    if (line.match(/VERSION = /)) {
        mainform[index] = "private static string VERSION = \""+argv.version+"\";";
    }
});

fs.writeFileSync("MainForm.cs", mainform.join("\n"));

exec(MSBUILD, ["/p:configuration=Release"], function(code) {
    if (code != 0) return;

    console.log("Merging EXE and DLLs...");

    exec(ILMerge, ["/target:winexe", "/wildcards", "/out:dist\\OpenRest.exe", "bin\\Release\\OpenRest.exe", "bin\\Release\\*.dll"], function(code) {
        if (code != 0) return;

        uploadNewVersion();
    });
});

function uploadNewVersion() {
    console.log("Uploading...");
    var client = new packages.Client();
    client.request({
        request:{
            "type":"package.create",
            "projectId":"com.openrest.olo.printer4win",
            "packageId":argv.version,
            "accessToken":"xyDSgsglBftgYjtUHgB0"
        },
        callback:function(e) {
            console.log(e);
            client.request({
                request:{
                    "type":"package.uploadurl",
                    "projectId":"com.openrest.olo.printer4win",
                    "packageId":argv.version,
                    "accessToken":"xyDSgsglBftgYjtUHgB0"
                },
                callback:function(e) {
                    console.log(e);
                    if (e.error) return;

                    var form = new FormData();
                    form.append("OpenRest.ex_", fs.createReadStream("dist\\OpenRest.exe"));
                    form.submit(e.value.url, function(err, res) {
                        console.log(err || "Success.");
                        res.resume();
                    });
                }
            });
        }
    });
}
