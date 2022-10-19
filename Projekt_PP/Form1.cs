using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Documents;
namespace Projekt_PP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        double srednia = 0, wariacja = 0, min = 0, max = 0;
        List<double> liczby2;
        
        private void buttonotworz_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Prosze podać scieżke do pliku tekstowego z liczbami zakończonymi ';' ", "Informacja!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OpenFileDialog Nowy = new OpenFileDialog();
                Nowy.Title = "Wybierz plik";
                Nowy.Filter = "txt files (*.txt)|*.txt";
                if (Nowy.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBox1.Text = File.ReadAllText(Nowy.FileName);
                    string[] liczby = File.ReadAllText(Nowy.FileName).Split(';');
                    liczby2 = new List<double>();
                    for (int i =0; i < liczby.Length; i++)
                    {
                        if (double.TryParse(liczby[i], out _))
                            liczby2.Add(Convert.ToDouble(liczby[i]));
                    }
                    srednia = (liczby2.Sum() / liczby2.Count);
                    textBox3.Text = srednia.ToString();
                    max = Double.MinValue;
                    min = Double.MaxValue;
                    for (int i = 0; i < liczby2.Count; i++)
                    {
                        if (liczby2[i] < min)
                            min = liczby2[i];
                        if (liczby2[i] > max)
                            max = liczby2[i];
                    }
                    textBox5.Text = min.ToString();
                    textBox2.Text = max.ToString();
                    button1.Enabled = true;
                    button2.Enabled = true;
                wariacja = 0;
                    for (int i = 0; i < liczby2.Count; i++ )
                    {
                        wariacja = (wariacja + Math.Pow((liczby2[i] - srednia), 2) / liczby2.Count);
                    }


                    textBox4.Text = Math.Round(wariacja, 6).ToString();
                    MessageBox.Show("Wczytano dane!");
                }
            else
            {
                MessageBox.Show("Błędny format pliku!", "BŁĄD!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                if (min == double.MaxValue)
            {
                MessageBox.Show("Najprawdopodobniej wpisano złe dane!", "BŁĄD!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Wykres = new Form2(liczby2);
            Wykres.ShowDialog();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SaveFileDialog zapisz = new SaveFileDialog();
            zapisz.Filter = "txt files (*.txt)|*.txt";
            if (zapisz.ShowDialog() == DialogResult.OK)
            {
                string Zawartość = "Wartość średnia: " + srednia + @"
" +
                                   "Wartość minimalna: " + min + @"
" +
                                   "Wartość Maksymalna: " + max + @"
" +
                                   "Wariacja: " + wariacja;
                File.WriteAllText(zapisz.FileName, Zawartość);
                
            } 

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
