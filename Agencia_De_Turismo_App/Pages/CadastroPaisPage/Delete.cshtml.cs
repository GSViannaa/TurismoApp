using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agencia_De_Turismo_App.Data;
using TurismoApp.Domain.models;
using Microsoft.AspNetCore.Authorization;

namespace Agencia_De_Turismo_App.Pages_CadastroPaisPage
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly Agencia_De_Turismo_App.Data.AppDbContext _context;

        public DeleteModel(Agencia_De_Turismo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaisDestino PaisDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PaisDestino = await _context.PaisesDestino
                 .Where(p => !p.IsDeleted)
                 .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var pais = await _context.PaisesDestino.FindAsync(id);

            if (pais != null)
            {
                pais.IsDeleted = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
