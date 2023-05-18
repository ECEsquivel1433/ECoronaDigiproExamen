//using Castle.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL3.Controllers
{
    public class AlumnoController : Controller
    {
        public ActionResult GetAll()
        {
            //instanciar servicio
            ML.Alumno alumno = new ML.Alumno();
            ServiceAlumno.AlumnosClient servicealumno = new ServiceAlumno.AlumnosClient();
            


            //Llamar al servicio
            var result = servicealumno.GetAll();



            if (result.Correct)
            {
                alumno.Alumnos = result.Objects.ToList();
            }
            else
            {
                ViewBag.Mensaje = "Ocurrio un error al consultar la información";
                return View();
            }
            return View(alumno);
        }

        [HttpGet]
        public ActionResult Form(byte? IdAlumno)
        {

            ML.Alumno alumno = new ML.Alumno();

            ML.Result resultAlumno = BL.Alumno.GetById(IdAlumno);

            if (resultAlumno.Correct)
            {
                alumno = (ML.Alumno)resultAlumno.Object;
            }
            if (IdAlumno == null)
            {

                return View(alumno);
            }
            else
            {
                ServiceAlumno.AlumnosClient servicealumno = new ServiceAlumno.AlumnosClient();
                var result = servicealumno.GetById(IdAlumno.Value);

                if (result.Correct)
                {
                    alumno = (ML.Alumno)result.Object;
                    return View(alumno);
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al consultar la información";
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            if (alumno.IdAlumno == 0)
            {
                //result = BL.Alumno.Add(alumno);

                ServiceAlumno.AlumnosClient servicealumno = new ServiceAlumno.AlumnosClient();

                var result = servicealumno.Add(alumno);


                if (result.Correct)
                {
                    ViewBag.Message = "Se inserto correctamente el alumno";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al insertar el alumno";
                }
            }
            else
            {

                ServiceAlumno.AlumnosClient servicealumno = new ServiceAlumno.AlumnosClient();
                var result = servicealumno.Update(alumno);

                if (result.Correct)
                {
                    ViewBag.Message = "Se actualizo correctamente el alumno";
                }
                else
                {
                    ViewBag.Message = "Ocurrio un error al actualizar el alumno";
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(ML.Alumno alumno)
        {
            ML.Result result = BL.Alumno.DeleteSP(alumno);
            if (result.Correct)
            {
                ViewBag.Message = "Se elimino el Departamento";

            }
            else
            {
                ViewBag.Message = "Ocurrio un error al eliminar el Departamento";
            }
            return PartialView("Modal");

        }
    }
}