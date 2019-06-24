using BibliotecaGames.BLL.Autenticacao;
using BibliotecaGames.BLL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGames.Autenticacao
{
    public partial class Login : System.Web.UI.Page
    {
        private LoginBO _loginBO;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            _loginBO = new LoginBO();

            var nomeUsuario = txtUsuario.Text;
            var senha = txtSenha.Text;

            try
            {
                var usuario = _loginBO.ObterUsuarioParaLogar(nomeUsuario, senha);

                FormsAuthentication.RedirectFromLoginPage(nomeUsuario, false);
                
                Session["Perfil"] = usuario.Perfil;
            }
            catch(UsuarioNaoCadastradoException)
            {
                lblStatus.Text = "Usuário ou senha incorretos";
            }
            catch (Exception)
            {
                lblStatus.Text = "Ocorreu um erro inesperado, favor consultar o administrador do sistema";
            }
        }
    }
}