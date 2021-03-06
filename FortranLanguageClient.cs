﻿using Microsoft.VisualStudio;
using Microsoft.VisualStudio.LanguageServer.Client;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Threading;
using Microsoft.VisualStudio.Utilities;
using StreamJsonRpc;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;


/**
 * Grammar files were taken from https://github.com/dparkins/language-fortran,
 * converted from cson to json,
 * then converted to tmLanguage using vscode TextMate Languages extension (https://marketplace.visualstudio.com/items?itemName=Togusa09.tmlanguage).
 * 
 */
namespace FortranLanguageClient
{
    [ContentType("fortran")]
    [Export(typeof(ILanguageClient))]
    [ProvideOptionPage(typeof(DialogPageProvider.General), "Fortran Language Client", "General", 0, 0, true)]
    public class FortranLanguageClient : AsyncPackage, ILanguageClient //, ILanguageClientCustomMessage
    {
        public string Name => "Fortran IntelliSense";

        public IEnumerable<string> FilesToWatch
        {

            get {
                string[] extArray = {"*.f", "*.f77", "*.f90", "*.f95", "*.f03", "*.f08", "*.for", "*.fpp"};

                foreach (string extension in extArray) {
                    yield return extension;
                }
            }
        }
            
        public IEnumerable<string> ConfigurationSections
        {
            get
            {
                yield return "fortranLanguageClient";
            }
        }

        public async Task<Connection> ActivateAsync(CancellationToken token)
        {

            var options = GeneralOptions.Instance;
            var programPath = options.FortlsPath;

            var arguments = "";
            if (options.TypeMemberSymbols == false) arguments += "--symbol_skip_mem ";
            if (options.FilterAutocomplete == false) arguments += "--autocomplete_no_prefix ";
            if (options.LowercaseIntrinsics == true) arguments += "--lowercase_intrinsics ";
            if (options.IncrementalSync == true) arguments += "--incremental_sync ";
            if (options.VariableHover == true) arguments += "--variable_hover ";
            if (options.SignatureHelp == true) arguments += "--use_signature_help ";

            ProcessStartInfo info = new ProcessStartInfo();
            info.Arguments = arguments;
            info.FileName = programPath;
            info.WorkingDirectory = Path.GetDirectoryName(programPath);
            info.RedirectStandardInput = true;
            info.RedirectStandardOutput = true;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;

            /*
            var stdInPipeName = @"output";
            var stdOutPipeName = @"input";

            var pipeAccessRule = new PipeAccessRule("Everyone", PipeAccessRights.ReadWrite, System.Security.AccessControl.AccessControlType.Allow);
            var pipeSecurity = new PipeSecurity();
            pipeSecurity.AddAccessRule(pipeAccessRule);

            var bufferSize = 256;
            var readerPipe = new NamedPipeServerStream(stdInPipeName, PipeDirection.InOut, 4, PipeTransmissionMode.Message, PipeOptions.Asynchronous, bufferSize, bufferSize, pipeSecurity);
            var writerPipe = new NamedPipeServerStream(stdOutPipeName, PipeDirection.InOut, 4, PipeTransmissionMode.Message, PipeOptions.Asynchronous, bufferSize, bufferSize, pipeSecurity);            
            */

            Process process = new Process();
            process.StartInfo = info;

            if (process.Start())
            {
                //await readerPipe.WaitForConnectionAsync(token);
                //await writerPipe.WaitForConnectionAsync(token);

                return new Connection(process.StandardOutput.BaseStream, process.StandardInput.BaseStream);
            }

            return null;
        }


        internal const string UiContextGuidString = "DE885E15-D44E-40B1-A370-45372EFC23AA";

        private Guid uiContextGuid = new Guid(UiContextGuidString);

        public event AsyncEventHandler<EventArgs> StartAsync;
        public event AsyncEventHandler<EventArgs> StopAsync;

        public FortranLanguageClient()
        {
            Instance = this;
        }

        internal static FortranLanguageClient Instance
        {
            get;
            set;
        }

        internal JsonRpc Rpc
        {
            get;
            set;
        }


        public object InitializationOptions => null;

        public object MiddleLayer => null;

        public object CustomMessageTarget => null;

 
       /* public async System.Threading.Tasks.Task AttachForCustomMessageAsync(JsonRpc rpc)
        {
            this.Rpc = rpc;

            await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();

            // Sets the UI context so the custom command will be available.
            var monitorSelection = ServiceProvider.GlobalProvider.GetService(typeof(IVsMonitorSelection)) as IVsMonitorSelection;
            if (monitorSelection != null)
            {
                if (monitorSelection.GetCmdUIContextCookie(ref this.uiContextGuid, out uint cookie) == VSConstants.S_OK)
                {
                    monitorSelection.SetCmdUIContext(cookie, 1);
                }
            }
        }*/

        public async System.Threading.Tasks.Task OnLoadedAsync()
        {
            await StartAsync?.InvokeAsync(this, EventArgs.Empty);
        }

        public System.Threading.Tasks.Task OnServerInitializedAsync()
        {
            return System.Threading.Tasks.Task.CompletedTask;
        }

        public System.Threading.Tasks.Task OnServerInitializeFailedAsync(Exception e)
        {
            return System.Threading.Tasks.Task.CompletedTask;
        }
    }
}
