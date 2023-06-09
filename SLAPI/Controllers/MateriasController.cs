﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLAPI.Controllers
{
    public class MateriasController : ApiController
    {
        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAllEF();

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        [HttpPost]
        [Route("api/Materia/GetById")]
        public IHttpActionResult GetById([FromBody] int idMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetByIdEF(idMateria);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result.Object);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpPost]
        [Route("api/Materia/Add")]
        public IHttpActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpPut]
        [Route("api/Materia/Update")]
        public IHttpActionResult Update([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.UpdateEF(materia);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
        [HttpPost]
        [Route("api/Materia/Delete")]
        public IHttpActionResult Delete([FromBody] int IdMateria)
        {
            ML.Result result = BL.Materia.DeleteEF(IdMateria);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}