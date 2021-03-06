using log4net;
using System.IO;
using System.Runtime.CompilerServices;

namespace ADSG.Foundation.Framework.Logging
{
    public class Logger
    {
        private readonly ILog _logger;

        public Logger(ILog Log)
        {
            _logger = Log;
        }

        public void Info(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            _logger.Info($"[{Path.GetFileNameWithoutExtension(sourceFilePath)}.{memberName}:{lineNumber}] - {message}");
        }

        public void Error(string message, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int lineNumber = 0)
        {
            _logger.Error($"[{Path.GetFileNameWithoutExtension(sourceFilePath)}.{memberName}:{lineNumber}] - {message}");
        }
    }
}