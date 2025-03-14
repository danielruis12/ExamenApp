using ExamenApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ExamenApp.Clases
{
    public class clsCliente
    {
        private DBExamenAppEntities dbExamenApp = new DBExamenAppEntities(); // Es el atributo/propiedad para gestionar la conexión a la base de datos.
        public Cliente cliente { get; set; } // Propiedad para manipular la información en la base de datos: Permite agregar, modificar o eliminar.
        public string Insertar()
        {
            try
            {
                dbExamenApp.Clientes.Add(cliente); // Agregar el objeto cliente a la lista de "Clientes". Todavía no se agrega a la base de datos. Se debe invocar el método SaveChanges().
                dbExamenApp.SaveChanges(); // Guardar los cambios en la base de datos.
                return "Cliente insertado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al insertar el cliente: " + ex.Message;
            }
        }
        public string Actualizar()
        { 
            try
            {

                Cliente clie = Consultar(cliente.Documento);
                if (clie == null)
                {
                    return "El cliente con el documento ingresado no se encuentra, no se puede actualizar";
                }
                dbExamenApp.Clientes.AddOrUpdate(cliente); // //Actualiza el objeto cliente en la lista "Clientes". Todavía no se actualiza en la base de datos. Se debe invocar el método SaveChanges().
                dbExamenApp.SaveChanges(); // Guardar los cambios en la base de datos.
                return "Cliente actualizado correctamente";
            }
            catch (Exception ex)
            {
                return "Error al actualizar el cliente: " + ex.Message;
            }
        }
        public Cliente Consultar(string Documento)
        {
            return dbExamenApp.Clientes.FirstOrDefault(c => c.Documento == Documento);
        }
        public List<Cliente> ConsultarTodos()
        {
            return dbExamenApp.Clientes.OrderBy(c => c.PrimerApellido).ToList();
        }
        public string Eliminar()
        {
            try
            {
                //Antes de eliminar, se debe verificar si el cliente existe
                Cliente clie = Consultar(cliente.Documento);
                if (clie == null)
                {
                    return "El cliente con el documento ingresado no se encuentra, no puede eliminarse";
                }
                //El cliente existe, puede eliminarse. Se elimina el objeto cliente que se busca, no el que se envía como parámetro.
                dbExamenApp.Clientes.Remove(clie); //Eliminar el objeto cliente de la lista de "Clientes". Todavía no se elimina de la base de datos. Se debe invocar el método SaveChanges().
                dbExamenApp.SaveChanges(); //Guardar los cambios en la base de datos
                return "Se eliminó el cliente correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el cliente: " + ex.Message;
            }
        }
    }
}