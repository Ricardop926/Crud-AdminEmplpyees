using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminEmpleados.BLL
{
    internal class EmployeesBll
    {

        public int Id { get; set; }
        public string Names { get; set; }
        public string Surname { get; set; }
        public string secondLastName { get; set; }
        public string deparnament { get; set; }
        public string e_mail { get; set; }
        public byte[] photo { get; set; }
    }
}
