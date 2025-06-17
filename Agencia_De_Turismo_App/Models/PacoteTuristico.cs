using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoApp.Domain.models
{
   public class PacoteTuristico
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public DateTime DataInicio { get; set; }
        public int CapacidadeMaxima { get; set; }

        public ICollection<CidadeDestino> Cidades { get; set; } = new List<CidadeDestino>();
        public ICollection<Reservas> Reservas { get; set; } = new List<Reservas>();


        public event Action<string>? CapacityReached;

        public void AdicionarReserva(Reservas reserva)
        {
            if (Reservas.Count >= CapacidadeMaxima)
                throw new InvalidOperationException("Capacidade esgotada.");

            Reservas.Add(reserva);

           
            if (Reservas.Count == CapacidadeMaxima)
                CapacityReached?.Invoke("Capacidade do pacote atingida!");
        }

    }
}
