using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Host;

namespace CodeOwls.PowerShell.ScriptCS
{
    public interface ICmdletContext
    {
        CommandOrigin CommandOrigin { get; }
        bool Stopping { get; }
        ICommandRuntime CommandRuntime { get; set; }
        PSTransactionContext CurrentPSTransaction { get; }
        string ParameterSetName { get; }
        InvocationInfo MyInvocation { get; }
        CommandInvocationIntrinsics InvokeCommand { get; }
        PSHost Host { get; }
        SessionState SessionState { get; }
        PSEventManager Events { get; }
        JobRepository JobRepository { get; }
        ProviderIntrinsics InvokeProvider { get; }
        object[] Input { get; }
        string GetResourceString(string baseName, string resourceId);
        void WriteError(ErrorRecord errorRecord);
        void WriteObject(object sendToPipeline);
        void WriteObject(object sendToPipeline, bool enumerateCollection);
        void WriteVerbose(string text);
        void WriteWarning(string text);
        void WriteCommandDetail(string text);
        void WriteProgress(ProgressRecord progressRecord);
        void WriteDebug(string text);
        bool ShouldProcess(string target);
        bool ShouldProcess(string target, string action);
        bool ShouldProcess(string verboseDescription, string verboseWarning, string caption);

        bool ShouldProcess(string verboseDescription, string verboseWarning, string caption,
                           out ShouldProcessReason shouldProcessReason);

        bool ShouldContinue(string query, string caption);
        bool ShouldContinue(string query, string caption, ref bool yesToAll, ref bool noToAll);
        bool TransactionAvailable();
        void ThrowTerminatingError(ErrorRecord errorRecord);
        PathInfo CurrentProviderLocation(string providerId);
        string GetUnresolvedProviderPathFromPSPath(string path);
        Collection<string> GetResolvedProviderPathFromPSPath(string path, out ProviderInfo provider);
        object GetVariableValue(string name);
        object GetVariableValue(string name, object defaultValue);
    }
}