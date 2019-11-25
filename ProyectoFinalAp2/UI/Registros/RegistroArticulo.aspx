<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroArticulo.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistrosArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading text-primary text-center">Registro Articulo</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%-- ArticuloID--%>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="IdTextBox" class="col-md-3 control-label input-sm">ID: </label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="IdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="IdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                            </div>
                            <asp:Button CssClass="col-md-1 btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                            <label for="fechaTextBox" class="col-md-2 control-label input-sm">Fecha: </label>
                            <div class="col-md-2">
                                <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <%--Departamento--%>
                        <div class="form-group">
                            <label for="DepartamentoTextBox" class="col-md-3 control-label input-sm">Departamento: </label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="DepartamentoDropdownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.5em">
                                </asp:DropDownList>
                            </div>
                            <a class="btn btn-info" href="RegistroDepartamento.aspx" target="_blank" role="button">+</a>
                        </div>

                        <%--Categoria--%>
                        <div class="form-group">
                            <label for="CategoriaTextBox" class="col-md-3 control-label input-sm">Categoria: </label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="CategoriaDropDownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.5em">
                                </asp:DropDownList>
                            </div>
                            <a class="btn btn-info" href="RegistroCategoria.aspx" target="_blank" role="button">+</a>
                        </div>

                        <%--Proveedores--%>
                        <div class="form-group">
                            <label for="ProveedoresTextBox" class="col-md-3 control-label input-sm">Proveedor: </label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="ProveedorDropDownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.5em">
                                </asp:DropDownList>
                            </div>
                            <a class="btn btn-info" href="RegistroProveedores.aspx" target="_blank" role="button">+</a>
                        </div>

                        <%--Descripcion--%>
                        <div class="form-group">
                            <label for="DescripcionID" class="col-md-3 control-label input-sm">Descripcion: </label>
                            <div class="col-md-5">
                                <asp:TextBox CssClass="form-control input-sm" ID="DescripcionTextBox" placeholder="Ingrese el Nombre del Producto" Enabled="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="DescripcionID" runat="server" MaxLength="200"
                                    ControlToValidate="DescripcionTextBox"
                                    ErrorMessage="Campo Estudiante obligatorio" ForeColor="Red"
                                    Display="Dynamic" SetFocusOnError="True"
                                    ToolTip="Campo Descripcion obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Descripcion
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="DescripcionTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <%--  Costo--%>
                        <div class="form-group">
                            <label for="CostoTextBox" class="col-md-3 control-label input-sm">Costo: </label>
                            <div class="col-md-2">
                                <asp:TextBox class="form-control input-sm" TextMode="Number" ID="CostoTextBox" OnTextChanged="CostoTextBox_TextChanged" Text="0" runat="server" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="CostoTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="CostoTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                            </div>

                            <%--Precio--%>
                            <label for="PrecioTextBox" class="col-md-1 control-label input-sm">Precio: </label>
                            <div class="col-md-2">
                                <asp:TextBox class="form-control input-sm" TextMode="Number" ID="PrecioTextBox" OnTextChanged="PrecioTextBox_TextChanged" Text="0" runat="server" Visible="true"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="precioTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="PrecioTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                            </div>
                        </div>

                        <%--Cantidad--%>
                        <div class="form-group">
                            <label for="Cantidad:" class="col-md-3 control-label input-sm">Cantidad: </label>
                            <div class="col-md-2">
                                <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="CantidadTextBox" Text="0" runat="server"></asp:TextBox>
                            </div>

                            <%--Ganancia--%>
                            <label for="GananciaTextBox" class="col-md-1 control-label input-sm">Ganancia: </label>
                            <div class="col-md-2">
                                <asp:TextBox class="form-control input-sm" ReadOnly="True" TextMode="Number" ID="GananciaTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                            </div>
                        </div>

                        <div class="panel-footer">
                            <div class="text-center">
                                <div class=" btn btn-primary glyphicon glyphicon-plus ">
                                    <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" BackColor="Transparent" BorderWidth="0" OnClick="NuevoButton_Click"></asp:Button>
                                </div>
                                <div class="btn btn-success glyphicon glyphicon-floppy-disk">
                                    <asp:Button ID="GuardarButton" runat="server" Text="Guardar" BackColor="Transparent" BorderWidth="0" OnClick="GuardarButton_Click" ValidationGroup="Guardar"></asp:Button>
                                </div>
                                <div class="btn btn-danger glyphicon glyphicon-floppy-remove">
                                    <asp:Button CssClass=" " ID="EliminarButton" runat="server" Text="Eliminar" BackColor="Transparent" BorderWidth="0" OnClick="EliminarButton_Click"></asp:Button>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
