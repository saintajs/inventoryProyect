
using MiInventario.BLL.Models;
using MiInventario.BLL.Services;
using System;
using System.Globalization;
using System.Web.UI;

namespace WebFormsApp
{
    public partial class _Default : Page
    {
        ProductoService service = new ProductoService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Cargar();
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            lblModalError.CssClass = string.IsNullOrWhiteSpace(lblModalError.Text)
                ? "inv-modal-error hide"
                : "inv-modal-error help-block text-danger";
        }

        private void Cargar()
        {
            gvProductos.DataSource = service.ObtenerTodos();
            gvProductos.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            lblModalError.Text = string.Empty;

            try
            {
                int cantidad = int.Parse(txtCantidad.Text.Trim(), CultureInfo.InvariantCulture);
                decimal precio = decimal.Parse(txtPrecio.Text.Trim(), CultureInfo.InvariantCulture);

                service.Agregar(new Producto
                {
                    Nombre = txtNombre.Text.Trim(),
                    Cantidad = cantidad,
                    Precio = precio
                });

                txtNombre.Text = string.Empty;
                txtCantidad.Text = string.Empty;
                txtPrecio.Text = string.Empty;

                Cargar();

                ClientScript.RegisterStartupScript(GetType(), "cerrarModalNuevo",
                    "$('#modalNuevoProducto').modal('hide');", true);
            }
            catch (FormatException)
            {
                lblModalError.Text = "Revise cantidad y precio: deben ser números válidos.";
                ClientScript.RegisterStartupScript(GetType(), "mostrarModalNuevo",
                    "$('#modalNuevoProducto').modal('show');", true);
            }
            catch (Exception ex)
            {
                lblModalError.Text = "No se pudo guardar: " + ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "mostrarModalNuevoErr",
                    "$('#modalNuevoProducto').modal('show');", true);
            }
        }

        protected void gvProductos_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            int id = (int)gvProductos.DataKeys[e.RowIndex].Value;
            service.Eliminar(id);
            Cargar();
        }
    }
}
