using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Course
{
    public partial class Form1 : Form
    {
        private ExcelPackage _package;
        private ExcelWorksheet _worksheet;

        string fileRoute = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Ventas.xlsx"
        );

        ExcelPackage package = new ExcelPackage();


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
            AddItem(ventas.Product, ventas.Quantity, ventas.AssignPrice(), ventas.CalculateSubtotal(), ventas.CalculateDiscount(), ventas.CalculateNet());

            CleanFields();
        }

        private int GetLastRowWithData(ExcelWorksheet worksheet)
        {
            if (worksheet.Dimension != null)
            {
                return worksheet.Dimension.End.Row;
            }
            return 0;
        }

        private void AddItem(string product, int quantity, double price, double subtotal, double discount, double net)
        {
            if (_worksheet == null) return;

            _worksheet.View.ShowGridLines = false;
            _worksheet.Workbook.CalcMode = ExcelCalcMode.Manual;

            int row = _worksheet.Dimension?.End.Row + 1 ?? 2;
            _worksheet.Cells[row, 1].Value = product;
            _worksheet.Cells[row, 2].Value = quantity;
            _worksheet.Cells[row, 3].Value = price;
            _worksheet.Cells[row, 4].Value = subtotal;
            _worksheet.Cells[row, 5].Value = discount;
            _worksheet.Cells[row, 6].Value = net;

            string currencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
            _worksheet.Cells[row, 3].Style.Numberformat.Format = $"[${currencySymbol}]#,##0.00";
            _worksheet.Cells[row, 4].Style.Numberformat.Format = $"[${currencySymbol}]#,##0.00";
            _worksheet.Cells[row, 5].Style.Numberformat.Format = $"[${currencySymbol}]#,##0.00";
            _worksheet.Cells[row, 6].Style.Numberformat.Format = $"[${currencySymbol}]#,##0.00";

            int endRow = GetLastRowWithData(_worksheet);
            _worksheet.Cells[1, 3, endRow, 6].AutoFitColumns();
            _worksheet.Workbook.CalcMode = ExcelCalcMode.Automatic;
            _worksheet.View.ShowGridLines = true;
            _package.SaveAs(new FileInfo(fileRoute));
        }


        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            register_listbox.Items.Clear();
            if (!File.Exists(fileRoute))
            {
                _package = new ExcelPackage();
                _worksheet = _package.Workbook.Worksheets.Add("Ventas");
                _worksheet.Cells[1, 1].Value = "Producto";
                _worksheet.Cells[1, 2].Value = "Cantidad";
                _worksheet.Cells[1, 3].Value = "Precio";
                _worksheet.Cells[1, 4].Value = "Subtotal";
                _worksheet.Cells[1, 5].Value = "Descuento";
                _worksheet.Cells[1, 6].Value = "Neto";

                _package.SaveAs(new FileInfo(fileRoute));
            } 
            else
            {
                _package = new ExcelPackage(new FileInfo(fileRoute));
                _worksheet = _package.Workbook.Worksheets[0];

                int rowCount = _worksheet.Dimension.End.Row;
                int columnCount = _worksheet.Dimension.End.Column;
                for (int row = 2; row <= rowCount; row++)
                {
                    ListViewItem item = new ListViewItem(_worksheet.Cells[row, 1].Text);
                    for (int column = 2; column <= columnCount; column++)
                    {
                        item.SubItems.Add(_worksheet.Cells[row, column].Text);
                    }
                    register_listbox.Items.Add(item);
                }
            }
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
