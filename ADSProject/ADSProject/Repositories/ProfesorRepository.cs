using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        /*private List<Profesor> lstProfesor = new List<Profesor>
        {
            new Profesor
            {
                IdProfesor = 1,
                NombresProfesor = "Mario Faustino",
                ApellidosProfesor = "Padilla Lopez",
                EmailProfesor = "mario.padilla@gmail.com"
            },
            new Profesor
            {
                IdProfesor = 2,
                NombresProfesor = "Jose Armando",
                ApellidosProfesor = "Perez Hernandez",
                EmailProfesor = "jose.perez@gmail.com"
            },
            new Profesor
            {
                IdProfesor = 3,
                NombresProfesor = "Einer Alexis",
                ApellidosProfesor = "Gonzales Diaz",
                EmailProfesor = "einer.gonzales@gmail.com"
            },
            new Profesor
            {
                IdProfesor = 1,
                NombresProfesor = "Carlos Alberto",
                ApellidosProfesor = "Peralta Robles",
                EmailProfesor = "carlos.peralta@gmail.com"
            }
        };*/
        private readonly ApplicationDbContext applicationDbContext;
        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarProfesor(int idProfesor, Profesor profesor)
        {
            try
            {
                //int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                //lstProfesor[indice] = profesor;
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                applicationDbContext.Entry(item).CurrentValues.SetValues(profesor);

                applicationDbContext.SaveChanges();

                return idProfesor;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                /*if (lstProfesor.Count > 0)
                {
                    profesor.IdProfesor = lstProfesor.Last().IdProfesor + 1;
                }

                lstProfesor.Add(profesor);*/
                applicationDbContext.Profesores.Add(profesor);
                applicationDbContext.SaveChanges();

                return profesor.IdProfesor;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarProfesor(int idProfesor)
        {
            try
            {
                //int indice = lstProfesor.FindIndex(tmp => tmp.IdProfesor == idProfesor);
                //lstProfesor.RemoveAt(indice);
                var item = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                applicationDbContext.Profesores.Remove(item);

                applicationDbContext.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Profesor> ObtenerProfesores()
        {
            try
            {
                //return lstProfesor;
                return applicationDbContext.Profesores.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Profesor ObtenerTodosLosProfesoresPorID(int idProfesor)
        {
            try
            {
                //Profesor profesor = lstProfesor.FirstOrDefault(tmp => tmp.IdProfesor == idProfesor);
                var profesor = applicationDbContext.Profesores.SingleOrDefault(x => x.IdProfesor == idProfesor);

                return profesor;

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
