using System.Runtime.CompilerServices;

namespace ADSG.Foundation.Framework.Logging
{
    public interface ILogger
    {
        void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int lineNumber = 0);
        void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int lineNumber = 0);
    }
}
