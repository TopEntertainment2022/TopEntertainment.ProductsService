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
        public IActionResult CreateJuego([FromBody] JuegoDTO2 juego)
        {
            try
            {
                if (juego == null || !_service.ValidarPlataforma(juego.PlataformaId) || !_service.ValidarClasificacion(juego.ClasificacionId) || !_service.ValidarCategorias(juego.Categorias))
                {
                    return StatusCode(400, new RespuestaDTO("La plataforma, clasificacion y/o categoria/s ingresadas no existen "));
                }
                else
                {
                    _service.Add(juego);
                    return StatusCode(201);
                }
            }
            catch (Exception e) { return StatusCode(500, e.Message); }
        }



        [HttpPut("{id}")]
        public IActionResult UpdateJuego(int id, [FromBody] JuegoDTO2 juego)
        {
            try
            {
                if (!_service.ValidarJuego(id)) return NotFound();

                if (juego == null || !_service.ValidarPlataforma(juego.PlataformaId) || !_service.ValidarClasificacion(juego.ClasificacionId) || !_service.ValidarCategorias(juego.Categorias))
                {
                    return StatusCode(400, new RespuestaDTO("La plataforma, clasificacion y/o categoria/s ingresadas no existen "));
                }
                else
                {

                    _service.Update(id, juego);

                    return StatusCode(201);
                }
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteJuego(int id)
        {
            try
            {
                if (!_service.ValidarJuego(id)) return NotFound();

                _service.Delete(id);
                return StatusCode(200);
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpGet]
        public IActionResult GetAllJuegos(int? categoria = null, int? clasificacion = null, int? plataforma = null, string? descripcion = null)
        {
            try
            {
                return new JsonResult(_service.GetAllJuegos(categoria, clasificacion,plataforma,descripcion)) { StatusCode = 200 };
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpGet("{id}")]
        public IActionResult GetJuegoById(int id)
        {
            try
            {
                if (!_service.ValidarJuego(id)) return NotFound();

                var juego = _service.GetJuegoById(id);
                return new JsonResult(juego) { StatusCode = 200 };
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }

        [HttpGet("plataforma/{id}")]
        public IActionResult GetJuegosByPlataformaId(int id)
        {

            try
            {
                if (!_service.ValidarPlataforma(id)) return StatusCode(404, new RespuestaDTO("La plataforma ingresada no existe "));

                else return new JsonResult(_service.GetJuegosByPlataformaId(id)) { StatusCode = 200 };
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }

        [HttpGet("categoria/{id}")]
        public IActionResult GetJuegosByCategoriaId(int id)
        {
            try
            {
                if (!_service.ValidarCategoria(id)) return StatusCode(404, new RespuestaDTO("La categoria ingresada no existe "));
                return new JsonResult(_service.GetJuegosByCategoriaId(id)) { StatusCode = 200 };
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }

        [HttpGet("clasificacion/{id}")]
        public IActionResult GetJuegosByClasificacionId(int id)
        {
            try
            {
                if (!_service.ValidarClasificacion(id)) return StatusCode(404, new RespuestaDTO("La clasificacion ingresada no existe "));
                return new JsonResult(_service.GetJuegosByClasificacionId(id)) { StatusCode = 200 };
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


    }

}
