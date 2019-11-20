<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroEntrada.aspx.cs" Inherits="ProyectoFinalAp2.UI.Registros.RegistroEntrada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">Registro Entreda</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <%-- EntradaID--%>
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

                    <%--Producto--%>
                    <div class="form-group">
                        <label for="ProductoTextBox" class="col-md-3 control-label input-sm">Producto: </label>
                        <div class="col-md-4">
                            <div>
                                <asp:DropDownList ID="ProductoDropdownList" CssClass=" form-control dropdown-item" AppendDataBoundItems="true" runat="server" Height="2.8em">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>

                    <%--  Costo--%>
                    <div class="form-group">
                        <label for="CostoTextBox" class="col-md-3 control-label input-sm">Costo: </label>
                        <div class="col-md-3">
                            <asp:TextBox class="form-control input-sm" TextMode="Number" ID="CostoTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                        </div>

                        <%--Cantidad--%>
                        <div class="form-group">
                            <label for="CantidadTextBox" class="col-md-3 control-label input-sm">Cantidad: </label>
                            <div class="col-md-3">
                                <asp:TextBox class="form-control input-sm" TextMode="Number" ID="CantidadTextBox" Text="0" runat="server" Visible="true"></asp:TextBox>
                            </div>
                            <%--Fecha--%>
                            <label for="FechaVencimientoTextBox" class="col-md-1 control-label input-sm">Fecha de vencimiento: </label>
                            <div class="col-md-3">
                                <asp:TextBox CssClass="form-control" ID="FechaVencimientoTextBox" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                            <asp:Button class="btn btn-info btn-sm" ID="AgregardoButton" runat="server" Text="Agregar" OnClick="AgregarButton_Click" />
                        </div>
                        <div class="table-responsive">
                            <div class="center">
                                <asp:GridView ID="GridView"
                                    runat="server"
                                    class="table table-condensed table-bordered table-responsive"
                                    CellPadding="4" ForeColor="#333333" GridLines="None">

                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField ShowHeader="False" HeaderText="Remover">
                                            <ItemTemplate>
                                                <asp:Button ID="RemoveLinkButton" runat="server" CausesValidation="false" CommandName="Select"
                                                    Text="Remover " class="btn btn-success btn-sm" OnClick="RemoveLinkButton_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                    <RowStyle BackColor="#EFF3FB" />
                                </asp:GridView>
                            </div>
                        </div>

                        <div class="form-group">
                            <label for="Total:" class="col-md-3 control-label input-sm">Total: </label>
                            <div class="col-md-4">
                                <asp:TextBox class="form-control input-sm" ReadOnly="True" ID="TotalTextBox" Text="0" runat="server"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        <div class="panel-footer">
            <div class="text-center">
                <div class="form-group" style="display: inline-block">

                    <asp:Button Text="Nuevo" CssClass="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                    <asp:Button Text="Guardar" CssClass="btn btn-success btn-sm" runat="server" ID="GuadarButton" OnClick="GuardarButton_Click" />
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
