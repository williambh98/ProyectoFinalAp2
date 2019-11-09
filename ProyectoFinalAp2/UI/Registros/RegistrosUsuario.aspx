<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrosUsuario.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistrosUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-primary">
        <div class="panel-heading">Registro Usuario </div>
        <div class="panel-body">
            <div class="form-horizontal col-md-12" role="form">
                <%--UsuarioId--%>
                <div class="form-group">
                    <label for="IdTextBox" class="col-md-3 control-label input-sm">Id: </label>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="True" placeholder="0" class="form-control input-sm"></asp:TextBox>
                    </div>
                    <div class="col-md-1 col-sm-2 col-xs-4">
                        <asp:LinkButton ID="BusquedaButton" CssClass="btn btn-info btn-block btn-md" data-toggle="modal" data-target="#myModal" CausesValidation="False" runat="server" Text="<span class='glyphicon glyphicon-search'></span>" PostBackUrl="/UI/Consultas/Cusuario.aspx" />
                    </div>
                </div>
                <%--Nombre--%>
                <div class="form-group">
                    <label for="NombreTextBox" class="col-md-3 control-label input-sm">Nombres:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="NombreTextBox" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator
                            runat="server" ID="VLDNombreTextBox"
                            ControlToValidate="NombreTextBox" ForeColor="Red"
                            ErrorMessage="Por favor llenar el campo !"
                            Display="Dynamic" SetFocusOnError="true">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--  Telefono--%>
                <div class="form-group">
                    <label for="TelefonoTextBox" class="col-md-3 control-label input-sm">Telefono:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="TelefonoTextBox" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                          <asp:RequiredFieldValidator
                            runat="server" ID="VLDTelefonoTextBox"
                            ControlToValidate="TelefonoTextBox" ForeColor="Red"
                            ErrorMessage="Por favor llenar el campo !"
                            Display="Dynamic" SetFocusOnError="true"
                            ToolTip="Campo Telefono Obligatorio">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <%--  Email--%>
                <div class="form-group">
                    <label for="EmailTextBox" class="col-md-3 control-label input-sm">Email:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="EmailTextBox" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                           <asp:RequiredFieldValidator
                            runat="server" ID="VEmailTextBox"
                            ControlToValidate="EmailTextBox" ForeColor="Red"
                            ErrorMessage="Por favor llenar el campo !"
                            Display="Dynamic" SetFocusOnError="true"
                            ToolTip="Campo Email Obligatorio">
                        </asp:RequiredFieldValidator>
                    </div>
                </div>

                <div class="form-group">
                    <label for="TipoDropDownList" class="col-md-3 control-label input-sm">Nivel:</label>
                    <div class="col-md-8">
                        <asp:DropDownList runat="server" ID="Tipousuario" Class="form-control input-sm">
                            <asp:ListItem Text="Administrador" Value="0"></asp:ListItem>
                            <asp:ListItem Text="Usuario" Value="1"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <%-- Contrasena--%>
                <div class="form-group">
                    <label for="ContrasenaTextBox" class="col-md-3 control-label input-sm">Contrasena:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="ContrasenaTextBox" runat="server"
                            Class="form-control input-sm"></asp:TextBox>
                         <asp:RequiredFieldValidator
                            runat="server" ID="RFVContrasenia"
                            ControlToValidate="ContrasenaTextBox" ForeColor="Red"
                            ErrorMessage="Por favor llenar el campo Contraseña!"
                            Display="Dynamic" SetFocusOnError="true"
                            ToolTip="Campo Contraseña Obligatorio">

                        </asp:RequiredFieldValidator>
                    </div>
                </div>
                <%-- Fecha--%>
                <div class="form-group">
                    <label for="FechaTextBox" class="col-md-3 control-label input-sm">Fecha Creacion:</label>
                    <div class="col-md-8">
                        <asp:TextBox class="form-control" ID="TextBox1" type="date" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <asp:ValidationSummary runat="server" ID="SumaryValidation"
                    ForeColor="red"
                    DisplayMode="BulletList"
                    ShowSummary="true"
                    EnableClientScript="True"
                    Font-Bold="False"
                    CssClass=" alert alert-danger" />
            </div>
        </div>
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuadarButton_Click" />
                    <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />

                </div>
            </div>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
