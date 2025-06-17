using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agencia_De_Turismo_App.Data;
using TurismoApp.Domain.models;

namespace Agencia_De_Turismo_App.Pages_CadastroCidadePage
{
    public class DeleteModel : PageModel
    {
        private readonly Agencia_De_Turismo_App.Data.AppDbContext _context;

        public DeleteModel(Agencia_De_Turismo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.CidadesDestino.FirstOrDefaultAsync(m => m.Id == id);

            if (cidadedestino is not null)
            {
                CidadeDestino = cidadedestino;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.CidadesDestino.FindAsync(id);
            if (cidadedestino != null)
            {
                CidadeDestino = cidadedestino;
                _context.CidadesDestino.Remove(CidadeDestino);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
