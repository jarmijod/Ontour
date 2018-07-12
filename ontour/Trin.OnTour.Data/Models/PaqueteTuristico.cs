namespace Trin.OnTour.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PaqueteTuristico")]
    public partial class PaqueteTuristico
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PaqueteTuristico()
        {
            Contrato = new HashSet<Contrato>();
        }

        [Key]
        [StringLength(5)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(20)]
        public string Origen { get; set; }

        [Required]
        [StringLength(20)]
        public string Destino { get; set; }

        public int DiasMinimos { get; set; }

        public int DiasMaximos { get; set; }

        public int ValorBase { get; set; }

        public int ValorPasajero { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
    }
}
