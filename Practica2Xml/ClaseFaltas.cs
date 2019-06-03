using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Practica2Xml
{
    [XmlRoot("Faltas")]
    public class ClaseFaltas
    {
        [XmlElement("DatosAlumnos")]
        public DatosAlumnos datosAlumnos { get; set; }
        [XmlElement("DatosFaltas")]
        public List<DatosFaltas> listaDatosFaltas = new List<DatosFaltas>();

        public ClaseFaltas()
        {

        }
    }

    public class DatosFaltas
    {
        [XmlAttribute]
        public String mes { get; set; }
        [XmlAttribute]
        public String curso { get; set; }
        [XmlElement("Fecha")]
        public List<Fecha> listaFechas = new List<Fecha>();

        public DatosFaltas()
        {

        }
    }

    public class Fecha
    {
        [XmlAttribute]
        public String valor { get; set; }
        [XmlElement("Falta")]
        public List<Falta> listaFaltas = new List<Falta>();

        public Fecha()
        {

        }
    }

    public class Falta
    {
        [XmlAttribute]
        public int IdAlumno { get; set; }
        [XmlAttribute]
        public String hora { get; set; }
        [XmlAttribute]
        public int modulo { get; set; }

        public Falta()
        {

        }

        public Falta(int idAlumno, string hora, int modulo)
        {
            IdAlumno = idAlumno;
            this.hora = hora;
            this.modulo = modulo;
        }
    }

    public class DatosAlumnos
    {
        [XmlElement("Alumno")]
        public List<Alumno> listaAlumnos = new List<Alumno>();

        public DatosAlumnos()
        {

        }
    }

    public class Alumno
    {
    
        [XmlAttribute]
        public int id { get; set; }
        [XmlAttribute]
        public String email { get; set; }
        [XmlText]
        public String nombre { get; set; }


        public Alumno()
        {

        }

        public Alumno(int id,String email,String nombre)
        {
            this.id = id;
            this.email = email;
            this.nombre = nombre;
        }
    }
}
