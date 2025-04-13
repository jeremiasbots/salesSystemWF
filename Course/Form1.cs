using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using OfficeOpenXml;

namespace Course
{
    public partial class Form1 : Form
    {
        private ExcelPackage _package;
        private ExcelWorksheet _worksheet;

        private string fileRoute = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            "Ventas.xlsx"
        );

        private static string[] products = {"Teclado", "Celular", "Reloj", "Cuatro"};

        private Ventas ventas = new Ventas();

        private double _total;

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
            if (IsFileBlocked(fileRoute))
            {
                MessageBox.Show("El archivo está en uso por otro programa (como Excel). Ciérralo antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string selectedProduct = product_combo_box.Text;
            if (!products.Contains(selectedProduct))
            {
                MessageBox.Show("Tienes que seleccionar un producto válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ventas.Product = product_combo_box.Text;
            try
            {
                ventas.Quantity = int.Parse(quantity_text_box.Text);
            } 
            catch
            {
                MessageBox.Show("Tienes que poner una cantidad válida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ListViewItem row = new ListViewItem(ventas.Product);
            row.SubItems.Add(ventas.Quantity.ToString());
            row.SubItems.Add(ventas.AssignPrice().ToString("C"));
            row.SubItems.Add(ventas.CalculateSubtotal().ToString("C"));
            row.SubItems.Add(ventas.CalculateDiscount().ToString("C"));
            row.SubItems.Add(ventas.CalculateNet().ToString("C"));
            register_listbox.Items.Add(row);
            _total += ventas.CalculateNet();
            quantity_net_total_label.Text = _total.ToString("C");
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

        private static decimal ParseCurrencyString(string value)
        {
            value = value.Trim();

            // 1. Intenta detectar el símbolo de moneda de cualquier cultura
            foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                string symbol = culture.NumberFormat.CurrencySymbol;
                if (value.Contains(symbol))
                {
                    try
                    {
                        decimal result = decimal.Parse(value, NumberStyles.Currency, culture);
                        return result;
                    }
                    catch (FormatException)
                    {
                        // Continuar si falla con esta cultura
                    }
                }
            }

            // 2. Limpia caracteres no numéricos (excepto dígitos, puntos, comas y signos)
            string cleanValue = Regex.Replace(value, @"[^\d.,-]", "");

            // 3. Intenta parsear con culturas comunes
            if (decimal.TryParse(cleanValue, NumberStyles.Any, new CultureInfo("es-ES"), out decimal resultEs))
            {
                return resultEs; // Ej: "190,00" → 190.00
            }
            else if (decimal.TryParse(cleanValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal resultInv))
            {
                return resultInv; // Ej: "190.00" → 190.00
            }

            throw new FormatException($"No se pudo parsear el valor: {value}");
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
                decimal totalExcel = 0;
                for (int row = 2; row <= rowCount; row++)
                {
                    ListViewItem item = new ListViewItem(_worksheet.Cells[row, 1].Text);
                    for (int column = 2; column <= columnCount; column++)
                    {
                        item.SubItems.Add(_worksheet.Cells[row, column].Text);
                        if (column == _worksheet.Dimension.End.Column)
                        {
                            string netValue = _worksheet.Cells[row, column].Text;
                            totalExcel += ParseCurrencyString(netValue);
                        }
                    }
                    register_listbox.Items.Add(item);
                }
                _total += decimal.ToDouble(totalExcel);
                string currencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                quantity_net_total_label.Text = $"{currencySymbol}{_total}";
            }
            FillProducts();
            CleanFields();
        }

        private void CleanFields()
        {
            product_combo_box.Text = "Seleccione un producto";
            lblPrecio.Text = "0.00";
            quantity_text_box.Clear();
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

        private void delete_button_Click(object sender, EventArgs e)
        {
            if (register_listbox.SelectedItems.Count > 0)
            {
                if (IsFileBlocked(fileRoute))
                {
                    MessageBox.Show("El archivo está en uso por otro programa (como Excel). Ciérralo antes de continuar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                foreach (ListViewItem item in register_listbox.SelectedItems)
                {
                    _worksheet.DeleteRow(item.Index + 2);
                    _package.SaveAs(new FileInfo(fileRoute));
                    register_listbox.Items.Remove(item);
                    decimal parsedText = ParseCurrencyString(item.SubItems[5].Text);
                    _total -= decimal.ToDouble(parsedText);
                    string currencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
                    quantity_net_total_label.Text = $"{currencySymbol}{_total}";
                }
            }
            else
            {
                MessageBox.Show("Selecciona las filas a eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsFileBlocked(string path)
        {
            try
            {
                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    return false;
                }
            }
            catch (IOException)
            {
                return true;
            }
        }
    }
}
