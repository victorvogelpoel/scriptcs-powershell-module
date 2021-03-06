/*
    Copyright (c) 2013 Code Owls LLC, All Rights Reserved.

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/


using System.Linq;
using System.Management.Automation;
using CodeOwls.PowerShell.ScriptCS.Sessions;

namespace CodeOwls.PowerShell.ScriptCS.Cmdlets
{
    [Cmdlet(VerbsLifecycle.Invoke, "ScriptCS")]
    public class InvokeScriptCSCmdlet : PSCmdlet, ICmdletContext
    {
        private const string DefaultSessionName = "<default>";

        private static readonly string[] DefaultReferences = new[]
                                                                 {
                                                                     "System", "System.Core", "System.Data",
                                                                     "System.Data.DataSetExtensions", "System.Xml",
                                                                     "System.Xml.Linq"
                                                                 };

        private static readonly string[] DefaultNamespaces = new[]
                                                                 {
                                                                     "System", "System.Collections.Generic",
                                                                     "System.Linq",
                                                                     "System.Text", "System.Threading.Tasks"
                                                                 };

        public InvokeScriptCSCmdlet()
        {
            References = DefaultReferences;
            Namespaces = DefaultNamespaces;
        }

        [Parameter(ValueFromPipeline = true)]
        public object[] Input { get; set; }

        [Parameter(Mandatory = false)]
        public string[] Session { get; set; }

        [Parameter(Mandatory = true, Position = 0)]
        [Alias("CS")]
        public string Script { get; set; }

        [Parameter(Mandatory = false)]
        public string[] References { get; set; }
        
        [Parameter(Mandatory = false)]
        [Alias("Using", "Import")]
        public string[] Namespaces { get; set; }

        private IScriptCSSession _session;
        protected override void BeginProcessing()
        {
            Script = "var pscmdlet = Require<CodeOwls.PowerShell.ScriptCS.CurrentCmdletContext>(); " + Script;            
        }

        protected override void EndProcessing()
        {
        }

        protected override void ProcessRecord()
        {
            var manager = new ScriptCSSessionManager();
            if (null != Session)
            {
                var sessions = manager.GetMatchingSessions(Session);
                if (sessions.Any())
                {
                    sessions.ToList().ForEach(Execute);
                }
                else
                {
                    Session.ToList().ForEach( s=>ExecuteInSession( manager, s ));
                }
            }
            else
            {
                ExecuteInSession(manager, DefaultSessionName);
            }
        }

        private void ExecuteInSession(ScriptCSSessionManager manager, string sessionName)
        {
            var session = manager.GetOrCreate(sessionName, this);
            Execute(session);
        }

        private void Execute(IScriptCSSession session)
        {
            using (session.PushLogger(new CmdletLogger(this)))
            {
                using (session.PushCmdletContext(this))
                {
                    var result = session.Execute(Script, References, Namespaces);
                    WriteObject(result);
                }
            }
        }
    }
}
