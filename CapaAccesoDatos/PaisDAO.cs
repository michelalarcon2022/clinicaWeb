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
    public class PaisDAO
    {
        #region "PATRON SINGLETON"
        private static PaisDAO daoPais = null;
        private PaisDAO() { }
        public static PaisDAO getInstance()
        {
            if (daoPais == null)
            {
                daoPais = new PaisDAO();
            }
            return daoPais;
        }
        #endregion
        public bool RegistrarPais(Pais pais)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            bool response = false;

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spRegistrarPais", conn);
                cmd.Parameters.AddWithValue("@prmNombre", pais.Nombre);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();

                cmd.ExecuteNonQuery();

                response = true;
            }
            catch (Exception e)
            {
                response = false;
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return response;
        }




        public List<Pais> BuscarPais()
        {
            CiudadDAO ciudadDAO = CiudadDAO.getInstance();
            SqlConnection con = null;
            SqlCommand cmd = null;
            SqlDataReader dr = null;
            List<Pais> paises = new List<Pais>();
            try
            {
                con = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("select * from paises where estado = 1", con);
                cmd.CommandType = CommandType.Text;

                con.Open();

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Pais objPais = new Pais();
                        objPais.Id = Convert.ToInt32(dr["id"]);
                        objPais.Nombre = dr["nombre"].ToString();
                        paises.Add(objPais);

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
            foreach (var pais in paises)
            {
                pais.Ciudades = ciudadDAO.BuscarCiudad(pais.Id);

            }
            return paises;


        }

        public bool EliminarPais(Int32 id)
        {
            SqlCommand cmd = null;
            SqlConnection conn = null;
            bool response = false;

            try
            {
                conn = Conexion.getInstance().ConexionBD();
                cmd = new SqlCommand("spEliminarPais", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdPais", id);
                conn.Open();

                cmd.ExecuteNonQuery();

                response = true;

            }
            catch (Exception e)
            {
                response = false;
                throw e;
            }
            finally
            {
                conn.Close();
            }
            return response;
        }
    }
}
