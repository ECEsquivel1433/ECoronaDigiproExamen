using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SLWFC
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlumnos" in both code and config file together.
    [ServiceContract]
    public interface IAlumnos
    {
        [OperationContract]
        SLWFC.Result Add(ML.Alumno alumno);

        [OperationContract]
        SLWFC.Result Update(ML.Alumno alumno);

        [OperationContract]
        SLWFC.Result Delete(ML.Alumno alumno);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SLWFC.Result GetAll();

        [OperationContract]
        [ServiceKnownType(typeof(ML.Alumno))]
        SLWFC.Result GetById(byte IdAlumno);
    }
}
