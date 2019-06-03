using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Practica2Xml
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObtenerDatos();
        }

        Datos d = new Datos();

        private void ObtenerDatos()
        {
            if(File.Exists("Faltas_CS14001_2.xml"))
            {
                d.DatosXml("Faltas_CS14001_2.xml");
            }
            if (File.Exists("modulos.txt"))
            {
                d.ObtenerModulos("modulos.txt");
            }
        }

        private void botonGestionarAlumnos_Click(object sender, RoutedEventArgs e)
        {
            gridInicial.Visibility = Visibility.Hidden;
            gridGestionarAlumnos.Visibility = Visibility.Visible;
            try
            {
                dataGridAlumnos.Items.Refresh();
                dataGridAlumnos.ItemsSource = d.f.datosAlumnos.listaAlumnos;
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void botonAgregarAlumno_Click(object sender, RoutedEventArgs e)
        {
            gridGestionarAlumnos.Visibility = Visibility.Hidden;
            gridAgregarAlumno.Visibility = Visibility.Visible;
        }

        private void botonVolver_Click(object sender, RoutedEventArgs e)
        {
            gridAgregarAlumno.Visibility = Visibility.Hidden;
            gridGestionarAlumnos.Visibility = Visibility.Visible;
            try
            {
                dataGridAlumnos.Items.Refresh();
                dataGridAlumnos.ItemsSource = d.f.datosAlumnos.listaAlumnos;
                if (File.Exists("Faltas_CS14001_2.xml"))
                {
                    d.SerializarAlumnos("Faltas_CS14001_2.xml");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void botonVolverInicio_Click(object sender, RoutedEventArgs e)
        {
            gridGestionarAlumnos.Visibility = Visibility.Hidden;
            gridInicial.Visibility = Visibility.Visible;
        }

        private void botonAgregar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = textBoxNombre.Text;
            String id = textBoxId.Text;
            String email = textBoxEmail.Text;

            d.AgragarAlumno(id, email, nombre);

            textBoxId.Text = "";
            textBoxNombre.Text = "";
            textBoxEmail.Text = "";
        }

        private void botonEliminarAlumno_Click(object sender, RoutedEventArgs e)
        {
            Alumno alumno = dataGridAlumnos.SelectedItem as Alumno;

            for (int i = 0; i < d.f.datosAlumnos.listaAlumnos.Count; i++)
            {
                if(alumno== d.f.datosAlumnos.listaAlumnos[i])
                {
                    d.f.datosAlumnos.listaAlumnos.RemoveAt(i);
                }
            }
            dataGridAlumnos.Items.Refresh();

            if (File.Exists("Faltas_CS14001_2.xml"))
            {
                d.SerializarAlumnos("Faltas_CS14001_2.xml");
            }
        }

        private void botonResumenFaltas_Click(object sender, RoutedEventArgs e)
        {
            gridInicial.Visibility = Visibility.Hidden;
            gridResumenFaltas.Visibility = Visibility.Visible;
            IniciarComboModulos();
        }

        private void IniciarComboModulos()
        {
            comboModulos.ItemsSource = d.m.Select(c => c.codigo);
        }

        String cod;

        private void comboModulos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //volvemos por a 0 as horas faltadas despois de mostrar para que non se acumulen
            foreach (ResumenFaltas r in d.srf.rf)
            {
                r.sumHorasFaltadas = 0;
                r.porcFaltas = 0;
            }

            cod = comboModulos.SelectedItem.ToString();

            //int horasTotales = d.m.Where(c => c.codigo.Equals(cod)).Select(c => c.horas);
            int horasTotales=CalcularHorasTotales(cod);
            int numeroModul = ObtenerNumeroModulo(cod);

            for(int i = 0; i < d.f.listaDatosFaltas.Count; i++)
            {
                for(int j = 0; j < d.f.listaDatosFaltas[i].listaFechas.Count; j++)
                {
                    for(int q = 0; q < d.f.listaDatosFaltas[i].listaFechas[j].listaFaltas.Count; q++)
                    {
                        if (d.f.listaDatosFaltas[i].listaFechas[j].listaFaltas[q].modulo == numeroModul)
                        {
                            //collemos as faltas que correspondan ao numero de modulo que se seleccionou
                            int idAlumno = d.f.listaDatosFaltas[i].listaFechas[j].listaFaltas[q].IdAlumno;
                            foreach(ResumenFaltas r in d.srf.rf)
                            {
                                if (r.idAl == idAlumno)
                                {
                                    r.sumHorasFaltadas++;
                                }
                            }
                        }
                    }
                }
            }

            //calculamos o porcentaxe de faltas para o modulo para cada alumno
            foreach(ResumenFaltas r in d.srf.rf)
            {
                double sumh = Convert.ToDouble(r.sumHorasFaltadas);
                double porc = sumh / horasTotales * 100;
                r.porcFaltas = porc;
            }

            dataGridResumenFaltas.Items.Refresh();
            dataGridResumenFaltas.ItemsSource = d.srf.rf;

            
        }

        private int ObtenerNumeroModulo(String cod)
        {
            int numeroModulo = 0;

            foreach(Modulo mod in d.m)
            {
                if (mod.codigo.Equals(cod))
                {
                    numeroModulo = mod.modulo;
                }
            }

            return numeroModulo;
        }

        private int CalcularHorasTotales(String cod)
        {
            int horasTot=0;

            foreach (Modulo mod in d.m)
            {
                if (mod.codigo.Equals(cod))
                {
                    horasTot = mod.horas;
                }
            }

            return horasTot;
        }

        private void botonSerializarResultado_Click(object sender, RoutedEventArgs e)
        {
            if(comboModulos.SelectedItem!=null)
                d.SerializarResumen(cod);
        }

        private void botonVolvIni_Click(object sender, RoutedEventArgs e)
        {
            gridResumenFaltas.Visibility = Visibility.Hidden;
            gridInicial.Visibility = Visibility.Visible;
        }
    }
}
