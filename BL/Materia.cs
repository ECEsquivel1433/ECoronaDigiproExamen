using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;

namespace BL
{
    public class Materia
    {
        public static ML.Result AddEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JTorresControlEscolarEntities context = new DL.JTorresControlEscolarEntities())
                {
                    int queryEF = context.MateriaAdd(materia.Nombre, materia.Costo);
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el materia" + ex;
            }
            return result;
        }
        public static ML.Result UpdateEF(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JTorresControlEscolarEntities context = new DL.JTorresControlEscolarEntities())
                {
                    int queryEF = context.MateriaUpdate(materia.IdMateria,materia.Nombre, materia.Costo);
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el materia" + ex;
            }
            return result;
        }
        public static ML.Result DeleteEF(int IdMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JTorresControlEscolarEntities context = new DL.JTorresControlEscolarEntities())
                {
                    int queryEF = context.MateriaDelete(IdMateria); //(materia.IdMateria)
                    if (queryEF > 0)
                    {
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el materia" + ex;
            }
            return result;
        }
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JTorresControlEscolarEntities context = new DL.JTorresControlEscolarEntities())
                {
                    var queryEF = context.MateriaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (queryEF != null)
                    {
                        foreach (var obj in queryEF)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = obj.IdMateria;
                            materia.Nombre = obj.Nombre;
                            materia.Costo = obj.Costo;


                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el materia" + ex;
            }
            return result;
        }

        public static ML.Result GetByIdEF(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JTorresControlEscolarEntities context = new DL.JTorresControlEscolarEntities())
                {
                    var queryEF = context.MateriaGetById(idMateria).FirstOrDefault();
                    if (queryEF != null)
                    {
                        ML.Materia materia = new ML.Materia();

                        materia.IdMateria = queryEF.IdMateria;
                        materia.Nombre = queryEF.Nombre;
                        materia.Costo = queryEF.Costo;

                        result.Object = materia;

                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "Ocurrio un error al insertar el materia" + ex;
            }
            return result;
        }
    }
}
