using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trin.OnTour.Data;

namespace Trin.OnTour.Business
{
    public class AdministracionClientes
    {
        protected OnTourContext Context { get; }

        public AdministracionClientes() : this(new OnTourContext()) { }

        public AdministracionClientes(OnTourContext context) => Context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<(bool success, string msg)> CrearCursoAsync(string alias, int nAlumnos, string establecimiento, string representante)
        {
            if (new[] { alias, establecimiento, representante }.IsAnyNullOrEmpty()) { return (false, "No puede haber datos vacíos"); }
            if (nAlumnos < 5) { return (false, "El número de alumnos no puede ser menor a 5"); }

            try
            {
                var curso = new Curso()
                {
                    Codigo = DateTime.Now.Ticks,
                    Alias = alias,
                    CantidadAlumnos = nAlumnos,
                    Establecimiento = establecimiento,
                    RutRepresentante = representante
                };

                Context.Curso.Add(curso);
                await Context.SaveChangesAsync();

                return (true, curso.ObtenerInfo());
            }
            catch (Exception e) { return (false, e.Message); }
        }

        public async Task<(bool success, string msg)> CrearApoderadoAsync(string rut, string nombreCompleto, string email, long curso, string rutAlumno, string telefono = null)
        {
            if (new[] { rut, nombreCompleto, email, rutAlumno}.IsAnyNullOrEmpty()) { return (false, "No puede haber datos vacíos"); }

            try
            {
                var apoderado = new Apoderado()
                {
                    Persona = new Persona()
                    {
                        Rut = rut,
                        NombreCompleto = nombreCompleto,
                        Email = email,
                        Telefono = telefono
                    },
                    Rut = rut,
                    CodigoCurso = curso,
                    MontoAportado = 0,
                    RutAlumno = rutAlumno
                };

                Context.Apoderado.Add(apoderado);
                await Context.SaveChangesAsync();

                return (true, apoderado.ObtenerInfo());
            }
            catch (Exception e) { return (false, e.Message); }
        }

        public async Task<(bool success, string msg)> CrearRepresentanteAsync(string rut, string nombreCompleto, string email, long curso, string telefono = null)
        {
            if (new[] { rut, nombreCompleto, email }.IsAnyNullOrEmpty()) { return (false, "No puede haber datos vacíos"); }

            try
            {
                var representante = new Representante()
                {
                    Persona = new Persona()
                    {
                        Rut = rut,
                        NombreCompleto = nombreCompleto,
                        Email = email,
                        Telefono = telefono
                    },
                    Rut = rut,
                };

                Context.Representante.Add(representante);
                await Context.SaveChangesAsync();

                return (true, representante.ObtenerInfo());
            }
            catch (Exception e) { return (false, e.Message); }
        }

        public IEnumerable GetAllCursos(string establecimiento) => Context.Curso.Where(x => x.Establecimiento.Equals(establecimiento)).ToList();

        public long GetIdCurso(Object obj) => ((Curso)obj).Codigo;

        public IEnumerable GetAllApoderados() => Context.Apoderado.ToList();
    }
}
