using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.DTOS;


namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("juegos")]
    [ApiController]
    public class JuegosController : ControllerBase
    {
        private readonly IJuegosService _service;
        private readonly IPlataformaService _servicePlataforma;

        public JuegosController(IJuegosService service, IPlataformaService servicePlataforma)
        {
            _service = service;
            _servicePlataforma = servicePlataforma;
        }


        [HttpPost]

        //Validar categorias, clasificacion
        //getById = mostrar eliminados?
        //segurizar add/update/delete
        //revisar codigos de respuestas y json results
        //agregar imagenes
        public IActionResult CreateJuego([FromBody] JuegoDTO2 juego)
        {
            try
            {
                if (juego == null || _servicePlataforma.GetPlataformaById(juego.PlataformaId) == null)
                {
                    return BadRequest();
                }
                else
                {
                    _service.Add(juego);
                    return StatusCode(201);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }



        [HttpPut("{id}")]
        public IActionResult UpdateJuego(int id, [FromBody] JuegoDTO2 juego)
        {
            try
            {
                if (juego == null || _servicePlataforma.GetPlataformaById(juego.PlataformaId) == null)
                {
                    return BadRequest("Error en la información ingresada");
                }
                else
                {

                    if (_service.GetJuegoById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _service.Update(id, juego);

                        return StatusCode(201);
                    }
                }
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteJuego(int id)
        {
            try
            {
                if (_service.GetJuegoById(id) == null) { return NotFound(); }
                else
                {
                    _service.Delete(id);
                    return StatusCode(200);
                }
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
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
                var plataforma = _service.GetJuegoById(id);

                if (plataforma != null)
                {
                    return new JsonResult(plataforma) { StatusCode = 200 };
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


    }

}
