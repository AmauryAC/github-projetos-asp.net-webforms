<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BibliotecaGames.Autenticacao.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Usuário:<br />
        <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>

        <br />
        
        Senha:<br />
        <asp:TextBox ID="txtSenha" TextMode="Password" runat="server"></asp:TextBox>

        <br />
        <asp:Label ID="lblStatus" runat="server"></asp:Label>

        <br />
        <asp:Button ID="btnLogin" Text="Entrar" runat="server" OnClick="btnLogin_Click" />

    </div>
    </form>
</body>
</html>
