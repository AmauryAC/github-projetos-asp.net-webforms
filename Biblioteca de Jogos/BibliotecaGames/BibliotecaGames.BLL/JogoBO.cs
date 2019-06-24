using BibliotecaGames.BLL.Exceptions;
using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL
{
    public class JogoBO
    {
        private JogoDAO _jogoDAO;

        public List<Jogo> ObterTodosOsJogos()
        {
            _jogoDAO = new JogoDAO();

            return _jogoDAO.ObterTodosOsJogos();
        }

        public Jogo ObterJogoPeloId(int id)
        {
            _jogoDAO = new JogoDAO();

            var jogo = _jogoDAO.ObterJogoPeloId(id);

            if (jogo == null)
                throw new JogoNaoEncontradoException();

            return jogo;
        }

        public void InserirNovoJogo(Jogo jogo)
        {
            ValidarJogo(jogo);

            _jogoDAO = new JogoDAO();

            var linhasAfetadas = _jogoDAO.InserirJogo(jogo);

            if(linhasAfetadas == 0)
            {
                throw new JogoNaoCadastradoException();
            }
        }

        public void AlterarJogo(Jogo jogo)
        {
            ValidarJogo(jogo);

            _jogoDAO = new JogoDAO();

            var linhasAfetadas = _jogoDAO.AlterarJogo(jogo);

            if (linhasAfetadas == 0)
            {
                throw new JogoNaoAlteradoException();
            }
        }

        public void ValidarJogo(Jogo jogo)
        {
            if(string.IsNullOrWhiteSpace(jogo.Titulo) || jogo.IdEditor == 0 || jogo.IdGenero == 0)
            {
                throw new JogoInvalidoException();
            }
        }
    }
}
