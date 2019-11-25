<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroUsuario.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistrosUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading text-primary text-center">Registro Usuario</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--UsuarioId--%>
                    <div class="panel-body">
                        <div class="form-horizontal" role="form">
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

                            <%--Nombre--%>
                            <div class="form-group">
                                <label for="Nombre" class="col-md-3 control-label input-sm">Nombre: </label>
                                <div class="col-md-6">
                                    <asp:TextBox CssClass="form-control input-sm" ID="NombreTextBox" placeholder="Ingrese el Nombre de Usuario" Enabled="true" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="NombreRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="NombreTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="NombreTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                                </div>
                            </div>
                            <%--  Telefono--%>
                            <div class="form-group">
                                <label for="TelefonoID" class="col-md-3 control-label input-sm">Telefono:</label>
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
                            <%--  Email--%>
                            <div class="form-group">
                                <label for="Email" class="col-md-3 control-label input-sm">Email:</label>
                                <div class="col-md-6">
                                    <asp:TextBox class="form-control" type="email" ID="EmailTextBox" placeholder="Micorreo@gmail.com" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <%-- Nivel--%>
                            <div class="form-group">
                                <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Nivel:</label>
                                <div class="col-md-6">
                                    <asp:DropDownList runat="server" ID="Tipousuario" Class="form-control input-sm">
                                        <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="Usuario" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <%-- Contrasena--%>
                            <div class="form-group">
                                <label for="Contrasena" class="col-md-3 control-label input-sm">Contraseña:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="ContrasenaTextBox" runat="server"
                                        Class="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="Contrasena" runat="server" MaxLength="200"
                                        ControlToValidate="ContrasenaTextBox"
                                        ErrorMessage="Campo Contrasena obligatorio" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="True"
                                        ToolTip="Campo Contrasena obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Contrasena
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <%-- Confimar Contrasena--%>
                            <div class="form-group">
                                <label for="Contrasena" class="col-md-3 control-label input-sm">Confimar Contraseña:</label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="ConfimarTextBox" runat="server"
                                        Class="form-control input-sm"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" MaxLength="200"
                                        ControlToValidate="ConfimarTextBox"
                                        ErrorMessage="Campo Confimar obligatorio" ForeColor="Red"
                                        Display="Dynamic" SetFocusOnError="True"
                                        ToolTip="Campo Contrasena obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Contrasena
                                    </asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <asp:CustomValidator ID="PasswwordCustomValidator" runat="server" ErrorMessage="Contraseñas no coinciden" ControlToValidate="ConfimarTextBox" ForeColor="Red" SetFocusOnError="True"></asp:CustomValidator>
                            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>

                            <div class="form-group">
                                <div class="col-sm-offset-4 col-sm-10">
                                    <div class=" btn btn-primary glyphicon glyphicon-plus ">
                                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" BackColor="Transparent" BorderWidth="0" OnClick="NuevoButton_Click"></asp:Button>
                                    </div>
                                    <div class="btn btn-success glyphicon glyphicon-floppy-disk">
                                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" BackColor="Transparent" BorderWidth="0" OnClick="GuadarButton_Click" ValidationGroup="Guardar"></asp:Button>
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
