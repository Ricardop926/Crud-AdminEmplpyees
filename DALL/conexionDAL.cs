using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AdminEmpleados.DALL
{
    internal class conexionDAL
    {
        private string cadenaConexion= "SERVER=DESKTOP-PP16DAK;DATABASE=dbSistema;integrated security=true;";
        SqlConnection conexion;

        public SqlConnection establecerConexion()
        {//este metodo se declara para poder conectarse a la base de datos 
            this.conexion = new SqlConnection(this.cadenaConexion);//se crea una conexion con sqlconecction y se le crea una intancia y se le asigna esa instancia al objeto this.conexion que se creo antes 
            return this.conexion; 

        }
        // método INSERT, DELETE. UPDATEno devuelve información, solo dice si se hizo ono alguna de las intrucciones 
        public bool ejecutarComandosSinRetornoDeDatos( string strComando) 
        {
            try
            {
                
                SqlCommand command = new SqlCommand();//para iniciar un comando en este caso una consulta// declarar comando
                command.CommandText = strComando;// aqui se crea el objeto a llamar o el comando//consulta a las base de datos
                command.Connection = this.establecerConexion();//para poder conectar //permite conectar//se reemplaxa por el meodo creado para poderse conectar a la base de datoss
                conexion.Open(); 
                command.ExecuteNonQuery();//ejecución de la sentencia
                conexion.Close();
                return true;//si todo sale bien dara un true sino pues en el catch tira el error

            }
            catch { return false; }

            

        }

        //sobrecarga 
        // método INSERT, DELETE. UPDATEno devuelve información, solo dice si se hizo ono alguna de las intrucciones // se le va a pasar un argumento diferente
        public bool ejecutarComandosSinRetornoDeDatos(SqlCommand Sqlcomando)
        {
            try
            {

                SqlCommand command = Sqlcomando;//para iniciar un comando en este caso una consulta// declarar comando
                /*command.CommandText = strComando;// aqui se crea el objeto a llamar o el comando//consulta a las base de datos //fue cambiado por el código anterior*/
                command.Connection = this.establecerConexion();//para poder conectar //permite conectar//se reemplaxa por el meodo creado para poderse conectar a la base de datoss
                conexion.Open();
                command.ExecuteNonQuery();//ejecución de la sentencia
                conexion.Close();
                return true;//si todo sale bien dara un true sino pues en el catch tira el error

            }
            catch { return false; }



        }


        /* Select retorno de datos */ // metodo para ejecutar las sentencias de tipo select 

        public DataSet ejecutarSentencia(SqlCommand sqlComando)
        {
            DataSet ds = new DataSet(); // ests ds es para adadptar toda la información 
            SqlDataAdapter adaptador = new SqlDataAdapter();  // creacion del adaptador   
            try
            {
                SqlCommand comando = new SqlCommand();
                comando = sqlComando;
                comando.Connection = establecerConexion();//utilizp el comando 
                adaptador.SelectCommand = comando;
                conexion.Open();
                adaptador.Fill(ds); /* se llena todo el adaptador */
                conexion.Close();
                return ds;
            }

            catch
            {

                return ds;
            }
        }


    }
}
