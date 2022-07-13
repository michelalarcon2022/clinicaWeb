using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;
using CapaEntidades;

namespace CapaLogicaNegocio
{
    public class PaisLN
    {
        #region "PATRON SINGLETON"
        private static PaisLN objPais = null;
        private PaisLN() { }
        public static PaisLN getInstance()
        {
            if (objPais == null)
            {
                objPais = new PaisLN();
            }
            return objPais;
        }
        #endregion

        public bool RegistrarPais(Pais pais)
        {
            try
            {
                return PaisDAO.getInstance().RegistrarPais(pais);
            }
            catch (Exception e) { throw e; }
        }


        //public bool ActualizarMenu(Menu menu)
        //{
        //    try
        //    {
        //        return MenuDAO.getInstance().ActualizarMenu(menu);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public bool EliminarPais(Int32 id)
        {
            try
            {
                return PaisDAO.getInstance().EliminarPais(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public List<Menu> ListarMenuPrincipal()
        //{
        //    try
        //    {
        //        return MenuDAO.getInstance().ListarMenuPrincipal();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        public List<Pais> ListarPaises()
        {
            try
            {
                return PaisDAO.getInstance().BuscarPais();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public Permiso ListarMenuPorEmpleado(Int32 IdEmpleado)
        //{
        //    try
        //    {
        //        return MenuDAO.getInstance().ListarMenuPorEmpleado(IdEmpleado);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
