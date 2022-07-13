using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{


    public class CiudadDAO
    {
        #region "PATRON SINGLETON"
        private static CiudadDAO daoCiudad = null;
        private CiudadDAO() { }
        public static CiudadDAO getInstance()
        {
            if (daoCiudad == null)
            {
                daoCiudad = new CiudadDAO();
            }
            return daoCiudad;
        }
        #endregion
        public List<Ciudad> BuscarCiudad(int paisId)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Ciudad> ciudades = new List<Ciudad>();
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand($"select * from ciudades where paisId='{paisId}'", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Ciudad objCiudades = new Ciudad();
                        objCiudades.Id = Convert.ToInt32(dr["id"]);
                        objCiudades.Nombre = dr["nombre"].ToString();
                        ciudades.Add(objCiudades);

                    }
                }


            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return ciudades;
        }

        public List<Ciudad> BuscarCiudad()
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Ciudad> ciudades = new List<Ciudad>();
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("select * from ciudades", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                dr = cmd.ExecuteReader();
                while(dr.NextResult()){
                    if (dr.Read())
                    {
                        Ciudad objCiudades = new Ciudad();
                        objCiudades.Id = Convert.ToInt32(dr["id"]);
                        objCiudades.Nombre = dr["nombres"].ToString();
                        ciudades.Add(objCiudades);

                    }
                }
                

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return ciudades;
        }
    }
}
