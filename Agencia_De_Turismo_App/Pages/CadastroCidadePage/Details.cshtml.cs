using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Agencia_De_Turismo_App.Data;
using TurismoApp.Domain.models;

namespace Agencia_De_Turismo_App.Pages.CadastroCidadePage
{
    public class DetailsModel : PageModel
    {
        private readonly Agencia_De_Turismo_App.Data.AppDbContext _context;

        public DetailsModel(Agencia_De_Turismo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public CidadeDestino CidadeDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            CidadeDestino = await _context.CidadeDestino
                 .Include(c => c.Pacotes)
                    .Include(c => c.PontosTuristicos)
                    .FirstOrDefaultAsync(m => m.Id == id);

            if (id == null)
            {
                return NotFound();
            }

            var cidadedestino = await _context.CidadeDestino.FirstOrDefaultAsync(m => m.Id == id);

            if (cidadedestino is not null)
            {
                CidadeDestino = cidadedestino;

                return Page();
            }

            return NotFound();
        }
    }
}
