using asp.net_fundamental.Services.Interfaces;

namespace asp.net_fundamental.Services
{
    public class LogginService : ILogginService<LogData>
    {
        private readonly string _fileName = "log.txt";
        public void Log(LogData logData)
        {
            try
            {
                if (File.Exists(_fileName))
                {
                    using (var writer = File.AppendText(_fileName))
                    {

                        WriteToFile(writer, logData);
                    }
                }
                else
                {
                    using (var writer = File.CreateText(_fileName))
                    {
                        WriteToFile(writer, logData);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] Write to file failed - Exception: {ex}");
            }
        }

        private void WriteToFile(StreamWriter writer, LogData data)
        {
            writer.WriteLine($"Time: [{DateTime.Now}]");
            writer.WriteLine(data);
        }
    }
}
