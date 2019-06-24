using BibliotecaGames.BLL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGames.Jogos
{
    public partial class Catalogo : System.Web.UI.Page
    {
        public JogoBO _jogoBO;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CarregarJogosNoRepeater();
                Deslogar();
            }
        }

        private void CarregarJogosNoRepeater()
        {
            _jogoBO = new JogoBO();

            RepeaterJogos.DataSource = _jogoBO.ObterTodosOsJogos();
            RepeaterJogos.DataBind();
        }

        private void Deslogar()
        {
            if(!string.IsNullOrEmpty(Page.Request.QueryString["logout"]))
            {
                FormsAuthentication.SignOut();
                Session.Abandon();

                //FormsAuthentication.RedirectToLoginPage();
                Response.Redirect("/Autenticacao/Login.aspx");
            }
        }
    }
}