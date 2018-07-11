namespace Trin.OnTour.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Persona")]
    public partial class Persona
    {
        [Key]
        [StringLength(10)]
        public string Rut { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreCompleto { get; set; }

        [StringLength(8)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(30)]
        public string Email { get; set; }

        public virtual Apoderado Apoderado { get; set; }

        public virtual Representante Representante { get; set; }
    }
}
