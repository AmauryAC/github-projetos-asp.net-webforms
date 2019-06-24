using BibliotecaGames.BLL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BibliotecaGames.Jogos
{
    public partial class CadastroEdicaoJogo : System.Web.UI.Page
    {
        private EditorBO _editorBO;
        private GeneroBO _generoBO;
        private JogoBO _jogoBO;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                CarregarEditoresNaCombo();
                CarregarGenerosNaCombo();

                if(EstaEmModoEdicao())
                {
                    CarregarDadosParaEdicao();
                }
            }

            btnGravar.Enabled = true;
        }

        protected void btnGravar_Click(object sender, EventArgs e)
        {
            _jogoBO = new JogoBO();

            //var jogo = new Jogo();

            var jogo = ObterModeloPreenchido();

            try
            {
                //jogo.Imagem = DateTime.Now.ToString("yyyyMMddhhmmss") + fupImage.FileName;
                jogo.Imagem = GravarImagemNoDisco();
            }
            catch(Exception)
            {
                lblMensagem.Text = "Ocorreu um erro ao salvar a imagem";
            }

            try
            {
                var mensagemDeSucesso = "";

                if (EstaEmModoEdicao())
                {
                    jogo.Id = ObterIdDoJogo();

                    _jogoBO.AlterarJogo(jogo);

                    mensagemDeSucesso = "Jogo alterado com sucesso";
                }
                else
                {
                    _jogoBO.InserirNovoJogo(jogo);

                    mensagemDeSucesso = "Jogo cadastrado com sucesso";
                }

                lblMensagem.ForeColor = System.Drawing.Color.Green;
                lblMensagem.Text = mensagemDeSucesso;

                btnGravar.Enabled = false;
            }
            catch (Exception)
            {
                lblMensagem.ForeColor = System.Drawing.Color.Red;
                lblMensagem.Text = "Ocorreu um erro ao gravar o jogo";
            }
        }

        private Jogo ObterModeloPreenchido()
        {
            var jogo = new Jogo();

            //jogo.Id = ObterIdDoJogo();
            jogo.Titulo = txtTitulo.Text;
            jogo.IdEditor = Convert.ToInt32(ddlEditor.SelectedValue);
            jogo.IdGenero = Convert.ToInt32(ddlGenero.SelectedValue);
            jogo.ValorPago = String.IsNullOrWhiteSpace(txtValorPago.Text) ? (double?)null : Convert.ToDouble(txtValorPago.Text);
            jogo.DataCompra = String.IsNullOrWhiteSpace(txtDataCompra.Text) ? (DateTime?)null : Convert.ToDateTime(txtDataCompra.Text);

            return jogo;
        }

        private string GravarImagemNoDisco()
        {
            if(fupImage.HasFile)
            {
                try
                {
                    var caminho = $"{AppDomain.CurrentDomain.BaseDirectory}Content\\ImagensJogos\\";
                    var fileName = fupImage.FileName;

                    fupImage.SaveAs($"{caminho}{fileName}");

                    return fileName;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return null;
            }
        }

        private void CarregarEditoresNaCombo()
        {
            _editorBO = new EditorBO();

            var editores = _editorBO.ObterTodosOsEditores();

            ddlEditor.DataSource = editores;
            ddlEditor.DataBind();
        }

        private void CarregarGenerosNaCombo()
        {
            _generoBO = new GeneroBO();

            var generos = _generoBO.ObterTodosOsGeneros();

            ddlGenero.DataSource = generos;
            ddlGenero.DataBind();
        }

        private void CarregarDadosParaEdicao()
        {
            _jogoBO = new JogoBO();

            var id = ObterIdDoJogo();
            var jogo = _jogoBO.ObterJogoPeloId(id);

            txtTitulo.Text = jogo.Titulo;
            txtValorPago.Text = jogo.ValorPago.ToString();
            txtDataCompra.Text = jogo.DataCompra.HasValue ? jogo.DataCompra.Value.ToString("yyyy-MM-dd") : string.Empty;
            ddlEditor.SelectedValue = jogo.IdEditor.ToString();
            ddlGenero.SelectedValue = jogo.IdGenero.ToString();
        }

        private int ObterIdDoJogo()
        {
            var id = 0;
            var idQueryString = Request.QueryString["id"];

            if (int.TryParse(idQueryString, out id))
            {
                if (id <= 0)
                    throw new Exception("Id Inválido");

                return id;
            }
            else
            {
                throw new Exception("Id Inválido");
            }
        }

        private bool EstaEmModoEdicao()
        {
            return Request.QueryString.AllKeys.Contains("id");
        }
    }
}