using System.Text;

namespace asp.net_fundamental.Services
{
    public class LogData
    {
        public string? Schema { get; set; }
        public string? Host { get; set; }
        public string? Path { get; set; }
        public string? QueryString { get; set; }
        public string? RequestBody { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine($"Schema : [{Schema}]");
            builder.AppendLine($"Host : [{Host}]");
            builder.AppendLine($"Path : [{Path}]");
            builder.AppendLine($"QueryString : [{QueryString}]");
            builder.AppendLine($"Request Body : [{RequestBody}]");
            return builder.ToString();
        }
    }
}