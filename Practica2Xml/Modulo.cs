using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2Xml
{
    class Modulo
    {
        public int modulo { get; set; }
        public String codigo { get; set; }
        public int horas { get; set; }
        public String nombreModulo { get; set; }

        public Modulo()
        {

        }

        public Modulo(int modulo, String codigo, int horas, String nombreModulo)
        {
            this.modulo = modulo;
            this.codigo = codigo;
            this.horas = horas;
            this.nombreModulo = nombreModulo;
        }
    }
}
