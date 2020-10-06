using System;
using System.Windows;
using David_P1_AP1.DAL;
using David_P1_AP1.Entidades;
using David_P1_AP1.BLL;
using David_P1_AP1.UI;
using System.Collections.Generic;

namespace David_P1_AP1.UI.Consultas{
    public partial class cCiudad:Window{
       
        public cCiudad(){
            InitializeComponent();
        }

        public void ConsultarBoton_Click(object render, RoutedEventArgs e){
            var lista = new List<Ciudad>();
            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch(FiltroComboBox.SelectedIndex){
                    case 0:
                        lista = CiudadBLL.GetList(c => c.CiudadId == this.Convertir(CriterioTextBox.Text));
                        break;
                    case 1:
                        lista = CiudadBLL.GetList(c => c.Nombre == this.CriterioTextBox.Text);
                        break;
                    default:
                     MessageBox.Show("Error", "Fallo", MessageBoxButton.OK);
                        break;
                }
            }
            else
                lista = CiudadBLL.GetList(c => true);
            
            InfoDataGrid.ItemsSource = null;
            InfoDataGrid.ItemsSource = lista;
        }

        public int Convertir(string id){
            
            int retornar = 0;
            int.TryParse(id, out retornar);
            
            return retornar;
        }

    }
}