using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Projekt_PP
{
    public partial class Form2 : Form
    {
        public Form2(List<double> liczby2)
        {
            InitializeComponent();
            
            for (int i = 0; i < liczby2.Count(); i++)
               this.chart1.Series["Próbki"].Points.AddXY(i, liczby2[i]);
            for (int i = 1; i < liczby2.Count(); i++)
                this.chart1.Series["Różnice"].Points.AddXY(i, liczby2[i] - liczby2[i - 1]);
            chart1.Series["Próbki"].BorderWidth = 3;
            chart1.Series["Różnice"].BorderWidth = 3;
            chart1.Series["Różnice"].Color = Color.Pink;
            chart1.Series["Próbki"].Color = Color.Red;
            chart1.Titles.Add("Temperatura");
           // chart1.Series["Próbki"].Font = new Font(FontFamily.GenericSansSerif, 50);
           // chart1.ChartAreas["ChartArea1"].BackColor = Color.DarkTurquoise;
           
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineColor = Color.Azure;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.LineColor = Color.LawnGreen;
            comboBox1.Items.Add("Czerwony");
            comboBox1.Items.Add("Zielony");
            comboBox1.Items.Add("Żółty");
            comboBox1.Items.Add("Niebieski");

            comboBox2.Items.Add("Różowy");
            comboBox2.Items.Add("Czarny");
            comboBox2.Items.Add("Brązowy");
            comboBox2.Items.Add("Fioletowy");

            comboBox3.Items.Add("Biały");
            comboBox3.Items.Add("Czarny");
            comboBox3.Items.Add("Srebrny");
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Czerwony")
            {
                chart1.Series["Próbki"].Color = Color.Red;
            }
            if (comboBox1.SelectedItem.ToString() == "Zielony")
            {
                chart1.Series["Próbki"].Color = Color.Green;
            }
            if (comboBox1.SelectedItem.ToString() == "Żółty")
            {
                chart1.Series["Próbki"].Color = Color.Yellow;
            }
            if (comboBox1.SelectedItem.ToString() == "Niebieski")
            {
                chart1.Series["Próbki"].Color = Color.Blue;
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedItem.ToString() == "Różowy")
            {
                chart1.Series["Różnice"].Color = Color.Pink;
            }
            if (comboBox2.SelectedItem.ToString() == "Czarny")
            {
                chart1.Series["Różnice"].Color = Color.Black;
            }
            if (comboBox2.SelectedItem.ToString() == "Brązowy")
            {
                chart1.Series["Różnice"].Color = Color.Brown;
            }
            if (comboBox2.SelectedItem.ToString() == "Fioletowy")
            {
                chart1.Series["Różnice"].Color = Color.Purple;
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chart1.Titles.Clear();
            }
            else
            {
                chart1.Titles.Add("Temperatura");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                chart1.Series["Próbki"].IsVisibleInLegend = false;
                chart1.Series["Różnice"].IsVisibleInLegend = false;
            }
            else
            {
                chart1.Series["Próbki"].IsVisibleInLegend = true;
                chart1.Series["Różnice"].IsVisibleInLegend = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem.ToString() == "Biały")
            {
                chart1.ChartAreas["ChartArea1"].BackColor = Color.White;
            }
            if (comboBox3.SelectedItem.ToString() == "Czarny")
            {
                chart1.ChartAreas["ChartArea1"].BackColor = Color.Black;
            }
            if (comboBox3.SelectedItem.ToString() == "Srebrny")
            {
                chart1.ChartAreas["ChartArea1"].BackColor = Color.Silver;
            }
        }
    }
}
