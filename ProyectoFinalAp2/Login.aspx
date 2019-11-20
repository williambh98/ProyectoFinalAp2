<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinalAp2.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div style="max-width: 600px;">
            <div class="panel panel-default">
                <div class="panel-heading h4 text-primary text-center">
                    Bienvenido System Inventario
                </div>
                <div class="panel-body">
                    <div class="form-horizontal" role="form">
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="txtmobile">User: </label>
                            <div class="col-sm-10">
                                <asp:TextBox class="form-control" ID="txtmobile" placeholder="Digite el usuario" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="txtpwd">Password: </label>
                            <div class="col-sm-10">
                                <asp:TextBox class="form-control" ID="txtpwd" TextMode="Password" placeholder="Digite la Password" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-2 col-sm-10">
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-offset-5 col-sm-10">
                                <asp:Button CssClass="btn btn-success" ID="btnLogin" runat="server" Text="Login"></asp:Button>
                                <asp:Button CssClass="btn btn-danger" ID="Salir" runat="server" Text="Salir"></asp:Button>
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
