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
using AdminEmpleados.DALL;
using AdminEmpleados.BLL;
using System.Drawing.Text;

namespace AdminEmpleados.PL
{
    public partial class fmrEmployees : Form
    {
        byte[] imagenByte; //para pasar la información directamente a la base de datos
        public fmrEmployees()
        {
            InitializeComponent();
        }

        private void fmrEmployees_Load(object sender, EventArgs e)
        {
            DeparnamentDAL objDeparnament = new DeparnamentDAL();
            cbxDeparnament.DataSource = objDeparnament.MostrarDepartamentos().Tables[0];//con datasourde le paseo directamente la fuente de doden viene la información; muestra la columna
            cbxDeparnament.DisplayMember = "deparnament";//con esto aparece lo que esta en esa tabla
            cbxDeparnament.ValueMember = "id_dep";//igualar con el id el valor de ese departamento

        }

        private void btnExamine_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();   // para seleccionar la imagen // abre una caja de dialogo
            selectorImagen.Title = "Seleccionar imagen";
            if (selectorImagen.ShowDialog() == DialogResult.OK)//ES VALIDANDO SI EL USUARIO SELCCIONO EL BOTON OK, PERO CMO YA CREAMOS UN SELECTOR, ENTONCES DECIR SI ESA FOTOGRAFÍA FUE SELECCIONADA 
            {
                picFoto.Image = Image.FromStream(selectorImagen.OpenFile());//se agarra toda la información y se almacena en el picFoto //pasa la fotografia directamente a lo que es el picto luego de dar ok
                MemoryStream memoria = new MemoryStream();// memoria para poder alamacenarlo y mandarlo a la base de datos //esta memoria creada sirce para guardar toda la información  binaria en la basde de datos
                picFoto.Image.Save(memoria,System.Drawing.Imaging.ImageFormat.Png);//para convertir esa imagen o despositar en la memoria en fotmato png

                imagenByte = memoria.ToArray();// igualar a la memoria a todo el arreglo que maneja la memoria// este arreglo es para depositar 
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
           
        {
            recoletarDatos();
        }
        private void recoletarDatos()
        {
            EmployeesBll objEmployees =  new EmployeesBll(); // aqui se llama la clase EmployeesBll

            int codigoEmployee = 1;// MODOFICANDO LO QEU ES LA VARIABLE 
            int.TryParse(txtID.Text, out codigoEmployee);//si encutra algo en este caso txtid, lo va a tomar como referencia  pero sino el out .. hace que quede con el numero 1

            // aqui lo que se hara es depositar toda la infirmación en en el objeto objEmployee
            objEmployees.Id = codigoEmployee;
            objEmployees.Names = txtName.Text;
            objEmployees.Surname = txtSurname.Text;
            objEmployees.secondLastName = txtSecondLastName.Text;
            objEmployees.e_mail = txtEmail.Text;

            int idDeparnament = 0;
            int.TryParse(cbxDeparnament.SelectedValue.ToString() , out idDeparnament); // buscar la información que este en la infor cbxDepartamento si lo encuntra lo coloca sino pone el valro que viene por default//aqui se esta indentificando si existe un valor, si el usuario selecciono el drop down y le piso una opcion y se agarra ese valor y se deposita en la variable idDeparnament//
            //objEmployees.deparnament = idDeparnament;

            objEmployees.photo = imagenByte;


        }

        private void cbxDeparnament_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
