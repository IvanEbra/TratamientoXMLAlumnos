using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Practica2Xml
{
    [XmlRoot("InformeFaltas")]
    public class SerializarResumenFaltas
    {
        [XmlElement("Alumno")]
        public List<ResumenFaltas> rf = new List<ResumenFaltas>();

        public SerializarResumenFaltas()
        {

        }
    }
}
