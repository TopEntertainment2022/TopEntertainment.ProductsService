using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Application.Services;
using TopEntertainment.Juegos.Domain.DTOS;

namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("Categoria")]
    [ApiController]

    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;

        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }



        [HttpGet]
        public IActionResult GetAllCategorias()
        {
            try
            {
                return new JsonResult(_service.GetAllCategorias()) { StatusCode = 200 };
            }

            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


    }
}
