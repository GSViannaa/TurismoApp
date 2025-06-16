using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoApp.Domain.models
{
   public class Reservas
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public int PacoteTuristicoId { get; set; }
        public PacoteTuristico PacoteTuristico { get; set; } = null!;

        public DateTime DataReserva { get; set; }
    }
}
