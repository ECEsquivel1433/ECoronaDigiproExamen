using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PL3.Controllers
{
    public class AlumnoMateriaController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Alumno alumno = new ML.Alumno();
            ML.Result result = BL.Alumno.GetAll();

            alumno.Alumnos = result.Objects;

            return View(alumno);
        }
        [HttpGet]
        public ActionResult GetMateriasAsignadas(byte IdAlumno)
        {
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result result = BL.AlumnoMateria.GetMateriasAsignadas(IdAlumno);
            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }
        [HttpGet]
        public ActionResult GetMateriasNoAsignadas(byte IdAlumno)
        {
            ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();

            ML.Result result = BL.AlumnoMateria.GetMateriasNoAsignadas(IdAlumno);
            ML.Result resultalumno = BL.Alumno.GetById(IdAlumno);

            alumnomateria.AlumnoMaterias = result.Objects;
            alumnomateria.Alumno = ((ML.Alumno)resultalumno.Object);

            return View(alumnomateria);
        }


        public ActionResult Delete(ML.AlumnoMateria alumnomateria)
        {
            //ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
            //alumnomateria.IdAlumnoMateria = IdAlumnoMateria;
            ML.Result result = BL.AlumnoMateria.Delete(alumnomateria);

            ViewBag.MateriasAsignadas = true;
            ViewBag.IdAlumno = alumnomateria.IdAlumnoMateria;

            if (result.Correct)
            {
                ViewBag.message = "Se ha eliminado el registro";
            }
            else
            {
                ViewBag.message = "ocurrió un error al eliminar el registro " + result.ErrorMessage;

            }
            return PartialView("Modal");
        }
    }
}