namespace EntityProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Transaction
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Product_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Transaction_Id { get; set; }

        public int? Quantity { get; set; }

        public int? Expiration_Period { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Production_Date { get; set; }

        public virtual Product Product { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
