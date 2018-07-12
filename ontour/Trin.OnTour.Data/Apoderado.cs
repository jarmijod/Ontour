namespace Trin.OnTour.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Apoderado")]
    public partial class Apoderado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apoderado()
        {
            DetallePago = new HashSet<DetallePago>();
        }

        [Key]
        [StringLength(10)]
        public string Rut { get; set; }

        [Required]
        [StringLength(10)]
        public string RutAlumno { get; set; }

        public int MontoAportado { get; set; }

        public long CodigoCurso { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual Persona Persona { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePago> DetallePago { get; set; }
    }
}
