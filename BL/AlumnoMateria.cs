using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetMateriasAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "GetMateriaAsignada";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;
                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        DataTable tableAlumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumno);

                        if (tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAlumno.Rows)
                            {
                                ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                                alumnomateria.Materias = new ML.Materia();
                                alumnomateria.Alumno = new ML.Alumno();

                                alumnomateria.IdAlumnoMateria = int.Parse(row[0].ToString());

                                alumnomateria.Materias.IdMateria = int.Parse(row[1].ToString());
                                alumnomateria.Materias.Nombre = row[2].ToString();

                                result.Objects.Add(alumnomateria);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al mostrar los datos";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
            }
            return result;
        }
        public static ML.Result GetMateriasNoAsignadas(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "GeMateriaNoAsignada";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = IdAlumno;
                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        DataTable tableAlumno = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableAlumno);

                        if (tableAlumno.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tableAlumno.Rows)
                            {
                                ML.AlumnoMateria alumnomateria = new ML.AlumnoMateria();
                                alumnomateria.Materias = new ML.Materia();
                               // alumnomateria.Alumno = new ML.Alumno();

                                alumnomateria.Materias.IdMateria = int.Parse(row[0].ToString());
                                alumnomateria.Materias.Nombre = row[1].ToString();
                                alumnomateria.Materias.Costo =  decimal.Parse(row[2].ToString());

                                result.Objects.Add(alumnomateria);
                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error al mostrar los datos";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Alumno" + result.Ex;
            }
            return result;
        }
        public static ML.Result AddAlumnoMateria(ML.AlumnoMateria alumnomateria1)
        { 
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "AddAlumnoMateria";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("IdAlumno", SqlDbType.Int);
                        collection[0].Value = alumnomateria1.Alumno.IdAlumno;

                        collection[1] = new SqlParameter("IdMateria", SqlDbType.Int);
                        collection[1].Value = alumnomateria1.Materias.IdMateria;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }


            catch (Exception ex)
            {

                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Usuario" + result.Ex;
            }
            return result;
        }
        public static ML.Result DeleteMateriaAsignada(ML.AlumnoMateria alumnomateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "DeleteMateriaAsignada";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdAlumnoMateria", SqlDbType.Int);
                        collection[0].Value = alumnomateria.IdAlumnoMateria;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Usuario" + result.Ex;
            }
            return result;
        }
    }
}