using System;
using System.Linq;
using System.Linq.Expressions;
using David_P1_AP1;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using David_P1_AP1.DAL;
using David_P1_AP1.Entidades;

namespace David_P1_AP1.BLL{
    public class CiudadBLL{
        public static bool Guardar(Ciudad ciudad){
            if(!Existe(ciudad.CiudadId))
                return Insertar(ciudad);
            else 
                return Modificar(ciudad);
        }

        public static bool Insertar(Ciudad ciudad){
            bool paso = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Ciudad.Add(ciudad);
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Ciudad ciudad){
            bool paso = false;
            Contexto contexto = new Contexto();
            try{
                contexto.Entry(ciudad).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id){
            bool paso = false;
            Contexto contexto = new Contexto();
            try{
                var ciudad = contexto.Ciudad.Find(id);
                if(ciudad != null){
                    contexto.Ciudad.Remove(ciudad);
                    paso = contexto.SaveChanges() > 0;     
                }
                
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return paso;
        }

        public static Ciudad Buscar(int id){
            Ciudad ciudad;
            Contexto contexto = new Contexto();

            try{
                ciudad = contexto.Ciudad.Find(id);
                
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return ciudad;
        }

        public static bool Existe(int id){
            bool encontrado = false;
            Contexto contexto = new Contexto();
            try{
                encontrado = contexto.Ciudad.Any(c => c.CiudadId == id);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return encontrado;
        }

        public static bool Existe(string nombre){
            bool encontrado = false;
            Contexto contexto = new Contexto();
            try{
                encontrado = contexto.Ciudad.Any(c => c.Nombre == nombre);
            }
            catch(Exception){
                throw;
            }
            finally{
                contexto.Dispose();
            }
            return encontrado;
        }


        
    }
}