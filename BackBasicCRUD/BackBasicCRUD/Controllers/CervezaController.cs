using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// App
using BackBasicCRUD.Models.Response;
using BackBasicCRUD.Models;
using BackBasicCRUD.Models.Request;

namespace BackBasicCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervezaController : ControllerBase
    {
        // GET: api/<CervezaController>
        [HttpGet]
        public IActionResult ListarCervezas()
        {
            Respuesta oRta = new();
            try
            {
                using (BasicCrudContext db = new())
                {
                    var lst = db.Cervezas.ToList();
                    oRta.Exito = 1;
                    oRta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRta.Mensaje = ex.Message;
            }
            return Ok(oRta);
        }

        // GET: api/<CervezaController>/2
        [HttpGet("{id}")]
        public IActionResult ListarCerveza(int id)
        {
            Respuesta oRta = new();
            try
            {
                using (BasicCrudContext db = new())
                {
                    Cerveza oCerveza = db.Cervezas.Find(id);
                    if (oCerveza == null)
                    {
                        oRta.Exito = 0;
                        oRta.Mensaje = "No existe el elemento";
                    }
                    else
                    {
                        oRta.Exito = 1;
                        oRta.Data = oCerveza;
                    }
                }
            }
            catch (Exception ex)
            {
                oRta.Mensaje = ex.Message;
            }
            return Ok(oRta);
        } 

        // POST: api/<CervezaController>
        [HttpPost]
        public IActionResult CrearCerveza(CervezaRequest model)
        {
            Respuesta oRta = new();
            try
            {
                using (BasicCrudContext db = new())
                {
                    Cerveza oCerveza = new();
                    oCerveza.Nombre = model.Nombre;
                    oCerveza.Marca = model.Marca;
                    db.Cervezas.Add(oCerveza);
                    db.SaveChanges();
                    oRta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRta.Mensaje = ex.Message;
            }
            return Ok(oRta);
        }

        // PUT: api/<CervezaController>
        [HttpPut]
        public IActionResult EditarCerveza(CervezaRequest model)
        {
            Respuesta oRta = new();
            try
            {
                using (BasicCrudContext db = new())
                {
                    Cerveza oCerveza = db.Cervezas.Find(model.Id);
                    oCerveza.Nombre = model.Nombre;
                    oCerveza.Marca = model.Marca;
                    db.Entry(oCerveza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oRta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRta.Mensaje = ex.Message;
            }
            return Ok(oRta);
        }

        // DELETE: api/<CervezaController>/2
        [HttpDelete("{id}")]
        public IActionResult EliminarCerveza(int id)
        {
            Respuesta oRta = new();
            try
            {
                using (BasicCrudContext db = new BasicCrudContext())
                {
                    Cerveza oCerveza = db.Cervezas.Find(id);
                    db.Remove(oCerveza);
                    db.SaveChanges();
                    oRta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRta.Mensaje = ex.Message;
            }
            return Ok(oRta);
        }
    }
}
