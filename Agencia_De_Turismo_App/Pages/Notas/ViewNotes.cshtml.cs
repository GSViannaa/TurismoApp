using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Agencia_De_Turismo_App.Pages.Notas
{
    public class ViewNotesModel : PageModel
    {
        private readonly string _pastaNotas;

        public ViewNotesModel(IWebHostEnvironment env)
        {
            _pastaNotas = Path.Combine(env.WebRootPath, "files");

            
            if (!Directory.Exists(_pastaNotas))
            {
                Directory.CreateDirectory(_pastaNotas);
            }
        }

        [BindProperty]
        public string NovaNota { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string? ArquivoSelecionado { get; set; }

        public List<string> ArquivosDisponiveis { get; set; } = new();
        public string? ConteudoArquivo { get; set; }

        public void OnGet()
        {
            CarregarArquivos();

            if (!string.IsNullOrEmpty(ArquivoSelecionado))
            {
                var caminho = Path.Combine(_pastaNotas, ArquivoSelecionado);
                if (System.IO.File.Exists(caminho))
                {
                    ConteudoArquivo = System.IO.File.ReadAllText(caminho);
                }
            }
        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrWhiteSpace(NovaNota))
            {
                var nomeArquivo = $"nota_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
                var caminho = Path.Combine(_pastaNotas, nomeArquivo);
                System.IO.File.WriteAllText(caminho, NovaNota);
            }

            return RedirectToPage();
        }

        private void CarregarArquivos()
        {
            ArquivosDisponiveis = Directory
                .GetFiles(_pastaNotas, "*.txt")
                .Select(Path.GetFileName)
                .ToList();
        }
    }

}
