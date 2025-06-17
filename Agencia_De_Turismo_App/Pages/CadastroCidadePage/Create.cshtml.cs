using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agencia_De_Turismo_App.Data;
using TurismoApp.Domain.models;

namespace Agencia_De_Turismo_App.Pages_CadastroCidadePage
{
    public class CreateModel : PageModel
    {
        private readonly Agencia_De_Turismo_App.Data.AppDbContext _context;

        public CreateModel(Agencia_De_Turismo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = null!;

        public SelectList ListaPaises { get; set; } = null!;

        public IActionResult OnGet()
        {
            ListaPaises = new SelectList(_context.PaisesDestino.ToList(), "Id", "Nome");
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {

            ListaPaises = new SelectList(_context.PaisesDestino, "Id", "Nome");

            if (!ModelState.IsValid) return Page();
            

            _context.CidadesDestino.Add(CidadeDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
