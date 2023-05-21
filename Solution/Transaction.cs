namespace EntityProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            Product_Transaction = new HashSet<Product_Transaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Supplier_Name { get; set; }

        [StringLength(50)]
        public string To_Warhouse { get; set; }

        [StringLength(50)]
        public string From_Warhouse { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Transaction> Product_Transaction { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Warehouse Warehouse1 { get; set; }
    }
}
