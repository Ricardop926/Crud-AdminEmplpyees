using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminEmpleados.PL;


namespace AdminEmpleados
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new fmrDepartament());  se inicia con este pero integrar ya no se necesita
            Application.Run(new fmrEmployees()); //con el fin que cuando demos click en iniciar, de forma automática se muestre la interfaz de empleados
        }
    }
}
