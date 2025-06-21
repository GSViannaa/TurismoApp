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
    public class IndexModel : PageModel
    {
        private readonly Agencia_De_Turismo_App.Data.AppDbContext _context;

        public IndexModel(Agencia_De_Turismo_App.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<PaisDestino> PaisDestino { get;set; } = default!;

        public async Task OnGetAsync()
        {
            PaisDestino = await _context.PaisesDestino.ToListAsync();
        }
    }
}
