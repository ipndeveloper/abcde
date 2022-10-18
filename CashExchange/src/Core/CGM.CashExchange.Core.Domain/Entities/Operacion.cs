using CGM.CashExchange.Core.Domain.Enums;
using CGM.CashExchange.Core.Domain.ValueObject;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CGM.CashExchange.Core.Domain.Entities
{
    public class Operacion
    {
        private DateTime _fechaCreacion;
        private DateTime _fechaCancelacion;
        public int IdFicha { get; set; } // auto generado
        // idficha y tipo = 
        //  1-TIP1
        //  2.TIPO2
       
        public int IdCajero { get; set; } 

        public string IdOperacionMaccord { get; set; }
        public DateTime FechaCreacion { get; private set; }
        public DateTime FechaCancelacion { get; private set; }
        public OperacionEstado Estado { get; private set; }
        private decimal _monto;
   
        public Euros Monto { get; private set; }
        protected Operacion()
        {
   
        }
        private void SetFechaCreacion(DateTime InputFechaCreacion)
        {
            _fechaCreacion = InputFechaCreacion;
        }
        private void SetFechaCancelacion(DateTime InputFechaCancelacion)
        {
            _fechaCancelacion = InputFechaCancelacion;
        }
        public Operacion(Euros monto, DateTime? fechaCreacion, int idCajero, string idOperacionMaccord) : this()
        {
            if (monto == null || monto.IsZero)
                throw new ArgumentException(nameof(monto));

            if (fechaCreacion == null)
                throw new ArgumentException(nameof(fechaCreacion));
            Monto = monto;
            FechaCreacion = fechaCreacion.Value;
            Estado = OperacionEstado.Creado;
            IdCajero = idCajero;
            IdOperacionMaccord = idOperacionMaccord;
        }
        public virtual bool Cancelar()
        {
            if (DateTime.UtcNow > FechaCreacion.AddMinutes(15))
                return false;

            FechaCancelacion= DateTime.UtcNow;
            Estado = OperacionEstado.Cancelado;
            return true;
        }
 
    }
  
}
