using ExamenApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace ExamenApp.Clases
{
	public class clsComputador
	{
        private DBExamenAppEntities dbExamenApp = new DBExamenAppEntities(); // Es el atributo (propiedad) para gestionar la conexión a la base de datos.
        public Computador computador { get; set; } // Propiedad para manipular la información en la base de datos. Esta permite agregar, modificar o eliminar.
        public string Insertar()
        {
            try
            {
                dbExamenApp.Computadors.Add(computador); // Agregar el objeto computador a la lista de "Computadors". Todavía no se agrega a la base de datos. Se debe invocar el método SaveChanges().
                dbExamenApp.SaveChanges(); // Guardar los cambios en la base de datos.
                return "Computador insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el computador: " + ex.Message;
            }
        }
        public string Actualizar ()
        {
            try
            {
                Computador comp = Consultar(computador.ComputadorID);
                if (comp == null)
                {
                    return "El computador con el ID ingresado no se encuentra, no se puede actualizar";
                }
                dbExamenApp.Computadors.AddOrUpdate(computador);
                dbExamenApp.SaveChanges();
                return "Computador actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el computador: " + ex.Message;
            }
        }
        public Computador Consultar(int ComputadorID)
        {
            return dbExamenApp.Computadors.FirstOrDefault(pc => pc.ComputadorID == ComputadorID);
        }
        public List<Computador> ConsultarTodos()
        {
            return dbExamenApp.Computadors.OrderBy(pc => pc.MarcaProcesador).ToList();
        }
        public string Eliminar()
        {
            try
            {
                Computador comp = Consultar(computador.ComputadorID);
                if (comp == null)
                {
                    return "El computador con el ID ingresado no se encuentra, no se puede eliminar";
                }
                dbExamenApp.Computadors.Remove(comp);
                dbExamenApp.SaveChanges();
                return "Computador eliminado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al eliminar el computador: " + ex.Message;
            }
        }
    }
}