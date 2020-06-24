using System;
using System.IO;

namespace OANDA.Logs
{
    public class LogWriter
    {
        public static void WriteLog(string strLog)
        {
            string logFilePath = @"C:\Users\Andrea\Downloads\mt4samples\Logs\Logs.txt";
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    log.WriteLine(strLog);
                }
            }
        }
    }
}
