using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL
{
    public class GeneroBO
    {
        private GeneroDAO _generoDAO;

        public List<Genero> ObterTodosOsGeneros()
        {
            _generoDAO = new GeneroDAO();

            return _generoDAO.ObterTodosOsGeneros();
        }
    }
}
