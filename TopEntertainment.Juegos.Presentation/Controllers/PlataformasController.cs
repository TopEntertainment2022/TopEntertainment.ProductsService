using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;


namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("plataforma")]
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



        //Crear y usar plataformaDTO
        [HttpPost]
        [ProducesResponseType(typeof(Plataforma), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreatePlataforma([FromBody] Plataforma plataforma)
        {
            try
            {
                _service.Add(plataforma);
                return StatusCode(200, "Juego creado correctamente");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult UpdatePlataforma(int id, [FromBody] Plataforma plataforma)
        //{
        //    //try
        //    //{
        //    //    if (juego == null)
        //    //    {
        //    //        return BadRequest("Error en la información ingresada");
        //    //    }

        //    //    var juegoEntity = _service.GetJuegoById(id);

        //    //    if (juegoEntity == null)
        //    //    {
        //    //        return NotFound();
        //    //    }

        //    //    _service.Update(id, juego);

        //    //    return NoContent();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return StatusCode(500, "Internal server error");
        //    //}
        //}


        //[HttpPut("delete/{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public IActionResult DeletePlataforma(int id)
        //{
        //    //try
        //    //{
        //    //    _service.Delete(id);
        //    //    return NoContent();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return StatusCode(500, "Internal server error");
        //    //}
        //}




    }

}