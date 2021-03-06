using Sitecore.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace ADSG.Foundation.Framework.Logging
{
    public class Logger : DefaultLog
    {
        public void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            base.Info($"[{Path.GetFileNameWithoutExtension(sourceFilePath)}.{memberName}:{lineNumber}] - {message}", "ApplicationLog");
        }

        public void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            base.Error($"[{Path.GetFileNameWithoutExtension(sourceFilePath)}.{memberName}:{lineNumber}] - {message}", "ApplicationLog");
        }
    }
}