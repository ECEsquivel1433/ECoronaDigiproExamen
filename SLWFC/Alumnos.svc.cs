using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Alumnos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Alumnos.svc or Alumnos.svc.cs at the Solution Explorer and start debugging.
    public class Alumnos : IAlumnos
    {
        public SLWFC.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            result = BL.Alumno.AddSP(alumno);

            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWFC.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            result = BL.Alumno.UpdateSP(alumno);

            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWFC.Result Delete(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            result = BL.Alumno.DeleteSP(alumno);

            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWFC.Result GetAll()
        {
            ML.Result result = BL.Alumno.GetAll();
            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
        public SLWFC.Result GetById(byte IdAlumno)
        {
            ML.Result result = BL.Alumno.GetById(IdAlumno);
            return new SLWFC.Result
            {
                Correct = result.Correct,
                ErrorMessage = result.ErrorMessage,
                Object = result.Object,
                Objects = result.Objects
            };
        }
    }
}
