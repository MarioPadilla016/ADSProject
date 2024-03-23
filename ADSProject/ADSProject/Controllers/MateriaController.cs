using ADSProject.Models;
using Microsoft.AspNetCore.Mvc;
using ADSProject.Interfaces;
using System.Runtime.CompilerServices;

namespace ADSProject.Controllers
{
    [Route("/apis/Materia")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateria materia;
        private const string COD_EXITO = "00000000";
        private const string COD_ERROR = "9999999";
        private string pCodRespuesta;
        private string pMensajeUsuario;
        private string pMensajeTecnico;

        public MateriaController(IMateria materia)
        {
            this.materia = materia;
        }

        [HttpPost("agregarMateria")]
        public ActionResult<string> AgregarMateria([FromBody] Materia materia)
        {
            try
            {
                int contador = this.materia.AgregarMateria(materia);
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

        [HttpPut("actualizarMateria/{idMateria}")]
        public ActionResult<string> ActualizarMateria(int idMateria, [FromBody] Materia materia)
        {
            try
            {
                int contador = this.materia.ActualizarMateria(idMateria, materia);
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

        [HttpDelete("eliminarMateria/{idMateria}")]
        public ActionResult<string> EliminarMateria(int idMateria)
        {
            try
            {
                bool eliminado = this.materia.EliminarMateria(idMateria);

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

        [HttpGet("obtenerMateriaPorID/{idMateria}")]
        public ActionResult<string> ObtenerTodasLasMateriasPorID(int idMateria)
        {
            try
            {
                Materia materias = this.materia.ObtenerTodasLasMateriasPorID(idMateria);
                if (materias != null)
                {
                    return Ok(materias);
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

        [HttpGet("obtenerMateria")]
        public ActionResult<List<Materia>> ObtenerMateria()
        {
            try
            {
                List<Materia> lstmaterias = this.materia.ObtenerMaterias();
                return Ok(lstmaterias);
            }
            catch
            {
                throw;
            }
        }
    }
}
