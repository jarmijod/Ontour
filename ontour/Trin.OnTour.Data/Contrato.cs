namespace Trin.OnTour.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contrato")]
    public partial class Contrato
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contrato()
        {
            DetallePago = new HashSet<DetallePago>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Codigo { get; set; }

        public int CantidadDias { get; set; }

        [Required]
        [StringLength(10)]
        public string RutEjecutivo { get; set; }

        public long? CodigoCurso { get; set; }

        [StringLength(5)]
        public string CodigoPaqueteTuristico { get; set; }

        public virtual Curso Curso { get; set; }

        public virtual PaqueteTuristico PaqueteTuristico { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetallePago> DetallePago { get; set; }
    }
}
