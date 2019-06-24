using BibliotecaGames.DAL;
using BibliotecaGames.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGames.BLL
{
    public class EditorBO
    {
        private EditorDAO _editorDAO;

        public List<Editor> ObterTodosOsEditores()
        {
            _editorDAO = new EditorDAO();

            return _editorDAO.ObterTodosOsEditores();
        }
    }
}
