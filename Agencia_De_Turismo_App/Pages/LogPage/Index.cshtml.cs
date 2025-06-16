using Agencia_De_Turismo_App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Agencia_De_Turismo_App.Pages.Log
{
    public class IndexModel : PageModel
    {
        public string? MensagemFinal { get; set; }

        public static List<string> LogEmMemoria = new();
        public void OnGet()
        {
        }

        public void OnPost()
        {
            Action<string> logger = LoggerService.LogToConsole;
            logger += LoggerService.LogToFile;
            logger += LoggerService.LogToMemory;

            string mensagem = $"Reserva criada em {DateTime.Now:HH:mm:ss}";

            logger.Invoke(mensagem);

            MensagemFinal = mensagem;

        }

       
    }
}
