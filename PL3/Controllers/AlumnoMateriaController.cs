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
            ML.Result result = BL.AlumnoMateria.DeleteMateriaAsignada(alumnomateria);

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
        [HttpPost]

        public ActionResult AddAlumnoMateria(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            if (alumnomateria.AlumnoMaterias != null)
            {
                foreach (string IdMateria in alumnomateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateria1 = new ML.AlumnoMateria();

                    alumnomateria1.Alumno = new ML.Alumno();
                    alumnomateria1.Materias = new ML.Materia();

                    alumnomateria1.Alumno.IdAlumno = alumnomateria.Alumno.IdAlumno;
                    alumnomateria1.Materias.IdMateria = int.Parse(IdMateria);

                    ML.Result resul = BL.AlumnoMateria.AddAlumnoMateria(alumnomateria1);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizaron las materias";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnomateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }
        public ActionResult DeleteAlumnoMateria(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            if (alumnomateria.AlumnoMaterias != null)
            {
                foreach (string IdAlumnoMateria in alumnomateria.AlumnoMaterias)
                {
                    ML.AlumnoMateria alumnomateria1 = new ML.AlumnoMateria();

                    alumnomateria1.IdAlumnoMateria = int.Parse(IdAlumnoMateria);

                    ML.Result resul = BL.AlumnoMateria.DeleteMateriaAsignada(alumnomateria1);
                }
                result.Correct = true;
                ViewBag.Message = "Se ha actualizaron las materias";
                ViewBag.MateriasAsignadas = true;
                ViewBag.IdAlumno = alumnomateria.Alumno.IdAlumno;
            }
            else
            {
                result.Correct = false;
            }
            return PartialView("Modal");
        }
    }
}