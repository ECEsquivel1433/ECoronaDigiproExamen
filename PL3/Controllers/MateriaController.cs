//using Castle.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL1.Controllers
{
    //public class MateriaController : Controller
    //{
    //    private IConfiguration configuration;
    //    public MateriaController(IConfiguration _configuration)
    //    {
    //        configuration = _configuration;
    //    }

    //    [HttpGet]
    //    public ActionResult GetAll()
    //    {

    //        ML.Materia materia = new ML.Materia();
    //        materia.Materias = new List<object>();

    //        using (var client = new HttpClient())
    //        {
    //            client.BaseAddress = new Uri("http://localhost:5047/api/");

    //            var responseTask = client.GetAsync("Materia/GetAll");
    //            responseTask.Wait(); //esperar a que se resuelva la llamada al servicio

    //            var result = responseTask.Result;


    //            if (result.IsSuccessStatusCode)
    //            {
    //                var readTask = result.Content.ReadAsAsync<ML.Result>();
    //                readTask.Wait();

    //                foreach (var resultItem in readTask.Result.Objects)
    //                {
    //                    ML.Materia resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultItem.ToString());
    //                    materia.Materias.Add(resultItemList);
    //                }
    //            }
    //        }
    //        return View(materia);
    //    }


    //    [HttpGet]
    //    public ActionResult Form(int? idMateria)
    //    {


    //        ML.Materia materia = new ML.Materia();



    //        //add
    //        if (idMateria == null)
    //        {
    //            return View(materia);
    //        }
    //        else //BetById para Update
    //        {
    //            //Se omite llamada a al y unboxing para WebAPI
    //            //ML.Result result = BL.Materia.GetById(idMateria.Value);
    //            using (var client = new HttpClient())
    //            {
    //                client.BaseAddress = new Uri("http://localhost:5047/api/");

    //                var postTask = client.PostAsJsonAsync<int>("Materia/GetById", idMateria.Value);
    //                postTask.Wait();

    //                var result = postTask.Result;


    //                if (result.IsSuccessStatusCode)
    //                {
    //                    var readTask = result.Content.ReadAsAsync<ML.Materia>();
    //                    readTask.Wait();
    //                    materia = readTask.Result;

    //                }
    //            }



    //            return View(materia);
    //        }
    //    }

    //    [HttpPost]
    //    public ActionResult Form(ML.Materia materia)
    //    {

    //        ML.Result result = new ML.Result();
    //        if (materia.IdMateria == 0)
    //        {
    //            using (var client = new HttpClient())
    //            {
    //                client.BaseAddress = new Uri("http://localhost:5047/api/");

    //                //HTTP POST
    //                var postTask = client.PostAsJsonAsync<ML.Materia>("Materia/Add", materia);
    //                postTask.Wait();

    //                var materiaresult = postTask.Result;
    //                if (materiaresult.IsSuccessStatusCode)
    //                {
    //                    ViewBag.Message = "Se agrego correctamente el usuario";
    //                }
    //                else
    //                {
    //                    ViewBag.Message = "Ocurrio un error al agregar el usuario";
    //                }
    //            }
    //            return PartialView("Modal");
    //        }
    //        else
    //        {
    //            using (var client = new HttpClient())
    //            {
    //                client.BaseAddress = new Uri("http://localhost:5047/api/");

    //                //HTTP POST
    //                var putTask = client.PutAsJsonAsync<ML.Materia>("Materia/Update", materia);
    //                putTask.Wait();

    //                var materiaresult = putTask.Result;
    //                if (materiaresult.IsSuccessStatusCode)
    //                {
    //                    ViewBag.Message = "Se actualizo correctamente el usuario";
    //                }
    //                else
    //                {
    //                    ViewBag.Message = "Ocurrio un error al actualizar el usuario";
    //                }
    //            }
    //            return PartialView("Modal");
    //        }

    //        //return PartialView("Modal");
    //    }


    //    public ActionResult Delete(int IdMateria)
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            client.BaseAddress = new Uri("http://localhost:5047/api/");

    //            //HTTP POST
    //            var postTask = client.PostAsJsonAsync<int>("Materia/Delete", IdMateria);
    //            postTask.Wait();

    //            var materiaresult = postTask.Result;
    //            if (materiaresult.IsSuccessStatusCode)
    //            {
    //                ViewBag.Message = "Se elimino correctamente el usuario";
    //            }
    //            else
    //            {
    //                ViewBag.Message = "Ocurrio un error al eliminar el usuario";
    //            }
    //        }
    //        return PartialView("Modal");
    //    }
    //}
}