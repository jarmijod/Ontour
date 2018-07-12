using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trin.OnTour.Data;

namespace Trin.OnTour.Business
{
    public static class Extensions
    {
        public static bool IsAnyNullOrEmpty(this IEnumerable<string> self)
        {
            foreach (var str in self)
            {
                if (String.IsNullOrEmpty(str)) { return true; }
            }
            return false;
        }

        public static string ObtenerInfo(this Curso self) =>
 $@"Codigo : {self.Codigo}
  Alias : {self.Codigo}
  N° Alumnos : {self.CantidadAlumnos},
  Establecimiento : {self.Establecimiento},
  Representante : {self.RutRepresentante}";

        public static string ObtenerInfo(this Persona self) =>
 $@"Rut : {self.Rut},
  Nombre : {self.NombreCompleto},
  Email : {self.Email},
  Telefono : {self.Telefono}";

        public static string ObtenerInfo(this Apoderado self) =>
$@"{self.Persona.ObtenerInfo()},
  Curso : {self.Curso.Establecimiento}, {self.Curso.Alias},
  Alumno : {self.RutAlumno},
  Monto aportado : {self.MontoAportado}";

        public static string ObtenerInfo(this Representante self) => self.Persona.ObtenerInfo();

        public static string ObtenerInfo(this Contrato self) =>
$@"Codigo : {self.Codigo},
  N° Días : {self.CantidadDias},
  P. Turístico : {self.CodigoPaqueteTuristico},
  Curso : {self.Curso.Establecimiento}, {self.Curso.Alias}";

        public static string ObtenerInfo(this DetallePago self) =>
$@"Codigo : {self.Codigo},
  Apoderado : {self.RutApoderado},
  Monto : {self.Monto}";

        public static string ObtenerInfo(this PagoDeposito self) =>
$@"{self.DetallePago.ObtenerInfo()},
  Banco : {self.EntidadBancaria},
  Comprobante : {self.ComprobantePago}"
    }
}
