using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Quiz2WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            player = new Player();
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 1000;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            player.Experience += 100;
            progressBar1.Value += 100;
            if (player.Experience >= 1000)
            {
                player.Level += 1;
                player.Experience = 0;
                progressBar1.Value = 0;
            }
            textBox1.Text = "";
            textBox1.Text += "Level " + player.Level + " Exp " + player.Experience + "/1000";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string playerStats = JsonConvert.SerializeObject(player);
            var path = System.IO.Path.Combine(Environment.CurrentDirectory, "player.json");
            System.IO.File.WriteAllText(path, playerStats);
            var data = File.ReadAllText(path);
            var newstring = JsonConvert.DeserializeObject(data);
        }


    }
}
