<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoFinalAp2.Loginnn" %>

<!DOCTYPE html>
<link href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<html>
<head runat="server">

    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js"></script>
    <link href="Content/toastr.css" rel="stylesheet" />
    <script type="text/javascript" src="/Scripts/toastr.min.js"></script>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
</head>

<body>
    <div class="container">
             
        <div class="panel" style="background-color:#008000">
            <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align: center; color: Black">System Inventario</div>
        </div>
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <h1 class="text-center login-title">Login</h1>

                <div class="account-wall">
                    <div class="text-center">
                        <img class="profile-img" src="\Resources\usuari.png"
                            alt="">
                    </div>
                    <form runat="server">
                        <br />
                        <div class="text-center">
                            <asp:TextBox ID="UsuarioTextBox" placeholder="Usuario" runat="server" Width="228px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ingrese Correo Electronico!" ValidationGroup="Iniciar" ControlToValidate="UsuarioTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Correo obligatorio&quot;&gt;Por favor llenar el campo Correo">*</asp:RequiredFieldValidator>

                        </div>
                        <br />
                        <div class="text-center">
                            <asp:TextBox ID="PasswordTextBox" type="password" placeholder="Password" runat="server" Width="228px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ingrese Correo Electronico!" ValidationGroup="Iniciar" ControlToValidate="PasswordTextBox" Display="Dynamic" Font-Bold="True" ForeColor="Red" SetFocusOnError="True" ToolTip="Campo Correo obligatorio&quot;&gt;Por favor llenar el campo Correo">*</asp:RequiredFieldValidator>

                        </div>
                        <br />
                        <asp:Button runat="server" Text="Iniciar" class="btn btn-md btn-primary btn-block" OnClick="LoginButton_Click" />
                        <label class="checkbox pull-center">
                            <input type="checkbox" value="remember-me">
                            Recuerdame               
                        </label>
                        <br />
                    </form>
                </div>
                <div class="text-center">
                    <a href="UI/Registros/RegistroUsuario.aspx" class="text-center new-account">Crear Cuenta </a>
                </div>
            </div>
        </div>
    </div>
</body>

</html>
