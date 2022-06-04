using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;


namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("Plataforma")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {

 
        private readonly IPlataformaService _service;

        public PlataformaController(IPlataformaService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAllPlataformas()
        {
            try
            {
                return new JsonResult(_service.GetAllPlataformas()) { StatusCode = 200 };
            }

            catch (Exception){return StatusCode(500, "Internal server error");}
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

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }



        [HttpPost]
        public IActionResult CreatePlataforma([FromBody] PlataformaDTO plataforma)
        {
            try
            {
                _service.Add(plataforma);
                return StatusCode(201, "Plataforma creado correctamente");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
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

                var plataformaEntity = _service.GetPlataformaById(id);

                if (plataformaEntity == null)
                {
                    return NotFound();
                }

                _service.Update(id, plataforma);

                return StatusCode(200, "Plataforma Actualizada");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePlataforma(int id)
        {
            try
            {
                var plataformaEntity = _service.GetPlataformaById(id);
                if (plataformaEntity.Juegos.Count == 0) { return BadRequest(); }
                else 
                { 
                _service.Delete(id);
                return StatusCode(200, "Plataforma Eliminada");
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }




    }

}