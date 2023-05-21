namespace EntityProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Permission_Product
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Permission_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_Id { get; set; }

        public int? Quantity { get; set; }

        public int? Expiration_Period { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Production_Date { get; set; }

        public virtual Permission Permission { get; set; }

        public virtual Product Product { get; set; }
    }
}
