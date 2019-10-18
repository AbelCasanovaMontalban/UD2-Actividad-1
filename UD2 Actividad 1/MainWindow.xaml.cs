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

namespace UD2_Actividad_1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> caracteres;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void IniciarButton_Click(object sender, RoutedEventArgs e)
        {
            CrearListaCaracteres(6);
            if (BajaRadioButton.IsChecked==true)
            {

                GenerarCasillas(4, 3);
            }

            if (MediaRadioButton.IsChecked == true)
            {

                GenerarCasillas(4, 4);
            }

            if (AltoRadioButton.IsChecked == true)
            {
                GenerarCasillas(4, 5);
            }
        }

        private void GenerarCasillas(int columnas,int filas)
        {
            contenedorParejas_Grid.RowDefinitions.Clear();
            contenedorParejas_Grid.ColumnDefinitions.Clear();
            contenedorParejas_Grid.Children.Clear();
            Random rnd = new Random();

            for (int i = 0; i < columnas; i++)
            {
                ColumnDefinition columna = new ColumnDefinition();
                contenedorParejas_Grid.ColumnDefinitions.Add(columna);
            }

            for (int j = 0; j < filas; j++)
            {
                RowDefinition fila= new RowDefinition();
                contenedorParejas_Grid.RowDefinitions.Add(fila);
            }

            for (int i = 0; i < columnas; i++)
            {
                for (int j = 0; j < filas; j++)
                {
                    int numero = rnd.Next(0, caracteres.Count);
                    Viewbox v = new Viewbox();
                    TextBlock t = new TextBlock();
                    v.Child = t;
                    v.SetValue(Grid.RowProperty, i);
                    v.SetValue(Grid.ColumnProperty, j);
                    t.FontFamily = new FontFamily("Webdings");
                    t.Text = caracteres[numero];
                    caracteres.RemoveAt(numero);
                    contenedorParejas_Grid.Children.Add(v);
                }
            }

        }

        private void CrearListaCaracteres(int numeroParejas)
        {
            List<string> caracteresAleatorios = new List<string>();

            // 64 a 125
            Random rnd = new Random();
            for (int i = 0; i < numeroParejas;)
            {
                int numero = rnd.Next(64, 126);
                string caracter = Convert.ToChar(numero).ToString();
                if (!caracteresAleatorios.Contains(caracter))
                {
                    caracteresAleatorios.Add(caracter);
                    caracteresAleatorios.Add(caracter);
                    i++;
                }
            }

            caracteres = caracteresAleatorios;
        }

    }
}
