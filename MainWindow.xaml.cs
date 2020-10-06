using System;
using System.Windows;
using David_P1_AP1.UI.Registros;
using David_P1_AP1.UI.Consultas;
namespace David_P1_AP1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void rCiudad_Click(object render, RoutedEventArgs e){
            new rCiudad().Show();
        }

        public void cCiudad_Click(object render, RoutedEventArgs e){
            new cCiudad().Show();
        }

    }
}
