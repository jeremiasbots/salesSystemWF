using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Course
{
    public partial class Form1 : Form
    {
        static string[] products = {"Teclado", "Celular", "Reloj", "Cuatro"};

        Ventas ventas = new Ventas();

        double total;

        public Form1()
        {
            InitializeComponent();
        }

        private void client_label_Click(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ventas.Product = product_combo_box.Text;
            ventas.Quantity = int.Parse(quantity_text_box.Text);

            ListViewItem row = new ListViewItem(ventas.Product);
            row.SubItems.Add(ventas.Quantity.ToString());
            row.SubItems.Add(ventas.AssignPrice().ToString("C"));
            row.SubItems.Add(ventas.CalculateSubtotal().ToString("C"));
            row.SubItems.Add(ventas.CalculateDiscount().ToString("C"));
            row.SubItems.Add(ventas.CalculateNet().ToString("C"));
            
            register_listbox.Items.Add(row);
            total += ventas.CalculateNet();
            quantity_net_total_label.Text = total.ToString("C");

            CleanFields();
        }


        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModifyDate();
            ModifyHour();
            FillProducts();
            quantity_net_total_label.Text = "0.00";
            CleanFields();
        }

        private void ModifyDate()
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
        }

        private void ModifyHour()
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void CleanFields()
        {
            client_textbox.Clear();
            product_combo_box.Text = "Seleccione un producto";
            lblPrecio.Text = "0.00";
            quantity_text_box.Clear();
            client_textbox.Focus();
        }

        private void FillProducts()
        {
            foreach (var product in products)
            {
                product_combo_box.Items.Add(product);
            }
        }

        private void price_label_Click(object sender, EventArgs e)
        {

        }

        private void lblPrecio_Click(object sender, EventArgs e)
        {
           
        }

        private void cancelar_button_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estás seguro de que deseas salir?", "Salida del programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                this.Close();
            } 
            else 
            {
                CleanFields();
            }
        }

        private void product_combo_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            ventas.Product = product_combo_box.Text;
            lblPrecio.Text = ventas.AssignPrice().ToString("C");
        }
    }
}
