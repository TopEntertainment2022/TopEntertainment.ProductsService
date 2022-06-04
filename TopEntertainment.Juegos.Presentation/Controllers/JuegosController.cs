using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("juegos")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        private readonly IJuegosService _service;

        public JuegosController(IJuegosService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAllJuegos()
        {
            try
            {
                return new JsonResult(_service.GetAllJuegos()) { StatusCode = 200 };
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpGet("{id}")]
        public IActionResult GetJuegoById(int id)
        {
            try
            {
                var juegoEntity = _service.GetJuegoById(id);

                if (juegoEntity != null)
                {
                    return new JsonResult(juegoEntity) { StatusCode = 200 };
                }

                return NotFound();
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpGet("name/{name}")]
        public IActionResult GetJuegoByName(string name)
        {
            try
            {
                var juegoEntity = _service.GetJuegoByName(name);

                if (juegoEntity != null)
                {
                    return new JsonResult(juegoEntity) { StatusCode = 200 };
                }

                return NotFound();
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpPost]
        public IActionResult CreateJuego([FromBody]JuegoDTO juego)
        {
            try
            {
                 _service.Add(juego);
                return StatusCode(200, "Juego creado correctamente");
            }

            catch (Exception e) { return BadRequest(e.Message);}

        }



        [HttpPut("{id}")]
        public IActionResult UpdateJuego(int id, [FromBody] JuegoDTO juego)
        {
            try
            {
                if (juego == null)
                {
                    return BadRequest("Error en la información ingresada");
                }

                var juegoEntity = _service.GetJuegoById(id);

                if (juegoEntity == null)
                {
                    return NotFound();
                }

                _service.Update(id,juego);

                return StatusCode(200, "Juego Actualizado");
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpDelete("delete/{id}")]
        public IActionResult DeleteJuego(int id)
        {
            try
            {
                    _service.Delete(id);
                    return StatusCode(200, "Juego Eliminado");
            }
            catch (Exception){ return StatusCode(500, "Internal server error");}
        }




    }

}
