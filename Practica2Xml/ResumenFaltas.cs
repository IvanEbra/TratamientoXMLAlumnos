using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Practica2Xml
{
    public class ResumenFaltas
    {
        public int idAl { get; set; }
        public String nombre { get; set; }
        public String email { get; set; }
        public int sumHorasFaltadas { get; set; }
        public double porcFaltas { get; set; }

        public ResumenFaltas()
        {

        }

        public ResumenFaltas(int idAl, String nombre,String email)
        {
            this.idAl = idAl;
            this.nombre = nombre;
            this.email = email;
        }
    }
}
