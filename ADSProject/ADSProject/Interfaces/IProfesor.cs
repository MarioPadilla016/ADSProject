﻿using ADSProject.Models;

namespace ADSProject.Interfaces
{
    public interface IProfesor
    {
        public int AgregarProfesor(Profesor profesor);
        public int ActualizarProfesor(int idProfesor, Profesor profesor);
        public bool EliminarProfesor(int idProfesor);
        public Profesor ObtenerTodosLosProfesoresPorID(int idProfesor);
        public List<Profesor> ObtenerProfesores();
    }
}
