using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Pelicula GetAll()
        {
            ML.Pelicula pelicula = new ML.Pelicula();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "PeliculaGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection.Open();

                        DataTable tablePelicula = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablePelicula);

                        if (tablePelicula.Rows.Count > 0)
                        {
                            pelicula.Objects = new List<object>();

                            foreach (DataRow row in tablePelicula.Rows)
                            {
                                pelicula.IdPelicula = int.Parse(row[0].ToString());
                                pelicula.Nombre = row[1].ToString();
                                pelicula.Fechadelanzamiento = row[2].ToString();
                                pelicula.Reseña = row[3].ToString();
                                pelicula.Puntutacion = int.Parse(row[4].ToString());

                                pelicula.Director = new ML.Director();
                                pelicula.Director.IdDirector = byte.Parse(row[5].ToString());
                                pelicula.Director.Nombre = row[6].ToString();

                                pelicula.Objects.Add(pelicula);
                            }
                            pelicula.Correct = true;
                        }
                        else
                        {
                            pelicula.Correct = false;
                            pelicula.ErrorMessage = "Ocurrio un error al mostrar los datos";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                pelicula.Correct = false;
                pelicula.Ex = ex;
                pelicula.ErrorMessage = "Ocurrió un error al actualizar el registro en la tabla Pelicula" + pelicula.Ex;
            }
            return pelicula;
        }
        public static ML.Pelicula Add(ML.Pelicula pelicula)
        {
            //ML.Pelicula pelicula = new ML.Pelicula();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConection()))
                {
                    string query = "PeliculaAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[5];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = pelicula.Nombre;

                        collection[1] = new SqlParameter("FechaLanzamiento", SqlDbType.Date);
                        collection[1].Value = pelicula.Fechadelanzamiento;

                        collection[2] = new SqlParameter("Reseña", SqlDbType.VarChar);
                        collection[2].Value = pelicula.Reseña;

                        collection[3] = new SqlParameter("Puntuacion", SqlDbType.VarChar);
                        collection[3].Value = pelicula.Puntutacion;

                        collection[4] = new SqlParameter("IdDirector", SqlDbType.VarChar);
                        collection[4].Value = pelicula.Director.IdDirector;

                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            pelicula.Correct = true;
                        }
                    }
                }
            }


            catch (Exception ex)
            {

                pelicula.Correct = false;
                pelicula.Ex = ex;
                pelicula.ErrorMessage = "Ocurrió un error al insertar el registro en la tabla Pelicula" + pelicula.Ex;
                //throw;
            }

            return pelicula;
        }
    }
}
