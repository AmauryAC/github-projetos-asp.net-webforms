<%@ Page Title="" Language="C#" MasterPageFile="~/Jogos/SiteMasterPage.Master" AutoEventWireup="true" CodeBehind="CadastroEdicaoJogo.aspx.cs" Inherits="BibliotecaGames.Jogos.CadastroEdicaoJogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-horizontal">
        <div class="form-group">
            <div class="col-md-2">
                <label for="txtTitulo">Título</label>
                <asp:TextBox runat="server" ID="txtTitulo" CssClass="form-control"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" Text="*" ErrorMessage="É necessário preencher o campo Título"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-2">
                <label for="txtValorPago">Valor Pago</label>
                <asp:TextBox runat="server" ID="txtValorPago" TextMode="Number" CssClass="form-control"></asp:TextBox>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-2">
                <label for="txtDataCompra">Data Compra</label>
                <asp:TextBox runat="server" ID="txtDataCompra" TextMode="Date" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="form-group">
            <div class="col-md-2">
                <label for="fupImage">Imagem</label>
                <asp:FileUpload runat="server" ID="fupImage" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-2">
                <label for="ddlGenero">Gênero</label>
                <asp:DropDownList runat="server" ID="ddlGenero" DataValueField="Id" DataTextField="Descricao" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvGenero" runat="server" ControlToValidate="ddlGenero" Text="*" ErrorMessage="É necessário preencher o campo Gênero"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group">
            <div class="col-md-2">
                <label for="ddlEditor">Editor</label>
                <asp:DropDownList runat="server" ID="ddlEditor" DataValueField="Id" DataTextField="Nome" CssClass="form-control"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvEditor" runat="server" ControlToValidate="ddlEditor" Text="*" ErrorMessage="É necessário preencher o campo Editor"></asp:RequiredFieldValidator>
            </div>
        </div>

        <asp:ValidationSummary ID="valSum" DisplayMode="BulletList" EnableClientScript="true" ForeColor="Red" HeaderText="Os campos com * são obrigatórios:" runat="server" />
        <asp:Label runat="server" ID="lblMensagem"></asp:Label>
        <br />

        <asp:Button runat="server" ID="btnGravar" Text="Gravar" CssClass="btn btn-primary" OnClick="btnGravar_Click" />

        <br />
        <a href="Catalogo.aspx">Voltar</a>
    </div>
</asp:Content>
