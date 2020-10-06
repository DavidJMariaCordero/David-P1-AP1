using System;
using System.Windows;
using David_P1_AP1.DAL;
using David_P1_AP1.Entidades;
using David_P1_AP1.BLL;
using David_P1_AP1.UI;

namespace David_P1_AP1.UI.Registros{
    public partial class rCiudad:Window{
       
        private Ciudad ciudad;
        public rCiudad(){
            InitializeComponent();
            ciudad = new Ciudad();
            this.DataContext = ciudad;
        }

        public void GuardarBoton_CLick(object render, RoutedEventArgs e){
            if(!Validar())
                return;
            var paso = CiudadBLL.Guardar(ciudad);
            if(paso){
                Limpiar();
                MessageBox.Show("Guardado con exito", "Bien", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Error al guardar", "Error", MessageBoxButton.OK);
            }

        }

        public void Limpiar(){
            this.ciudad = new Ciudad();
            this.DataContext = ciudad;

        }

        public void BuscarBoton_CLick(object render, RoutedEventArgs e){
            Contexto contexto = new Contexto();
            var encontrado = CiudadBLL.Buscar(Convert.ToInt32(CiudadIdTextBox.Text));
            if(encontrado != null)
                this.ciudad = encontrado;
            else{
                this.ciudad = new Ciudad();
                MessageBox.Show("No encontrado", "Error", MessageBoxButton.OK);
            }

            this.DataContext = this.ciudad;
        }

        private bool Validar(){
            bool valido = true;
            if(NombreTextBox.Text.Length == 0){
                valido = false;
                MessageBox.Show("Debe incluir el nombre", "Error", MessageBoxButton.OK);
            }
            else if(CiudadBLL.Existe(NombreTextBox.Text)){
                valido = false;
                MessageBox.Show("Esta ciudad ya esta registrada", "Error", MessageBoxButton.OK);
            }
            return valido;
        }

        public void NuevoBoton_CLick(object render, RoutedEventArgs e){
            Limpiar();
        }

        public void EliminarBoton_CLick(object render, RoutedEventArgs e){
            if(CiudadBLL.Eliminar(Convert.ToInt32(CiudadIdTextBox.Text))){
                Limpiar();
                MessageBox.Show("Eliminado", "Exito", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Error al eliminar", "Error", MessageBoxButton.OK);
            }
        }

    }
}