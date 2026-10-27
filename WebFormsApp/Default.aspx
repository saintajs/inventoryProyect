<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="inv-page">
        <div class="inv-toolbar">
            <button type="button" class="btn btn-primary inv-btn-nuevo" data-toggle="modal" data-target="#modalNuevoProducto">
                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                Nuevo
            </button>
        </div>

        <div class="inv-grid-wrap">
            <div class="table-responsive">
                <asp:GridView ID="gvProductos" runat="server"
                    AutoGenerateColumns="False"
                    DataKeyNames="Id"
                    GridLines="None"
                    CssClass="table table-striped table-hover table-bordered inv-grid"
                    OnRowDeleting="gvProductos_RowDeleting">

                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                        <asp:CommandField ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="modal fade" id="modalNuevoProducto" tabindex="-1" role="dialog" aria-labelledby="modalNuevoTitulo">
            <div class="modal-dialog" role="document">
                <div class="modal-content inv-modal">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="modalNuevoTitulo">Nuevo producto</h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalError" runat="server" CssClass="inv-modal-error" />
                        <div class="form-group">
                            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="txtNombre" Text="Nombre" />
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCantidad" runat="server" AssociatedControlID="txtCantidad" Text="Cantidad" />
                            <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" />
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblPrecio" runat="server" AssociatedControlID="txtPrecio" Text="Precio" />
                            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnGuardar" runat="server"
                            Text="Guardar"
                            CssClass="btn btn-primary inv-btn-submit-modal"
                            OnClick="btnGuardar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        $(function () {
            $('.inv-btn-nuevo').on('click', function () {
                $('#<%= txtNombre.ClientID %>').val('');
                $('#<%= txtCantidad.ClientID %>').val('');
                $('#<%= txtPrecio.ClientID %>').val('');
                $('#<%= lblModalError.ClientID %>').text('').addClass('hide');
            });
        });
    </script>

</asp:Content>
