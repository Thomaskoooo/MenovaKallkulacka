using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace penizkyMenic
{
    public partial class Form1 : Form
    {

        


        private readonly Dictionary<string, decimal> exchangeRates = new Dictionary<string, decimal>
        {
            { "EUR", 1.0m },
            { "CZK", 25.0m },
            { "HUF", 360.0m }
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            comboBox1.Items.AddRange(new string[] { "EUR", "CZK", "HUF" });
            comboBox2.Items.AddRange(new string[] { "EUR", "CZK", "HUF" });

            comboBox1.SelectedIndex = 0; 
            comboBox2.SelectedIndex = 1;   




        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Vyberte prosim menu.");
                return;
            }

            if (!decimal.TryParse(textBox1.Text, out decimal amount))
            {
                MessageBox.Show("Zadejte platnou částku.");
                return;
            }

            string fromCurrency = comboBox1.SelectedItem.ToString();
            string toCurrency = comboBox2.SelectedItem.ToString();



            
            decimal result = ConvertCurrency(amount, fromCurrency, toCurrency);

          
            textBox2.Text = $"{amount} {fromCurrency} = {result:F2} {toCurrency}";

        }

        private decimal ConvertCurrency(decimal amount, string fromCurrency, string toCurrency)
        {
            decimal fromRate = exchangeRates[fromCurrency];
            decimal toRate = exchangeRates[toCurrency];
            return amount * toRate / fromRate;
        }


    }
}
