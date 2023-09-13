using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace API_García_Hernández
{
    public partial class Form1 : Form
    {
        HttpClient client = new HttpClient();
        static Raza raza;
        static Dato dato;
        int c;
        public Form1()
        {
            InitializeComponent();
            client.BaseAddress = new Uri("https://catfact.ninja/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
           
            string id = textBox1.Text;
            bool isNumeric = int.TryParse(id, out _);
            if(isNumeric==true)
            { 
            int ido = Convert.ToInt32(id);
            if(ido>0 && ido<5)
            {
                HttpResponseMessage response = await client.GetAsync("breeds?page=" + id);

                if (response.IsSuccessStatusCode && c<25 && c>=0)
                {
                    raza = await response.Content.ReadFromJsonAsync<Raza>();
                    this.listBox1.Items.Clear();
                    this.listBox2.Items.Clear();
                    this.listBox3.Items.Clear();
                    this.listBox4.Items.Clear();
                    this.listBox5.Items.Clear();

                    this.listBox1.Items.Add(raza.data[c].breed);
                    this.listBox2.Items.Add(raza.data[c].country);
                    this.listBox3.Items.Add(raza.data[c].origin);
                    this.listBox4.Items.Add(raza.data[c].coat);
                    this.listBox5.Items.Add(raza.data[c].pattern);
                }
            }
            else
            {
               MessageBox.Show("Id inválido");
            }
            }
            else
            {
                MessageBox.Show("Id inválido");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (c < 25)
            {
                c++;
                button1_Click(sender, e);
            }
            else
            {
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (c > 1)
            {
        c--;button1_Click(sender, e);
            }
            else
            {
                
            }
          
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = await client.GetAsync("/fact");

            if (response.IsSuccessStatusCode)
            {
                dato = await response.Content.ReadFromJsonAsync<Dato>();
             this.listBox6.Items.Clear();
            this.listBox6.Items.Add(dato.fact);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
