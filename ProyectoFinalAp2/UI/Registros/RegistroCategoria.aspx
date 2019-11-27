<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCategoria.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistroCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading text-primary text-center"> Registros Categoria</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%--DepartamentoID--%>
                    <div class="panel-body">
                        <div class="form-group">
                            <label for="IdTextBox" class="col-md-3 control-label input-sm">ID: </label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control input-sm" TextMode="Number" ID="IdTextBox" Text="0" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="IdRFV" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="IdTextBox" Display="Dynamic" ForeColor="Red" ValidationGroup="Guardar">*No puede estar vacío</asp:RequiredFieldValidator>                          
                            </div>
                            <asp:Button CssClass="col-md-1 btn btn-info btn-sm" ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                            <label for="fechaTextBox" class="col-md-2 control-label input-sm">Fecha: </label>
                            <div class="col-md-2">
                                <asp:TextBox CssClass="form-control" ID="fechaTextBox" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <%--Categoria--%>
                        <div class="form-group">
                            <label for="Categoria" class="col-md-3 control-label input-sm">Categoria: </label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control input-sm" ID="CategoriaTextBox" placeholder="Ingrese el Categoria" Enabled="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="Categoria" runat="server" MaxLength="200"
                                    ControlToValidate="CategoriaTextBox"
                                    ErrorMessage="Campo Categoria obligatorio" ForeColor="Red"
                                    Display="Dynamic" SetFocusOnError="True"
                                    ToolTip="Campo Descripcion obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Categoria
                                </asp:RequiredFieldValidator>
                            </div>
                        </div>

                        <%--Descripcion--%>
                        <div class="form-group">
                            <label for="DescripcionID" class="col-md-3 control-label input-sm">Descripcion: </label>
                            <div class="col-md-4">
                                <asp:TextBox CssClass="form-control input-sm" ID="DescripcionTextBox" placeholder="Ingrese Descripcion" Enabled="true" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="DescripcionID" runat="server" MaxLength="200"
                                    ControlToValidate="DescripcionTextBox"
                                    ErrorMessage="Campo Estudiante obligatorio" ForeColor="Red"
                                    Display="Dynamic" SetFocusOnError="True"
                                    ToolTip="Campo Descripcion obligatorio" ValidationGroup="Guardar">Por favor llenar el campo Descripcion
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="NombreREV" runat="server" ErrorMessage="Solo Letras" ControlToValidate="DescripcionTextBox" ForeColor="Red" ValidationExpression="^[a-z &amp; A-Z]*$" ValidationGroup="Guardar">Solo Letras</asp:RegularExpressionValidator>
                            </div>
                        </div>


                        <div class="panel-footer">
                            <div class="text-center">
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
