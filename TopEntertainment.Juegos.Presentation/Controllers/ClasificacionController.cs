﻿using Microsoft.AspNetCore.Mvc;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Application;
using TopEntertainment.Juegos.Application.Services;

namespace TopEntertainment.Juegos.Presentation.Controllers
{
    [Route("Clasificacion")]
    [ApiController]

    public class ClasificacionController : ControllerBase
    {
        private readonly IClasificacionService _service;
        private readonly IJuegosService _juegosService;

        public ClasificacionController(IClasificacionService service, IJuegosService juegosService)
        {
            _service = service;
            _juegosService = juegosService;
        }


        [HttpPost]
        public IActionResult CreateClasificacion([FromBody] ClasificacionDTO clasificacion)
        {
            try
            {
                if (clasificacion == null)
                {
                    return BadRequest();
                }
                else
                {
                    _service.Add(clasificacion);
                    return StatusCode(201);
                }
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateClasificacion(int id, [FromBody] ClasificacionDTO plataforma)
        {
            try
            {
                if (plataforma == null)
                {
                    return BadRequest();
                }
                else
                {

                    if (!_juegosService.ValidarClasificacion(id))
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
        public IActionResult DeleteClasificacion(int id)
        {
            try
            {
                if (!_juegosService.ValidarClasificacion(id)) { return NotFound(); }
                else
                {
                    if (_service.ClasificacionIsEmpty(id))
                    {
                        _service.Delete(id);
                        return StatusCode(200);
                    }
                    else return StatusCode(400, new RespuestaDTO("La Clasificacion no se puede eliminar "));
                }
            }

            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }



        [HttpGet]
        public IActionResult GetAllClasificacion()
        {
            try
            {
                return new JsonResult(_service.GetAllClasificacion()) { StatusCode = 200 };
            }

            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


        [HttpGet("{id}")]
        public IActionResult GetClasificacionById(int id)
        {
            try
            {
                if (_juegosService.ValidarClasificacion(id))
                {
                    var clasificacion = _service.GetClasificacionById(id);
                    return new JsonResult(clasificacion) { StatusCode = 200 };
                }
                else return NotFound();
            }
            catch (Exception e) { return StatusCode(500, new RespuestaDTO(e.Message)); }
        }


    }
}