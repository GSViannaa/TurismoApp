namespace Agencia_De_Turismo_App.Services
{
    public class LoggerService
    {
        public static List<string> LogEmMemoria = new();

        public static void LogToConsole(string msg)
        {
            Console.WriteLine($"[Console] {msg}");
        }

        public static void LogToFile(string msg)
        {
            string caminho = "wwwroot/logs.txt";
            Directory.CreateDirectory("wwwroot");
            File.AppendAllText(caminho, $"[Arquivo] {msg}{Environment.NewLine}");
        }

        public static void LogToMemory(string msg)
        {
            LogEmMemoria.Add($"[Memória] {msg}");
        }
    }
}

