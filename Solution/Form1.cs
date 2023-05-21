using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityProject
{
	public partial class Form1 : Form
	{
		Project Ent=new Project();
		Product product=new Product();
		Warehouse warehouse = new Warehouse();
		Supplier supplier = new Supplier();
		Client client = new Client();
		Permission permission=new Permission();
		Transaction transaction = new Transaction();
		Permission_Product permission_product = new Permission_Product();
		Product_Transaction product_transaction = new Product_Transaction();
		public Form1()
		{
			InitializeComponent();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			listBox1.Items.Add("ID\tName");
			listBox1.Items.Add("-------------------------------------------------------------------------------");
			foreach (Product pt in Ent.Products)
			{
				listBox1.Items.Add(pt.Id + "\t" + pt.Name);
			}
			listBox2.Items.Add("Name\t\tAddress\t\tManager");
			listBox2.Items.Add("-------------------------------------------------------------------------------");

			foreach (Warehouse w in Ent.Warehouses)
			{
				listBox2.Items.Add(w.Name + "\t" + w.Address + "\t\t" + w.Manager);
			}
			listBox3.Items.Add("Name\t\tMobile\t\tEmail");
			listBox3.Items.Add("-------------------------------------------------------------------------------");

			foreach (Supplier s in Ent.Suppliers)
			{
				listBox3.Items.Add(s.Name + "\t" + s.Mobile + "\t" + s.Email);
			}
			listBox4.Items.Add("Name\t\tMobile\t\tEmail");
			listBox4.Items.Add("-------------------------------------------------------------------------------");

			foreach (Client c in Ent.Clients)
			{
				listBox4.Items.Add(c.Client_Name + "\t" + c.Mobile + "\t" + c.Email);
			}
			listBox5.Items.Add("ID\tType\tWareHouse Name\t\tSupplier Name");
			listBox5.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Permission pr in Ent.Permissions)
			{
				listBox5.Items.Add(pr.Id + "\t" + pr.Type + "\t" +pr.Warhouse_Name + "\t\t" +pr.Supplier_Name);
			}
			listBox6.Items.Add("ID\tTo\t\tFrom\t\tSupplier Name");
			listBox6.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Transaction t in Ent.Transactions)
			{
				listBox6.Items.Add(t.Id + "\t" + t.To_Warhouse + "\t" +t.From_Warhouse + "\t" +t.Supplier_Name);
			}
			listBox9.Items.Add("Product ID\tPermission ID\tQuantity");
			listBox9.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Permission_Product pp in Ent.Permission_Product)
			{
				listBox9.Items.Add(pp.Product_Id + "\t\t" + pp.Permission_Id + "\t\t" + pp.Quantity);
			}
			listBox10.Items.Add("Product ID\tTransaction ID\tQuantity");
			listBox10.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Product_Transaction pt in Ent.Product_Transaction)
			{
				listBox10.Items.Add(pt.Product_Id + "\t\t" + pt.Transaction_Id + "\t\t" + pt.Quantity);
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{

			if (textBox1.Text != "" && textBox2.Text != "")
			{
				Product pt = Ent.Products.Find(int.Parse(textBox1.Text));
				if (pt == null)
				{
					product.Id = int.Parse(textBox1.Text);
					product.Name = textBox2.Text;
					Ent.Products.Add(product);
					Ent.SaveChanges();
					listBox1.Items.Add(textBox1.Text+"\t"+ textBox2.Text);
					textBox1.Text = textBox2.Text = "";
				}
				else
				{
					MessageBox.Show("Product is Available");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{

			product = Ent.Products.Find(int.Parse(textBox1.Text));
			if (product != null)
			{
				if (textBox2.Text != "")
				{
					product.Name = textBox2.Text;
					Ent.SaveChanges();
					textBox1.Text = textBox2.Text = "";
				}
				else
				{
					MessageBox.Show("No Name Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available Product");
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
			{
				Warehouse wh = Ent.Warehouses.Find(textBox3.Text);
				if (wh == null)
				{
					warehouse.Name = textBox3.Text;
					warehouse.Address = textBox4.Text;
					warehouse.Manager= textBox5.Text;
					Ent.Warehouses.Add(warehouse);
					Ent.SaveChanges();
					listBox2.Items.Add(textBox3.Text + "\t\t" + textBox4.Text + "\t\t" + textBox5.Text);
					textBox3.Text = textBox4.Text = textBox5.Text = "";
				}
				else
				{
					MessageBox.Show("Product is Available");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			warehouse = Ent.Warehouses.Find(textBox3.Text);
			if (warehouse != null)
			{
				if (textBox4.Text != "" && textBox5.Text != "")
				{
					warehouse.Address = textBox4.Text;
					warehouse.Manager = textBox5.Text;
					Ent.SaveChanges();
					textBox3.Text= textBox4.Text = textBox5.Text = "";
				}
				else
				{
					MessageBox.Show("No Name or Address Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available warehouse");
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
			{
				Supplier sp = Ent.Suppliers.Find(textBox6.Text);
				if (sp == null)
				{
					supplier.Name = textBox6.Text;
					supplier.Mobile = textBox7.Text;
					supplier.Email= textBox8.Text;
					Ent.Suppliers.Add(supplier);
					Ent.SaveChanges();
					listBox3.Items.Add(textBox6.Text + "\t\t" + textBox7.Text + "\t\t" + textBox8.Text);
					textBox6.Text = textBox7.Text = textBox8.Text = "";
				}
				else
				{
					MessageBox.Show("Supplier is Available");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			supplier = Ent.Suppliers.Find(textBox6.Text);
			if (supplier != null)
			{
				if (textBox7.Text != "" && textBox8.Text != "")
				{
					supplier.Mobile = textBox7.Text;
					supplier.Email = textBox8.Text;
					Ent.SaveChanges();
					textBox6.Text = textBox7.Text = textBox8.Text = "";
				}
				else
				{
					MessageBox.Show("No Mobile or Email Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available Supplier");
			}
		}

		private void button8_Click(object sender, EventArgs e)
		{
			if (textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "")
			{
				Client c = Ent.Clients.Find(textBox9.Text);
				if (c == null)
				{
					client.Client_Name = textBox9.Text;
					client.Mobile = textBox10.Text;
					client.Email = textBox11.Text;
					Ent.Clients.Add(client);
					Ent.SaveChanges();
					listBox4.Items.Add(textBox9.Text + "\t\t" + textBox10.Text + "\t\t" + textBox11.Text);
					textBox9.Text = textBox10.Text = textBox11.Text = "";
				}
				else
				{
					MessageBox.Show("Client is Available");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button7_Click(object sender, EventArgs e)
		{
			client = Ent.Clients.Find(textBox9.Text);
			if (client != null)
			{
				if (textBox10.Text != "" && textBox11.Text != "")
				{
					client.Mobile = textBox10.Text;
					client.Email = textBox11.Text;
					Ent.SaveChanges();
					textBox9.Text = textBox10.Text = textBox11.Text = "";
				}
				else
				{
					MessageBox.Show("No Mobile or Email Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available Client");
			}
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if (textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
			{
				Permission p = Ent.Permissions.Find(int.Parse(textBox12.Text));
				if (p == null)
				{
					permission.Id =int.Parse(textBox12.Text);
					permission.Type = textBox13.Text;
					permission.Warhouse_Name = textBox14.Text;
					permission.Supplier_Name = textBox15.Text;

					Ent.Permissions.Add(permission);
					Ent.SaveChanges();
					listBox5.Items.Add(textBox12.Text + "\t" + textBox13.Text + "\t" + textBox14.Text + "\t\t" + textBox15.Text);
					textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
				}
				else
				{
					MessageBox.Show("Permission is Available");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button9_Click(object sender, EventArgs e)
		{
			permission = Ent.Permissions.Find(int.Parse(textBox12.Text));
			if (permission != null)
			{
				if (textBox13.Text != "" && textBox14.Text != "" && textBox15.Text != "")
				{
					permission.Type = textBox13.Text;
					permission.Warhouse_Name = textBox14.Text;
					permission.Supplier_Name = textBox15.Text;
					Ent.SaveChanges();
					textBox12.Text = textBox13.Text = textBox14.Text = textBox15.Text = "";
				}
				else
				{
					MessageBox.Show("No Type or Name Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available Permission");
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			if (textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "")
			{
				Transaction t = Ent.Transactions.Find(int.Parse(textBox16.Text));
				if (t == null)
				{
					transaction.Id = int.Parse(textBox16.Text);
					transaction.To_Warhouse = textBox17.Text;
					transaction.From_Warhouse = textBox18.Text;
					transaction.Supplier_Name = textBox19.Text;

					Ent.Transactions.Add(transaction);
					Ent.SaveChanges();
					listBox6.Items.Add(textBox16.Text + "\t" + textBox17.Text + "\t\t" + textBox18.Text + "\t\t" + textBox19.Text);
					textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = "";
				}
				else
				{
					MessageBox.Show("Transaction is Available");
				}
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button11_Click(object sender, EventArgs e)
		{
			transaction = Ent.Transactions.Find(int.Parse(textBox16.Text));
			if (transaction != null)
			{
				if (textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "")
				{
					transaction.To_Warhouse = textBox17.Text;
					transaction.From_Warhouse = textBox18.Text;
					transaction.Supplier_Name = textBox19.Text;
					Ent.SaveChanges();
					textBox16.Text = textBox17.Text = textBox18.Text = textBox19.Text = "";
				}
				else
				{
					MessageBox.Show("No Type or Name Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available Transaction");
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			if (textBox24.Text != "" && textBox25.Text != "" && textBox26.Text != "" && textBox27.Text != "")
			{
				int pid = int.Parse(textBox24.Text);
				int prid = int.Parse(textBox25.Text);
				Permission_Product pp = (Ent.Permission_Product.
				Where(p => p.Permission_Id == pid  && p.Product_Id == prid).
				Select(p => p)).FirstOrDefault();

				if (pp == null)
				{
					permission_product.Product_Id = int.Parse(textBox25.Text);
					permission_product.Permission_Id = int.Parse(textBox24.Text);
					permission_product.Quantity = int.Parse(textBox27.Text);
					permission_product.Production_Date = DateTime.Parse(textBox26.Text);

					Ent.Permission_Product.Add(permission_product);
					Ent.SaveChanges();
					listBox9.Items.Add(textBox25.Text + "\t\t" + textBox24.Text + "\t\t" + textBox27.Text);
					textBox24.Text = textBox25.Text = textBox26.Text = textBox27.Text = "";
				}
				else
				{
					MessageBox.Show("Product Permission is Available");
				}

			}
			else
			{
				MessageBox.Show("Empty Data");
			}
			
		}

		private void button17_Click(object sender, EventArgs e)
		{
			int pid = int.Parse(textBox24.Text);
			int prid = int.Parse(textBox25.Text);
			permission_product = (Ent.Permission_Product.
			Where(p => p.Permission_Id == pid && p.Product_Id == prid).
			Select(p => p)).FirstOrDefault();
			if (permission_product != null)
			{
				if (textBox26.Text != "" && textBox27.Text != "")
				{
					permission_product.Quantity = int.Parse(textBox27.Text);
					permission_product.Production_Date = DateTime.Parse(textBox26.Text);
					Ent.SaveChanges();
					textBox24.Text = textBox25.Text = textBox26.Text = textBox27.Text = "";
				}
				else
				{
					MessageBox.Show("No Quantity or Time Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available Product Permission");
			}
		}

		
		private void button20_Click(object sender, EventArgs e)
		{
			if (textBox28.Text != "" && textBox29.Text != "" && textBox30.Text != "" && textBox31.Text != "")
			{
				int pid = int.Parse(textBox29.Text);
				int tid = int.Parse(textBox28.Text);
				Product_Transaction pt = (Ent.Product_Transaction.
				Where(p => p.Transaction_Id == tid && p.Product_Id == pid).
				Select(p => p)).FirstOrDefault();

				if (pt == null)
				{
					product_transaction.Product_Id = int.Parse(textBox29.Text);
					product_transaction.Transaction_Id = int.Parse(textBox28.Text);
					product_transaction.Quantity = int.Parse(textBox30.Text);
					product_transaction.Production_Date = DateTime.Parse(textBox31.Text);

					Ent.Product_Transaction.Add(product_transaction);
					Ent.SaveChanges();
					listBox10.Items.Add(textBox29.Text + "\t\t" + textBox28.Text + "\t\t" + textBox30.Text);
					textBox28.Text = textBox29.Text = textBox30.Text = textBox31.Text = "";
				}
				else
				{
					MessageBox.Show("Product Transaction is Available");
				}

			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button19_Click(object sender, EventArgs e)
		{
			int pid = int.Parse(textBox29.Text);
			int tid = int.Parse(textBox28.Text);
			product_transaction = (Ent.Product_Transaction.
			Where(p => p.Transaction_Id == tid && p.Product_Id == pid).
			Select(p => p)).FirstOrDefault();
			if (product_transaction != null)
			{
				if (textBox30.Text != "" && textBox31.Text != "")
				{
					product_transaction.Quantity = int.Parse(textBox30.Text);
					product_transaction.Production_Date = DateTime.Parse(textBox31.Text);
					Ent.SaveChanges();
					textBox28.Text = textBox29.Text = textBox30.Text = textBox31.Text = "";
				}
				else
				{
					MessageBox.Show("No Quantity or Time Available");
				}
			}
			else
			{
				MessageBox.Show("Not Available Product Transaction");
			}
		}
		private void button13_Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			listBox1.Items.Add("ID\tName");
			listBox1.Items.Add("-------------------------------------------------------------------------------");
			foreach (Product pt in Ent.Products)
			{
				listBox1.Items.Add(pt.Id + "\t" + pt.Name);
			}
		}

		private void button14_Click(object sender, EventArgs e)
		{
			listBox2.Items.Clear();

			listBox2.Items.Add("Name\t\tAddress\t\tManager");
			listBox2.Items.Add("-------------------------------------------------------------------------------");

			foreach (Warehouse w in Ent.Warehouses)
			{
				listBox2.Items.Add(w.Name + "\t" + w.Address + "\t\t" + w.Manager);
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			listBox3.Items.Clear();
			listBox3.Items.Add("Name\t\tMobile\t\tEmail");
			listBox3.Items.Add("-------------------------------------------------------------------------------");

			foreach (Supplier s in Ent.Suppliers)
			{
				listBox3.Items.Add(s.Name + "\t" + s.Mobile + "\t" + s.Email);
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			listBox4.Items.Clear();
			listBox4.Items.Add("Name\t\tMobile\t\tEmail");
			listBox4.Items.Add("-------------------------------------------------------------------------------");

			foreach (Client c in Ent.Clients)
			{
				listBox4.Items.Add(c.Client_Name + "\t" + c.Mobile + "\t" + c.Email);
			}
		}

		private void button21_Click(object sender, EventArgs e)
		{
			listBox5.Items.Clear();
			listBox9.Items.Clear();
			listBox5.Items.Add("ID\tType\tWareHouse Name\t\tSupplier Name");
			listBox5.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Permission pr in Ent.Permissions)
			{
				listBox5.Items.Add(pr.Id + "\t" + pr.Type + "\t" + pr.Warhouse_Name + "\t\t" + pr.Supplier_Name);
			}
			listBox9.Items.Add("Product ID\tPermission ID\tQuantity");
			listBox9.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Permission_Product pp in Ent.Permission_Product)
			{
				listBox9.Items.Add(pp.Product_Id + "\t\t" + pp.Permission_Id + "\t\t" + pp.Quantity);
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			listBox6.Items.Clear();
			listBox10.Items.Clear();
			listBox6.Items.Add("ID\tTo\t\tFrom\t\tSupplier Name");
			listBox6.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Transaction t in Ent.Transactions)
			{
				listBox6.Items.Add(t.Id + "\t" + t.To_Warhouse + "\t" + t.From_Warhouse + "\t" + t.Supplier_Name);
			}
			listBox10.Items.Add("Product ID\tTransaction ID\tQuantity");
			listBox10.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Product_Transaction pt in Ent.Product_Transaction)
			{
				listBox10.Items.Add(pt.Product_Id + "\t\t" + pt.Transaction_Id + "\t\t" + pt.Quantity);
			}
		}

		private void button23_Click(object sender, EventArgs e)
		{
			if (textBox20.Text != "")
			{
				listBox7.Items.Clear();
				warehouse = Ent.Warehouses.Find(textBox20.Text);
				if (warehouse != null)
				{
					listBox7.Items.Add("Name\t\tAddress\t\tManager\t\tProducts");
					listBox7.Items.Add("-----------------------------------------------------------------------------------------------------------");
					foreach(var item in warehouse.Products)
					listBox7.Items.Add(warehouse.Name + "\t" + warehouse.Address +
						"\t\t" + warehouse.Manager + "\t" + item.Name);
				
				}
					
				else 
				{
					MessageBox.Show("Wrong Data");

				}
				textBox20.Text = "";
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button24_Click(object sender, EventArgs e)
		{
			if (textBox21.Text != "")
			{
				listBox7.Items.Clear();
				product = Ent.Products.Find(int.Parse(textBox21.Text));
				if (product != null)
				{
					listBox7.Items.Add("Product ID\tProduct Name\t\tWarehouse Name\t\tClient Name");
					listBox7.Items.Add("--------------------------------------------------------------------------------------------------------");

					foreach (Warehouse w in product.Warehouses)
					{
						foreach (var item in product.Clients)
						{
							listBox7.Items.Add(product.Id + "\t\t" + product.Name + "\t\t\t" + w.Name + "\t\t" + item.Client_Name);
						}
					}
				}

				else
				{
					MessageBox.Show("Wrong Data");

				}
				textBox21.Text = "";
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button25_Click(object sender, EventArgs e)
		{
			listBox7.Items.Clear();
			listBox7.Items.Add("Product ID\tTransaction ID\tQuantity\tProduction Date");
			listBox7.Items.Add("--------------------------------------------------------------------------------------------------------");

			foreach (Product_Transaction pt in Ent.Product_Transaction)
			{
				listBox7.Items.Add(pt.Product_Id + "\t\t" + pt.Transaction_Id + "\t\t" + 
					pt.Quantity + "\t" + pt.Production_Date);
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			if (textBox22.Text != "")
			{
				listBox7.Items.Clear();
				int period = int.Parse(textBox22.Text);
				var pro = from p in Ent.Permission_Product select p;
				if (pro != null)
				{
					listBox7.Items.Add("Products ID");
					listBox7.Items.Add("-----------------------------------------------------------------------------------------------------------");
					foreach (var item in pro)
					{
						if (DateTime.Now.Subtract((DateTime)item.Production_Date).TotalDays <= period)
						{
							listBox7.Items.Add(item.Product_Id);
						}

					}
				}
				else
				{
					MessageBox.Show("Wrong Data");

				}
				textBox22.Text = "";
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}

		private void button27_Click(object sender, EventArgs e)
		{
			if (textBox23.Text != "")
			{
				listBox7.Items.Clear();
				int time = int.Parse(textBox23.Text);
				var pro = from p in Ent.Permission_Product select p;
				if (pro != null)
				{
					listBox7.Items.Add("Products ID");
					listBox7.Items.Add("--------------------------");
					foreach (var item in pro)
					{
						if (item.Production_Date.Value.Year+item.Expiration_Period-DateTime.Now.Year==time)
						{
							listBox7.Items.Add(item.Product_Id);
						}

					}
				}
				else
				{
					MessageBox.Show("Wrong Data");

				}
				textBox23.Text = "";
			}
			else
			{
				MessageBox.Show("Empty Data");
			}
		}
	}
}
