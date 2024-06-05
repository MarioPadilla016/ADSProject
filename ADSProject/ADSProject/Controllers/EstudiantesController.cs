﻿using ADSProject.Models;
using ADSProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace ADSProject.Controllers
{
    [Route("api/estudiantes/")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiante estudiante;
        private const string COD_EXITO = "000000";
        private const string COD_ERROR = "999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;
        public EstudiantesController(IEstudiante estudiante)
        {
            this.estudiante = estudiante;
        }
        [HttpPost("agregarEstudiante")]
        public ActionResult<string> AgregarEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                /*if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }*/
                int contador = this.estudiante.AgregarEstudiante(estudiante);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro insertado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al inserta el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPatch("actualizarEstudiante/{idEstudiante}")]
        public ActionResult<string> ActualizarEstudiante(int idEstudiante, [FromBody] Estudiante estudiante)
        {
            try
            {
                /*if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }*/
                int contador = this.estudiante.ActualizarEstudiante(idEstudiante, estudiante);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro actualizado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("eliminarEstudiante/{idEstudiante}")]
        public ActionResult<string> EliminarEstudiante(int idEstudiante)
        {
            try
            {
                bool eliminado = this.estudiante.EliminarEstudiante(idEstudiante);
                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro eliminado con exito";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Ocurrio un problema al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                }
                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("obtenerEstudiantePorID/{idEstudiante}")]
        public ActionResult<Estudiante> ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                Estudiante estudiante = this.estudiante.ObtenerEstudiantePorID(idEstudiante);
                if (estudiante != null)
                {
                    return Ok(estudiante);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se encontro el registro";
                    pMensajeTecnico = pCodRespuesta + " || " + pMensajeUsuario;
                    return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("obtenerEstudiantes")]
        public ActionResult<List<Estudiante>> ObtenerEstudiantes()
        {
            try
            {
                List<Estudiante> lstEstudiantes = this.estudiante.ObtenerTodosLosEstudiante();

                return Ok(lstEstudiantes);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
