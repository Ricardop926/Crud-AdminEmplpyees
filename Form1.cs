using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleados.PL;

namespace AdminEmpleados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//permite abrir la otra pantalla del crud, el cual ingresa los departamentos cuadno se da click
        {
            fmrDepartament formularioDeparnament = new fmrDepartament();
            formularioDeparnament.Show();
        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            fmrEmployees formularioEmployees = new fmrEmployees();
            formularioEmployees.Show();
        }
    }
}
