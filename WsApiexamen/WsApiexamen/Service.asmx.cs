using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WsApiexamen.Models;
using System.Web.Script.Services;

namespace WsApiexamen
{
    /// <summary>
    /// Descripción breve de Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        Context db = new Context();
        
      

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public Response AgregarExamen(string Nombre, string Descripcion)
        {
            Response response = new Response(); 

            tblExamen examen = new tblExamen();
            examen.Nombre = Nombre;
            examen.Descripcion = Descripcion;
            db.tblExamen.Add(examen);

            try
            {
                if (db.SaveChanges() > 0)
                {
                    db.SaveChanges();
                    response.message = "Operación realizada con exito";
                    response.success = true;
                }
            }
            catch(Exception ex) {
                response.message = ex.Message;
                response.success = false;
            }


            return response;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public Response ActualizarExamen(int Id,string Nombre, string Descripcion)
        {
            Response response = new Response();


            var examen = db.tblExamen.Find(Id);
            examen.Nombre = Nombre;
            examen.Descripcion = Descripcion;
            db.Entry(examen).State = System.Data.Entity.EntityState.Modified;

            try
            {
                if (db.SaveChanges() > 0)
                {
                    db.SaveChanges();
                    response.message = "Operación realizada con exito";
                    response.success = true;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }


            return response;
        }


        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public Response EliminarExamen(int Id)
        {
            Response response = new Response();

            var examen = db.tblExamen.Find(Id);         
            db.tblExamen.Remove(examen);

            try
            {
                if (db.SaveChanges() > 0)
                {
                    db.SaveChanges();
                    response.message = "Operación realizada con exito";
                    response.success = true;
                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }


            return response;
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public List<tblExamen> ConsultarExamen()
        {

            var examen = new List<tblExamen>();

            try
            {
                examen = db.tblExamen.ToList();
            }
            catch (Exception ex)
            {
              
            }


            return examen;
        }
    }
}
