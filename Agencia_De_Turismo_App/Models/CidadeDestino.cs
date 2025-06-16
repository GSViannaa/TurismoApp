using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoApp.Domain.models
{
    public  class CidadeDestino
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MinLength(3, ErrorMessage = "Mínimo de 3 caracteres.")]
        public string Nome { get; set; } = null!;

        [Required(ErrorMessage = "Selecione um país.")]
        public int PaisDestinoId { get; set; }

        public ICollection<PontoTuristico> PontosTuristicos { get; } = new List<PontoTuristico>();
        public ICollection<PacoteTuristico> Pacotes { get; } = new List<PacoteTuristico>();
    }
}
