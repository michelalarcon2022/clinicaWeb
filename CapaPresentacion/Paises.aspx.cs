using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocio;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class Paises : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PaisLN paisLN = PaisLN.getInstance();
                paisLN.ListarPaises();
                LlenarMenuPrincipal();
            }
        }

        private void LlenarMenuPrincipal()
        {

            //List<CapaEntidades.Menu> ListaMenu = MenuLN.getInstance().ListarMenuPrincipal();
            //ddlMenuPrincipal.DataTextField = "nombre";
            //ddlMenuPrincipal.DataSource = ListaMenu;
            //ddlMenuPrincipal.DataBind();

            //// Modal
            //ddlAMenuPrincipal.DataValueField = "idMenu";
            //ddlAMenuPrincipal.DataTextField = "nombre";
            //ddlAMenuPrincipal.DataSource = ListaMenu;
            //ddlAMenuPrincipal.DataBind();
        }

        [WebMethod]
        public static List<Pais> ListarPaises()
        {
            return PaisLN.getInstance().ListarPaises();
        }

        [WebMethod]
        public static bool ActualizarDatosMenu(String id, String nombrePermiso, String urlPermiso, String ymenuPrincipal, bool zisActivo, bool zisSubmenu)
        {
            CapaEntidades.Menu objMenu = new CapaEntidades.Menu();
            objMenu.IdMenu = Convert.ToInt32(id);
            objMenu.Nombre = nombrePermiso;
            objMenu.Url = urlPermiso;
            objMenu.IdMenuParent = Convert.ToInt32(ymenuPrincipal);
            objMenu.Estado = zisActivo;
            objMenu.IsSubMenu = zisSubmenu;

            return MenuLN.getInstance().ActualizarMenu(objMenu);
        }

        [WebMethod]
        public static bool EliminarDatosPaises(String id)
        {
            Int32 idPais = Convert.ToInt32(id);

            return PaisLN.getInstance().EliminarPais(idPais);
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            CapaEntidades.Pais objPais = new CapaEntidades.Pais();
            objPais.Nombre = txtNombrePermiso.Text;
            bool response = PaisLN.getInstance().RegistrarPais(objPais);
            if (response)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");
                LlenarMenuPrincipal();
            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");
            }
        }
    }
}