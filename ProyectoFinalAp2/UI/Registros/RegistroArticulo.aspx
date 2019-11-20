<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroArticulo.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistrosArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro Articulo</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%-- ArticuloID--%>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="IdTextBox" class="col-md-3 control-label input-sm">ID: </label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
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
                            <button aria-describedby="DepartamentoDropdownList" type="button" class="btn btn-info" data-toggle="modal" data-target="#PacienteModal" runat="server">+</button>
                        </div>

                        <%--Categoria--%>
                        <div class="form-group">
                            <label for="CategoriaTextBox" class="col-md-3 control-label input-sm">Categoria: </label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="CategoriaDropDownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.5em">
                                </asp:DropDownList>
                            </div>
                            <button aria-describedby="PacientsDropdownList" type="button" class="btn btn-info" data-toggle="modal" data-target="#PacienteModal" runat="server">+</button>
                        </div>

                        <%--Proveedores--%>
                        <div class="form-group">
                            <label for="ProveedoresTextBox" class="col-md-3 control-label input-sm">Proveedor: </label>
                            <div class="col-md-5">
                                <asp:DropDownList ID="ProveedorDropDownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.5em">
                                </asp:DropDownList>
                            </div>
                            <button aria-describedby="ProveedorDropdownList" type="button" class="btn btn-info" data-toggle="modal" data-target="#PacienteModal" runat="server">+</button>
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
                            </div>
                        </div>

                        <%--  Costo--%>
                        <div class="form-group">
                            <label for="CostoTextBox" class="col-md-3 control-label input-sm">Costo: </label>
                            <div class="col-md-2">
                                <asp:TextBox class="form-control input-sm" TextMode="Number" ID="CostoTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                            </div>
                            <%--Precio--%>
                            <label for="PrecioTextBox" class="col-md-1 control-label input-sm">Precio: </label>
                            <div class="col-md-2">
                                <asp:TextBox class="form-control input-sm" TextMode="Number" ID="PrecioTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="Cantidad:" class="col-md-3 control-label input-sm">Cantidad: </label>
                            <div class="col-md-5">
                                <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="CantidadTextBox" Text="0" runat="server"></asp:TextBox>
                            </div>
                        </div>

                   <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">

                                    <asp:Button Text="Nuevo" CssClass="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                                    <asp:Button Text="Guardar" CssClass="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />
                                    <asp:Button Text="Eliminar" CssClass="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />                              
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
