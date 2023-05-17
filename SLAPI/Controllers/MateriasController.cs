using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace SLAPI.Controllers
{
    public class MateriasController : Controller
    {
        [HttpGet]
        [Route("api/Materia/GetAll")]
        public IActionResult GetAll()
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetAllEF(materia);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Materia/GetById")]
        public IActionResult GetById([FromBody] int idMateria)
        {
            ML.Materia materia = new ML.Materia();
            ML.Result result = BL.Materia.GetByIdEF(idMateria);
            if (result.Correct)
            {
                return Ok(result.Object);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Materia/Add")]
        public IActionResult Add([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.AddEF(materia);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPut]
        [Route("api/Materia/Update")]
        public IActionResult Update([FromBody] ML.Materia materia)
        {
            ML.Result result = BL.Materia.UpdateEF(materia);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
        }
        [HttpPost]
        [Route("api/Materia/Delete")]
        public IActionResult Delete([FromBody] int IdMateria)
        {
            ML.Result result = BL.Materia.DeleteEF(IdMateria);
            if (result.Correct)
            {
                return Ok(result.Objects);
            }
            else
            {
                return NotFound(result);
            }
        }
    }
}