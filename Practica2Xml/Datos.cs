using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Practica2Xml
{
    [XmlRoot("InformeFaltas")]
    class Datos
    {

        public Datos()
        {

        }

        public ClaseFaltas f = new ClaseFaltas();
        public List<Modulo> m = new List<Modulo>();
        


        public SerializarResumenFaltas srf = new SerializarResumenFaltas();

        public void DatosXml(String nombreFichero)
        {
            //obxecto para deserializar xml
            XmlSerializer deserializar = new XmlSerializer(typeof(ClaseFaltas));
            //lemos o fichero xml
            TextReader reader = new StreamReader(nombreFichero,Encoding.Default);
            //creamos a variable do tipo que vamos a deserializar
            f = deserializar.Deserialize(reader) as ClaseFaltas;
            //cerramos o reader para que non nos digan que esta en uso
            reader.Close();
            InicializarRF();
        }

        private void InicializarRF()
        {
            foreach(Alumno cf in f.datosAlumnos.listaAlumnos)
            {
                srf.rf.Add(new ResumenFaltas(cf.id, cf.nombre, cf.email));
            }
        }

        public void SerializarAlumnos(String nombreFichero)
        {
            XmlSerializer serializar = new XmlSerializer(typeof(ClaseFaltas));
            TextWriter writer = new StreamWriter(nombreFichero, false, Encoding.Default);
            serializar.Serialize(writer, f);
            writer.Close();
        }

        public void AgragarAlumno(String id,String email,String nombre)
        {
            try
            {
                int i = Convert.ToInt32(id);
                ComprobarDuplicidad(i, email, nombre);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

        private void ComprobarDuplicidad(int i,String email,String nombre)
        {
            bool añadir = true;

            foreach(Alumno a in f.datosAlumnos.listaAlumnos)
            {
                if(a.id==i || a.nombre.Equals(nombre) || a.email.Equals(email))
                {
                    añadir = false;
                }
            }

            if (añadir == true)
            {
                f.datosAlumnos.listaAlumnos.Add(new Alumno(i, email, nombre));
            }
        }

        public void ObtenerModulos(String nombreFichero)
        {
            TextReader reader = new StreamReader(nombreFichero, Encoding.Default);
            while (reader.Peek() > -1)
            {
                String[] linea = reader.ReadLine().Split('\t');
                int mod = Convert.ToInt32(linea[0]);
                int hor = Convert.ToInt32(linea[2]);
                m.Add(new Modulo(mod, linea[1], hor, linea[3]));
            }
            reader.Close();
        }

        public void SerializarResumen(String cod)
        {
            XmlSerializer serializar = new XmlSerializer(typeof(SerializarResumenFaltas));
            TextWriter writer = new StreamWriter("ResumenFaltas"+cod+".xml");
            serializar.Serialize(writer, srf);
            writer.Close();
        }

    }
}
