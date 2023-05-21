using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityProject
{
	public partial class Project : DbContext
	{
		public Project()
			: base("name=Project")
		{
		}

		public virtual DbSet<Client> Clients { get; set; }
		public virtual DbSet<Permission> Permissions { get; set; }
		public virtual DbSet<Permission_Product> Permission_Product { get; set; }
		public virtual DbSet<Product> Products { get; set; }
		public virtual DbSet<Product_Transaction> Product_Transaction { get; set; }
		public virtual DbSet<Supplier> Suppliers { get; set; }
		public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
		public virtual DbSet<Transaction> Transactions { get; set; }
		public virtual DbSet<Warehouse> Warehouses { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Client>()
				.Property(e => e.Client_Name)
				.IsUnicode(false);

			modelBuilder.Entity<Client>()
				.Property(e => e.Telephone)
				.IsUnicode(false);

			modelBuilder.Entity<Client>()
				.Property(e => e.Mobile)
				.IsUnicode(false);

			modelBuilder.Entity<Client>()
				.Property(e => e.Fax)
				.IsUnicode(false);

			modelBuilder.Entity<Client>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Client>()
				.Property(e => e.Website)
				.IsUnicode(false);

			modelBuilder.Entity<Client>()
				.HasMany(e => e.Products)
				.WithMany(e => e.Clients)
				.Map(m => m.ToTable("Client_Product").MapLeftKey("Client_Name"));

			modelBuilder.Entity<Permission>()
				.Property(e => e.Type)
				.IsUnicode(false);

			modelBuilder.Entity<Permission>()
				.Property(e => e.Warhouse_Name)
				.IsUnicode(false);

			modelBuilder.Entity<Permission>()
				.Property(e => e.Supplier_Name)
				.IsUnicode(false);

			modelBuilder.Entity<Permission>()
				.HasMany(e => e.Permission_Product)
				.WithRequired(e => e.Permission)
				.HasForeignKey(e => e.Permission_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Permission_Product)
				.WithRequired(e => e.Product)
				.HasForeignKey(e => e.Product_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Product_Transaction)
				.WithRequired(e => e.Product)
				.HasForeignKey(e => e.Product_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Product>()
				.HasMany(e => e.Warehouses)
				.WithMany(e => e.Products)
				.Map(m => m.ToTable("Warehouse_Product"));

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Telephone)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Mobile)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Fax)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Website)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.Property(e => e.Email)
				.IsUnicode(false);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.Permissions)
				.WithRequired(e => e.Supplier)
				.HasForeignKey(e => e.Supplier_Name)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Supplier>()
				.HasMany(e => e.Transactions)
				.WithOptional(e => e.Supplier)
				.HasForeignKey(e => e.Supplier_Name);

			modelBuilder.Entity<Transaction>()
				.Property(e => e.Supplier_Name)
				.IsUnicode(false);

			modelBuilder.Entity<Transaction>()
				.Property(e => e.To_Warhouse)
				.IsUnicode(false);

			modelBuilder.Entity<Transaction>()
				.Property(e => e.From_Warhouse)
				.IsUnicode(false);

			modelBuilder.Entity<Transaction>()
				.HasMany(e => e.Product_Transaction)
				.WithRequired(e => e.Transaction)
				.HasForeignKey(e => e.Transaction_Id)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Warehouse>()
				.Property(e => e.Name)
				.IsUnicode(false);

			modelBuilder.Entity<Warehouse>()
				.Property(e => e.Address)
				.IsUnicode(false);

			modelBuilder.Entity<Warehouse>()
				.Property(e => e.Manager)
				.IsUnicode(false);

			modelBuilder.Entity<Warehouse>()
				.HasMany(e => e.Permissions)
				.WithRequired(e => e.Warehouse)
				.HasForeignKey(e => e.Warhouse_Name)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Warehouse>()
				.HasMany(e => e.Transactions)
				.WithOptional(e => e.Warehouse)
				.HasForeignKey(e => e.To_Warhouse);

			modelBuilder.Entity<Warehouse>()
				.HasMany(e => e.Transactions1)
				.WithOptional(e => e.Warehouse1)
				.HasForeignKey(e => e.From_Warhouse);
		}
	}
}
