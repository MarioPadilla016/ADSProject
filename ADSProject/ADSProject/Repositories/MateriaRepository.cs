using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class MateriaRepository : IMateria
    {
        /*private List<Materia> lstMateria = new List<Materia>
        {
            new Materia
            {
                IdMateria = 1,
                Nombre = "ADS"
            },
            new Materia
            {
                IdMateria = 2,
                Nombre = "DSII"
            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarMateria(int idMateria, Materia materia)
        {
            try
            {
                //int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);
                //lstMateria[indice] = materia;
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);

                applicationDbContext.Entry(item).CurrentValues.SetValues(materia);

                applicationDbContext.SaveChanges();

                return idMateria;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int AgregarMateria(Materia materia)
        {
            try
            {
                /*if (lstMateria.Count > 0)
                {
                    materia.IdMateria = lstMateria.Last().IdMateria + 1;
                }

                lstMateria.Add(materia);*/
                applicationDbContext.Materias.Add(materia);
                applicationDbContext.SaveChanges();

                return materia.IdMateria;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                /*int indice = lstMateria.FindIndex(tmp => tmp.IdMateria == idMateria);
                lstMateria.RemoveAt(indice);*/
                var item = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria== idMateria);

                applicationDbContext.Materias.Remove(item);

                applicationDbContext.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Materia> ObtenerMaterias()
        {
            try
            {
                // return lstMateria;
                return applicationDbContext.Materias.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Materia ObtenerTodasLasMateriasPorID(int idMateria)
        {
            try
            {
                //Materia materia = lstMateria.FirstOrDefault(tmp => tmp.IdMateria == idMateria);
                var materia = applicationDbContext.Materias.SingleOrDefault(x => x.IdMateria == idMateria);

                return materia;

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
