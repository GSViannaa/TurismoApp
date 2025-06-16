using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Agencia_De_Turismo_App.Data;
using TurismoApp.Domain.models;

namespace Agencia_De_Turismo_App.Pages_CadastroPaisPage
{
    public class CreateModel : PageModel
    {
        private readonly Agencia_De_Turismo_App.Data.AppDbContext _context;

        public CreateModel(Agencia_De_Turismo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PaisDestino PaisDestino { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PaisesDestino.Add(PaisDestino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
