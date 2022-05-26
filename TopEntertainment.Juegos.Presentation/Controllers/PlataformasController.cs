using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.DTOS;


namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("Plataforma")]
    [ApiController]

    //Cuando la plataforma tenga juegos asociados avisar que no se puede eliminar
    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaService _service;

        public PlataformaController(IPlataformaService service)
        {
            _service = service;
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
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePlataforma(int id, [FromBody] PlataformaDTO plataforma)
        {
            try
            {
                if (plataforma == null)
                {
                    return BadRequest("Error en la información ingresada");
                }
                else
                {

                    if (_service.GetPlataformaById(id) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        _service.Update(id, plataforma);

                        return StatusCode(201, "Plataforma Actualizada");
                    }
                }
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePlataforma(int id)
        {
            try
            {
                if (_service.GetPlataformaById(id) == null) { return NotFound(); }
                else
                {
                    _service.Delete(id);
                    return StatusCode(200, "Plataforma Eliminada");
                }
            }
            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }



        [HttpGet]
        public IActionResult GetAllPlataformas()
        {
            try
            {
                return new JsonResult(_service.GetAllPlataformas()) { StatusCode = 200 };
            }

            catch (Exception) { return StatusCode(500, "Internal server error"); }
        }


        [HttpGet("{id}")]
        public IActionResult GetPlataformaById(int id)
        {
            try
            {
                var plataforma = _service.GetPlataformaById(id);

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