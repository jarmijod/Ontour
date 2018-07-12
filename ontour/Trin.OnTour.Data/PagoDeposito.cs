namespace Trin.OnTour.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PagoDeposito")]
    public partial class PagoDeposito
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Codigo { get; set; }

        [Required]
        [StringLength(20)]
        public string EntidadBancaria { get; set; }

        [Required]
        [StringLength(40)]
        public string ComprobantePago { get; set; }

        public virtual DetallePago DetallePago { get; set; }
    }
}
