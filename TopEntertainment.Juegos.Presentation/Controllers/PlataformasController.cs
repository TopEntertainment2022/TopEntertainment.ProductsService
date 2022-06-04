using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.DTOS;


namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("Plataforma")]
    [ApiController]

    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaService _service;
        private readonly IJuegosService _juegosService;

        public PlataformaController(IPlataformaService service, IJuegosService juegosService)
        {
            _service = service;
            _juegosService = juegosService;
        }


        [HttpPost]
        public IActionResult CreatePlataforma([FromBody] PlataformaDTO plataforma)
        {
            try
            {
                if (plataforma == null)
                {
                    return BadRequest();
                }
                else
                {
                    _service.Add(plataforma);
                    return StatusCode(201);
                }
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePlataforma(int id, [FromBody] PlataformaDTO plataforma)
        {
            try
            {
                if (plataforma == null)
                {
                    return BadRequest();
                }
                else
                {

                    if (!_juegosService.ValidarPlataforma(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        _service.Update(id, plataforma);

                        return StatusCode(201);
                    }
                }
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePlataforma(int id)
        {
            try
            {
                if (!_juegosService.ValidarPlataforma(id)) { return NotFound(); }
                else
                {
                    if (_service.PlataformaIsEmpty(id))
                    {
                        _service.Delete(id);
                        return StatusCode(200);
                    }
                    else return StatusCode(400, new RespuestaDTO("La plataforma no se puede eliminar porque tiene juegos asociados"));
                }
            }

            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }



        [HttpGet]
        public IActionResult GetAllPlataformas()
        {
            try
            {
                return new JsonResult(_service.GetAllPlataformas()) { StatusCode = 200 };
            }

            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpGet("{id}")]
        public IActionResult GetPlataformaById(int id)
        {
            try
            {
                if (_juegosService.ValidarPlataforma(id))
                {
                    var plataforma = _service.GetPlataformaById(id);
                    return new JsonResult(plataforma) { StatusCode = 200 };
                }
                else return NotFound();
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


    }

}