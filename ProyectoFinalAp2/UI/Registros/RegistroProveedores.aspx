﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroProveedores.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistroProveedores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registros Proveedores</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--Proveedores--%>
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

                    <%--Nombre--%>
                    <div class="form-group">
                        <label for="Nombre" class="col-md-3 control-label input-sm">Nombre: </label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control input-sm" ID="NombreTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Nombre" runat="server" MaxLength="200"
                                ControlToValidate="NombreTextBox"
                                ErrorMessage="Campo Nombre obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Descripcion obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Nombre
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--Direccion--%>
                    <div class="form-group">
                        <label for="Direccion" class="col-md-3 control-label input-sm">Direccion: </label>
                        <div class="col-md-4">
                            <asp:TextBox CssClass="form-control input-sm" ID="DireccionTextBox" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Direccion" runat="server" MaxLength="200"
                                ControlToValidate="DireccionTextBox"
                                ErrorMessage="Campo Direccion obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Descripcion obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Direccion
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <%--  Email--%>
                    <div class="form-group">
                        <label for="EmailTextBox" class="col-md-3 control-label input-sm">Email:</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="EmailTextBox" runat="server"
                                Class="form-control input-sm"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="Email" runat="server" MaxLength="200"
                                ControlToValidate="EmailTextBox"
                                ErrorMessage="Campo Email obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Email obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Email
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <%--  Telefono--%>
                    <div class="form-group">
                        <label for="TelefonoTextBox" class="col-md-3 control-label input-sm">Telefono:</label>
                        <div class="col-md-8">
                            <asp:TextBox ID="TelefonoTextBox" runat="server"
                                Class="form-control input-sm"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="Telefono" runat="server" MaxLength="200"
                                ControlToValidate="TelefonoTextBox"
                                ErrorMessage="Campo Telefono obligatorio" ForeColor="Red"
                                Display="Dynamic" SetFocusOnError="True"
                                ToolTip="Campo Telefono obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Telefono
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
            </div>

        </div>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" CssClass="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" CssClass="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" ValidationGroup="Guardar" />
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
                    <asp:RequiredFieldValidator ID="EliminarRequiredFieldValidator" CssClass="col-md-1 col-sm-1" runat="server" ControlToValidate="IdTextBox" ErrorMessage="Es necesario elegir ID valido para eliminar" ValidationGroup="Eliminar">Porfavor elige un ID valido.</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EliminarRegularExpressionValidator" CssClass="col-md-1 col-sm-1 col-md-offset-1 col-sm-offset-1" runat="server" ControlToValidate="PresupuestoTextBox" ErrorMessage="RegularExpressionValidator" ValidationExpression="\d+ " ValidationGroup="Eliminar" Visible="False"></asp:RegularExpressionValidator>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
