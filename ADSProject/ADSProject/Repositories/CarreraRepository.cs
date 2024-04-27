using ADSProject.DB;
using ADSProject.Interfaces;
using ADSProject.Migrations;
using ADSProject.Models;

namespace ADSProject.Repositories
{
    public class CarreraRepository : ICarrera
    {
        /*private List<Carrera> lstCarrera = new List<Carrera>
       {
           new Carrera
           {
               IdCarrera = 1,
               Codigo = "I01001",
               Nombre = "Ingenieria en Sistemas Computacionales"
           },
           new Carrera
           {
               IdCarrera = 2,
               Codigo = "I02001",
               Nombre = "Ingenieria Electrica"
           }
           ,
           new Carrera
           {
               IdCarrera = 3,
               Codigo = "I03001",
               Nombre = "Ingenieria en Agronegocios"
           },
           new Carrera
           {
               IdCarrera = 4,
               Codigo = "I04001",
               Nombre = "Ingenieria Industrial"
           }
       };*/
        private readonly ApplicationDbContext applicationDbContext;
        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public int ActualizarCarrera(int idCarrera, Carrera carrera)
        {
            try
            {
                //int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                //lstCarrera[indice] = carrera;

                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);

                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);

                applicationDbContext.SaveChanges();
                return idCarrera;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                /*if (lstCarrera.Count > 0)
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera + 1;
                }

                lstCarrera.Add(carrera);*/

                applicationDbContext.Carreras.Add(carrera);
                applicationDbContext.SaveChanges();

                return carrera.IdCarrera;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int idCarrera)
        {
            try
            {
                /*int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == idCarrera);
                lstCarrera.RemoveAt(indice);*/

                var item = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);

                applicationDbContext.Carreras.Remove(item);

                applicationDbContext.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerCarreras()
        {
            try
            {
                //return lstCarrera;
                return applicationDbContext.Carreras.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public Carrera ObtenerTodasLasCarrerasPorID(int idCarrera)
        {
            try
            {
                //Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == idCarrera);
                var carrera = applicationDbContext.Carreras.SingleOrDefault(x => x.IdCarrera == idCarrera);

                return carrera;

            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
