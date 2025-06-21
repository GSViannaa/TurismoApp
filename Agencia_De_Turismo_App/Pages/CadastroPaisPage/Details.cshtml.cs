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
    public class DetailsModel : PageModel
    {
        private readonly Agencia_De_Turismo_App.Data.AppDbContext _context;

        public DetailsModel(Agencia_De_Turismo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public PaisDestino PaisDestino { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paisdestino = await _context.PaisesDestino.FirstOrDefaultAsync(m => m.Id == id);

            if (paisdestino is not null)
            {
                PaisDestino = paisdestino;

                return Page();
            }

            return NotFound();
        }
    }
}
