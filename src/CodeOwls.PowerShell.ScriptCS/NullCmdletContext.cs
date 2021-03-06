using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;

namespace CodeOwls.PowerShell.ScriptCS
{
    public class NullCmdletContext : ICmdletContext
    {
        public CommandOrigin CommandOrigin { get; private set; }
        public bool Stopping { get; private set; }
        public ICommandRuntime CommandRuntime { get; set; }
        public PSTransactionContext CurrentPSTransaction { get; private set; }
        public string ParameterSetName { get; private set; }
        public InvocationInfo MyInvocation { get; private set; }
        public CommandInvocationIntrinsics InvokeCommand { get; private set; }
        public PSHost Host { get; private set; }
        public SessionState SessionState { get; private set; }
        public PSEventManager Events { get; private set; }
        public JobRepository JobRepository { get; private set; }
        public ProviderIntrinsics InvokeProvider { get; private set; }
        public object[] Input { get; private set; }

        public string GetResourceString(string baseName, string resourceId)
        {
            return null;
        }

        public void WriteError(ErrorRecord errorRecord)
        {
        }

        public void WriteObject(object sendToPipeline)
        {
        }

        public void WriteObject(object sendToPipeline, bool enumerateCollection)
        {
        }

        public void WriteVerbose(string text)
        {
        }

        public void WriteWarning(string text)
        {
        }

        public void WriteCommandDetail(string text)
        {
        }

        public void WriteProgress(ProgressRecord progressRecord)
        {
        }

        public void WriteDebug(string text)
        {
        }

        public bool ShouldProcess(string target)
        {
            return false;
        }

        public bool ShouldProcess(string target, string action)
        {
            return false;
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption)
        {
            return false;
        }

        public bool ShouldProcess(string verboseDescription, string verboseWarning, string caption,
                                  out ShouldProcessReason shouldProcessReason)
        {
            shouldProcessReason = ShouldProcessReason.None;
            return false;
        }

        public bool ShouldContinue(string query, string caption)
        {
            return false;
        }

        public bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll)
        {
            return false;
        }

        public bool TransactionAvailable()
        {
            return false;
        }

        public void ThrowTerminatingError(ErrorRecord errorRecord)
        {
        }

        public PathInfo CurrentProviderLocation(string providerId)
        {
            return null;
        }

        public string GetUnresolvedProviderPathFromPSPath(string path)
        {
            return null;
        }

        public Collection<string> GetResolvedProviderPathFromPSPath(string path, out ProviderInfo provider)
        {
            provider = null;
            return null;
        }

        public object GetVariableValue(string name)
        {
            return null;
        }

        public object GetVariableValue(string name, object defaultValue)
        {
            return null;
        }
    }
}