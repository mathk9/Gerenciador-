using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gerenciamento_Colmeia
{
    public partial class Form1 : Form
    {
        Queen queen;
        public Form1()
        {
            InitializeComponent();
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Coletar nécta", "Produção de mel" });
            workers[1] = new Worker(new string[] { "Cuidar dos ovos", "Ensinar às abelhas bebês" });
            workers[2] = new Worker(new string[] { "Manutenção da colméia", "Patrulha" });
            workers[3] = new Worker(new string[] { "Coletar nécta", "Produção de mel",
                "Cuidar dos ovos", "Ensinar às abelhas bebês", "Manutenção da colméia", "Patrulha"});

            queen = new Queen(workers);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (queen.AssignWork(comboBox1.Text, (int)numericUpDown1.Value) == false)
                MessageBox.Show("Não tem operárias disponiveis para o trabalho '"
                    + comboBox1.Text + "'", "A abelha rainha diz...");
            else
                MessageBox.Show("O trabalho '" + comboBox1.Text + "' irá ser feito "
                    + numericUpDown1.Value + " turnos", "A abelha rainha diz...");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = queen.WorkTheNextShift();
        }

    }
}
