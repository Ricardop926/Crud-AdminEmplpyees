using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using AdminEmpleados.BLL;
using System.Windows.Forms;

namespace AdminEmpleados.DALL
{
    internal class DeparnamentDAL
    {

        conexionDAL conexion;
        public DeparnamentDAL()
        {
            conexion = new conexionDAL();
        }
        public bool Add(DeparnamentBll oDeparnamentBLL)

        {
            SqlCommand Sqlcomando = new SqlCommand("INSERT INTO Deparnament VALUES (@deparnament)");
            Sqlcomando.Parameters.Add("@deparnament", SqlDbType.VarChar).Value = oDeparnamentBLL.deparnament;// aquí con el SqlDbType.VarChar se valida la informacion,2 utilizamos un parametro que es @departament 3 estamso igualiando el valor que proviene del Value = oDeparnamentBLL.deparnament con este oDeparnamentBLL que es el parametro del método 
            return conexion.ejecutarComandosSinRetornoDeDatos(Sqlcomando);


          // return conexion.ejecutarComandosSinRetornoDeDatos(" INSERT INTO Deparnament (deparnament) VALUES ('"+ oDeparnamentBLL.deparnament + "')");

        }
        public bool Delete(DeparnamentBll oDeparnamentBLL)//vale recordar qeu lo qeu va dentro de este metodo es el obejto creado en 
        {
            SqlCommand Sqlcomando = new SqlCommand("DELETE FROM Deparnament WHERE id_dep=@id_dep ");
            Sqlcomando.Parameters.Add("@id_dep", SqlDbType.Int).Value = oDeparnamentBLL.id_dep;
            return conexion.ejecutarComandosSinRetornoDeDatos(Sqlcomando);


            //conexion.ejecutarComandosSinRetornoDeDatos(" DELETE  FROM Deparnament  WHERE Id_dep="+ oDeparnamentBLL.id_dep);
           // return 1; // va a determinar si se efectuo la operación o no se efectuo la operación

        }
        public bool Change(DeparnamentBll oDeparnamentBLL)//vale recordar qeu lo qeu va dentro de este metodo es el obejto creado en 
        {

            SqlCommand Sqlcomando = new SqlCommand("UPDATE  Deparnament SET deparnament= @deparnament WHERE id_dep=@id_dep ");
            Sqlcomando.Parameters.Add("@deparnament", SqlDbType.VarChar).Value = oDeparnamentBLL.deparnament;
            Sqlcomando.Parameters.Add("@id_dep", SqlDbType.Int).Value = oDeparnamentBLL.id_dep;
            return conexion.ejecutarComandosSinRetornoDeDatos(Sqlcomando);
            // conexion.ejecutarComandosSinRetornoDeDatos(" UPDATE  Deparnament SET deparnament='" +oDeparnamentBLL.deparnament+"'  WHERE Id_dep=" + oDeparnamentBLL.id_dep);
            // return 1; // va a determinar si se efectuo la operación o no se efectuo la operación

        }


        public DataSet MostrarDepartamentos()//metodos
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Deparnament");
            return conexion.ejecutarSentencia(sentencia);

           

        }

    }
}
