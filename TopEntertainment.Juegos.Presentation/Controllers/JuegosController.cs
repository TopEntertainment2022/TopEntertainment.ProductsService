using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;

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
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetJuegoById(int id)
        {
            try
            {
                var juegoEntity = _service.GetJuegoById(id);

                if(juegoEntity != null)
                {
                    return new JsonResult(juegoEntity) { StatusCode = 200};
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
