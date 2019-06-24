using BibliotecaGames.BLL.Exceptions;
using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL.Autenticacao
{
    public class LoginBO
    {
        private UsuarioDAO _usuarioDAO;

        public Usuario ObterUsuarioParaLogar(string nomeUsuario, string senha)
        {
            _usuarioDAO = new UsuarioDAO();

            var usuario = _usuarioDAO.ObterUsuarioPeloUsuarioESenha(nomeUsuario, senha);

            if (usuario == null)
                throw new UsuarioNaoCadastradoException();
            else
                return usuario;
        }
    }
}
