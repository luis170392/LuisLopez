using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WsApiexamen.Models;
namespace WsApiexamen
{
    public class clsExamen
    {
        Context db = new Context();
        public Response AgregarExamen(string tipo, tblExamen examen)
        {
            Response response = new Response();
       
            try
            {
                if (tipo == "ws")
                {
                    Service servivce = new Service();
                    response =  servivce.AgregarExamen(examen.Nombre, examen.Descripcion);

                    response.message = "Operación realizada con exito";
                    response.success = true;
                    
                }
                if(tipo == "sp")
                {
                    var lects = db.Database.SqlQuery<tblExamen>(
                    "spAgregar @Nombre, @Descripcion",
                    new SqlParameter("@Nombre", examen.Nombre),
                    new SqlParameter("@Descripcion", examen.Descripcion));
              
                }
            }
            catch(Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        public List<tblExamen> ConsultarExamen(string tipo, string Nombre, string Descripcion)
        {
            List<tblExamen> list = new List<tblExamen>();
            try
            {
                if (tipo == "ws")
                {
                    Service servivce = new Service();

                    list = servivce.ConsultarExamen();

                }
                if (tipo == "sp")
                {
                    var lects = db.Database.SqlQuery<tblExamen>(
                    "spConsultar @Nombre, @Descripcion",
                    new SqlParameter("@Nombre", Nombre),
                    new SqlParameter("@Descripcion",Descripcion));

                }
            }
            catch (Exception ex)
            {
               
            }

            return list;
        }


        public Response ActualizarExamen(string tipo, tblExamen examen)
        {
            Response response = new Response();

            try
            {
                if (tipo == "ws")
                {
                    Service servivce = new Service();
                    response = servivce.ActualizarExamen( examen.idExamen,examen.Nombre, examen.Descripcion);

                    response.message = "Operación realizada con exito";
                    response.success = true;
                    
                }
                if (tipo == "sp")
                {
                    var lects = db.Database.SqlQuery<tblExamen>(
                    "spActualizar  @Nombre, @Descripcion",
                    new SqlParameter("@Nombre", examen.Nombre),
                    new SqlParameter("@Descripcion", examen.Descripcion));

                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

        public Response EliminarExamen(string tipo, int id)
        {
            Response response = new Response();

            try
            {
                if (tipo == "ws")
                {
                    Service servivce = new Service();
                    response = servivce.EliminarExamen(id);

                    response.message = "Operación realizada con exito";
                    response.success = true;

                }
                if (tipo == "sp")
                {
                    var lects = db.Database.SqlQuery<tblExamen>(
                    "spEliminar  @idExamen",
                    new SqlParameter("@idExamen", id));

                }
            }
            catch (Exception ex)
            {
                response.message = ex.Message;
                response.success = false;
            }

            return response;
        }

    }
}