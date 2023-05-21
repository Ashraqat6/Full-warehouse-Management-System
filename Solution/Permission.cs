namespace EntityProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Permission()
        {
            Permission_Product = new HashSet<Permission_Product>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [Required]
        [StringLength(50)]
        public string Warhouse_Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Supplier_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Permission_Product> Permission_Product { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse { get; set; }
    }
}
