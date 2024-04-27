using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class GrupoRepository : IGrupo
    {
        /*private List<Grupo> lstGrupo = new List<Grupo>
        {
            new Grupo
            {
                IdGrupo = 1,
                IdProfesor = 1,
                IdMateria = 1,
                IdCarrera = 1,
                Ciclo = 1,
                Anio = 2024,
            },
            new Grupo
            {
                IdGrupo = 2,
                IdProfesor = 2,
                IdMateria = 2,
                IdCarrera = 2,
                Ciclo = 1,
                Anio = 2024,
            },
            new Grupo
            {
                IdGrupo = 3,
                IdProfesor = 3,
                IdMateria = 3,
                IdCarrera = 3,
                Ciclo = 1,
                Anio = 2024,
            },
            new Grupo
            {
                IdGrupo = 4,
                IdProfesor = 4,
                IdMateria = 4,
                IdCarrera = 4,
                Ciclo = 1,
                Anio = 2024,
            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public GrupoRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarGrupo(int idGrupo, Grupo grupo)
        {
            try
            {
                //int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                //lstGrupo[indice] = grupo;
                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);

                applicationDbContext.Entry(item).CurrentValues.SetValues(grupo);

                applicationDbContext.SaveChanges();
                return idGrupo;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int AgregarGrupo(Grupo grupo)
        {
            try
            {
                /*if (lstGrupo.Count > 0)
                {
                    grupo.IdGrupo= lstGrupo.Last().IdGrupo + 1;
                }

                lstGrupo.Add(grupo);*/

                applicationDbContext.Grupos.Add(grupo);
                applicationDbContext.SaveChanges();
                return grupo.IdGrupo;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarGrupo(int idGrupo)
        {
            try
            {
                /*int indice = lstGrupo.FindIndex(tmp => tmp.IdGrupo == idGrupo);
                lstGrupo.RemoveAt(indice);*/

                var item = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);

                applicationDbContext.Grupos.Remove(item);

                applicationDbContext.SaveChanges();
                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Grupo> ObtenerGrupos()
        {
            try
            {
                //return lstGrupo;

                return applicationDbContext.Grupos.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Grupo ObtenerTodosLosGruposPorID(int idGrupo)
        {
            try
            {
                //Grupo grupo= lstGrupo.FirstOrDefault(tmp => tmp.IdGrupo == idGrupo);
                var grupo = applicationDbContext.Grupos.SingleOrDefault(x => x.IdGrupo == idGrupo);

                return grupo;

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
