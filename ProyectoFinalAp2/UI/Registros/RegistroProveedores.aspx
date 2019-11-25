<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroProveedores.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistroProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading text-primary text-center"> Registros Proveedores</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--Proveedores--%>
                    <div class="form-group">
                        <label for="IdTextBox" class="col-md-3 control-label input-sm">ID: </label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0"  runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="IdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="IdREV" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="IdTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
                        </div>
                        <asp:Button CssClass="col-md-1 btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                        <label for="fechaTextBox" class="col-md-2 control-label input-sm">Fecha: </label>
                        <div class="col-md-2">
                            <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                    </div>

                    <%--Nombre--%>
                    <div class="form-group">
                        <label for="Nombre" class="col-md-3 control-label input-sm">Nombre: </label>
                        <div class="col-md-6">
                            <asp:TextBox CssClass="form-control input-sm" ID="NombreTextBox" placeholder="Ingrese el Nombre de Proveedor" Enabled="true" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Nombre" runat="server" MaxLength="200"
                                ControlToValidate="NombreTextBox"
                                ErrorMessage="Campo Nombre obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Descripcion obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Nombre
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <%--Direccion--%>
                    <div class="form-group">
                        <label for="Direccion" class="col-md-3 control-label input-sm">Direccion: </label>
                        <div class="col-md-6">
                            <asp:TextBox CssClass="form-control input-sm" ID="DireccionTextBox" placeholder="Ingrese la Direccion" Enabled="true" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Direccion" runat="server" MaxLength="200"
                                ControlToValidate="DireccionTextBox"
                                ErrorMessage="Campo Direccion obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Descripcion obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Direccion
                            </asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                        </div>
                    </div>

                    <%--  Email--%>
                    <div class="form-group">
                        <label for="EmailTextBox" class="col-md-3 control-label input-sm">Email:</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="EmailTextBox" placeholder="micorreo@gmail.com" Enabled="true" runat="server"
                                Class="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Email" runat="server" MaxLength="200"
                                ControlToValidate="EmailTextBox"
                                ErrorMessage="Campo Email obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Email obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Email
                            </asp:RequiredFieldValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <%--  Telefono--%>
                    <div class="form-group">
                        <label for="TelefonoTextBox" class="col-md-3 control-label input-sm">Telefono:</label>
                        <div class="col-md-6">
                            <asp:TextBox ID="TelefonoTextBox" placeholder="000-000-0000" MaxLength="10" Enabled="true" runat="server"
                                Class="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Telefono" runat="server" MaxLength="200"
                                ControlToValidate="TelefonoTextBox"
                                ErrorMessage="Campo Telefono obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Telefono obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Telefono
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator" runat="server" ErrorMessage="Solo Números" ForeColor="Red" ValidationExpression="^[0-9]*$" ControlToValidate="TelefonoTextBox" ValidationGroup="Guardar">Solo Números</asp:RegularExpressionValidator>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
