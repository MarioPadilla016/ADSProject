using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IGrupo
    {
        public int AgregarGrupo(Grupo grupo);
        public int ActualizarGrupo(int idGrupo, Grupo grupo);
        public bool EliminarGrupo(int idGrupo);
        public Grupo ObtenerTodosLosGruposPorID(int idGrupo);
        public List<Grupo> ObtenerGrupos();
    }
}
