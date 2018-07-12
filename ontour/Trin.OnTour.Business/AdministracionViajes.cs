using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trin.OnTour.Data;

namespace Trin.OnTour.Business
{
    public class AdministracionViajes
    {
        protected OnTourContext Context { get; }

        public AdministracionViajes(OnTourContext context) => Context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<(bool success, string msg)> RegistrarContrato(int nDias, string rutEjecutivo, long curso, string paqueteTuristico)
        {
            if (new[]{rutEjecutivo, paqueteTuristico}.IsAnyNullOrEmpty()) { return (false, "No debe haber datos vacíos"); }

            try
            {
                var contrato = new Contrato()
                {
                    Codigo = DateTime.Now.Ticks,
                    CantidadDias = nDias,
                    RutEjecutivo = rutEjecutivo,
                    CodigoCurso = curso,
                    CodigoPaqueteTuristico = paqueteTuristico
                };

                Context.Contrato.Add(contrato);
                await Context.SaveChangesAsync();

                return (true, contrato.ObtenerInfo());
            }
            catch(Exception e) { return (false, e.Message); }
        }

        public async Task<(bool success, string msg)> RegistrarPago(string apoderado, int monto, long contrato)
        {
            if (new[] { apoderado }.IsAnyNullOrEmpty()) { return (false, "No debe haber datos vacíos"); }

            try
            {
                var pago = new DetallePago()
                {
                    Codigo = DateTime.Now.Ticks,
                    RutApoderado = apoderado,
                    Monto = monto,
                    CodigoContrato = contrato
                };

                Context.DetallePago.Add(pago);
                await Context.SaveChangesAsync();

                return (true, pago.ObtenerInfo());
            }
            catch (Exception e) { return (false, e.Message); }
        }

        public async Task<(bool success, string msg)> RegistrarDeposito(string apoderado, int monto, long contrato, string banco, string comprobante)
        {
            if (new[] { apoderado, banco, comprobante }.IsAnyNullOrEmpty()) { return (false, "No debe haber datos vacíos"); }

            try
            {
                var cod = DateTime.Now.Ticks;
                var pago = new PagoDeposito()
                {
                    DetallePago = new DetallePago()
                    {
                        Codigo = cod,
                        RutApoderado = apoderado,
                        Monto = monto,
                        CodigoContrato = contrato
                    },
                    Codigo = cod,
                    ComprobantePago = comprobante,
                    EntidadBancaria = banco
                };

                Context.PagoDeposito.Add(pago);
                await Context.SaveChangesAsync();

                return (true, pago.ObtenerInfo());
            }
            catch (Exception e) { return (false, e.Message); }
        }
    }
}
