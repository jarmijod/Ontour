namespace Trin.OnTour.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DetallePago")]
    public partial class DetallePago
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Codigo { get; set; }

        public int Monto { get; set; }

        [Required]
        [StringLength(10)]
        public string RutApoderado { get; set; }

        public long CodigoContrato { get; set; }

        public virtual Apoderado Apoderado { get; set; }

        public virtual Contrato Contrato { get; set; }

        public virtual PagoDeposito PagoDeposito { get; set; }
    }
}
