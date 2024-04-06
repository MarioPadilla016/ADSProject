using ADSProject.Interfaces;
using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ADSProject.Controllers
{
    [Route("/apis/Profesor")]
    public class ProfesorController : ControllerBase
    {
        private readonly IProfesor profesor;
        private const string COD_EXITO = "00000000";
        private const string COD_ERROR = "9999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public ProfesorController(IProfesor profesor)
        {
            this.profesor = profesor;
        }

        [HttpPost("agregarProfesor")]
        public ActionResult<string> AgregarProfesor([FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.AgregarProfesor(profesor);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Registro exitoso";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Error inesperado al insertar el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }


                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {

                throw;
            }
        }

        [HttpPut("actualizarProfesor/{idProfesor}")]
        public ActionResult<string> ActualizarProfesor(int idProfesor, [FromBody] Profesor profesor)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int contador = this.profesor.ActualizarProfesor(idProfesor, profesor);
                if (contador > 0)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "actualizacion exitoso";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Error inesperado al actualizar el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }

                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("eliminarProfesor/{idProfesor}")]
        public ActionResult<string> EliminarProfesor(int idProfesor)
        {
            try
            {
                bool eliminado = this.profesor.EliminarProfesor(idProfesor);

                if (eliminado)
                {
                    pCodRespuesta = COD_EXITO;
                    pMensajeUsuario = "Eliminacion exitoso";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "Error inesperado al eliminar el registro";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                }


                return Ok(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
            }
            catch
            {
                throw;
            }
        }


        [HttpGet("obtenerProfesorporID/{idProfesor}")]
        public ActionResult<string> ObtenerTodosLosProfesoresPorID(int idProfesor)
        {
            try
            {
                Profesor profesores = this.profesor.ObtenerTodosLosProfesoresPorID(idProfesor);
                if (profesores != null)
                {
                    return Ok(profesores);
                }
                else
                {
                    pCodRespuesta = COD_ERROR;
                    pMensajeUsuario = "No se a encontrado ningun dato";
                    pMensajeTecnico = pCodRespuesta + "||" + pMensajeUsuario;
                    return NotFound(new { pCodRespuesta, pMensajeUsuario, pMensajeTecnico });
                }

            }
            catch
            {

                throw;
            }
        }


        [HttpGet("obtenerProfesor")]
        public ActionResult<List<Profesor>> ObtenerProfesor()
        {
            try
            {
                List<Profesor> lstprofesores = this.profesor.ObtenerProfesores();
                return Ok(lstprofesores);
            }
            catch
            {
                throw;
            }
        }


    }
}
