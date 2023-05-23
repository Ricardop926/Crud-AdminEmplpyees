using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleados.DALL;
using AdminEmpleados.BLL;

namespace AdminEmpleados.PL
{
    public partial class fmrDepartament : Form
    {
        DeparnamentDAL oDeparnamentDAL;//creacion de un objeto para una instancia
        public fmrDepartament()
        {
            oDeparnamentDAL = new DeparnamentDAL();//objeto aqui se está instanciasdo el objeto
            InitializeComponent();// interfax gráfica 
            llenarGrid(); // Este método se creo en departamentDAL PERMITE VER EN EL DATAGRID LA INFORMACION QUE SE LE AGREGA A LA BASE DE DATOS
            limpiarEntradas();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // instructions for collecting information
            // recuperar u obtener  infirmación
            //método 
            
           
            //MessageBox.Show("CONECTADO...");
            //clase DALL Deparnament... objeto que tiene la información de la gui
            oDeparnamentDAL.Add(Recoverinformation());
            llenarGrid();
            limpiarEntradas();
        }

        private DeparnamentBll Recoverinformation() {

            //esta clase me ayuda a definir la información que voy a leer en la interfaz gráfica - instacia
            DeparnamentBll oDeparnamentBLL = new DeparnamentBll();
            //se crea la variente para poder recoletar la vaariente del txtID

            int id_dep = 0; int.TryParse(txtID.Text, out id_dep);

            oDeparnamentBLL.id_dep = id_dep;
            // PARA UTILIXAR EL VALOR DE ESE TEXTBIX
            oDeparnamentBLL.deparnament = txtName.Text;

            return oDeparnamentBLL;




        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvDeparnament.ClearSelection();

            if (indice >= 0 )
            {
                txtID.Text = dgvDeparnament.Rows[indice].Cells[0].Value.ToString();// recuperar valor de la colomna
                txtName.Text = dgvDeparnament.Rows[indice].Cells[1].Value.ToString(); // se recupera el valor del indice y se buscan todas las filas y se recupera lo que está en la clomnba 1 y la columna 2// cuando se hace este procedimiento permite seleccionar los valores ya introduccidos y salen en los textbox


                // esto permite que cuando selecciones en el grid se actives todos los botones que estaban desactivados 
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnChange.Enabled = true;
                btnCancel.Enabled = true;

            }



           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            oDeparnamentDAL.Delete(Recoverinformation());
            llenarGrid();
            limpiarEntradas();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            oDeparnamentDAL.Change(Recoverinformation());
            
            llenarGrid();
            limpiarEntradas();
        }

        public void llenarGrid()//este nos permite llenar el grid con toda la información de la base datos, es una forma de simplificar el método
        {
            dgvDeparnament.DataSource = oDeparnamentDAL.MostrarDepartamentos().Tables[0];

            //le cambia el nombre a las columnas que ya estan estblecidas en la base de datos pero en el front sale con los siguiente nombres asignados
            dgvDeparnament.Columns[0].HeaderText = "clave";
            dgvDeparnament.Columns[1].HeaderText = "Nombre Departamento";


        }
        public void limpiarEntradas()
        {
            txtID.Text = "";
            txtName.Text = "";
            btnAdd.Enabled = true;
            btnDelete.Enabled = false;
            btnChange.Enabled = false;
            btnCancel.Enabled = false;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //al darle doble click al boton cancelar se activar el boton add
            limpiarEntradas();
        }

        private void fmrDepartament_Load(object sender, EventArgs e)
        {

        }
    }
}
