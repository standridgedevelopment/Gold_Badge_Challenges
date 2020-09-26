using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cage
{
    class MenuRepository
    {
        protected readonly List<MenuItem> _menu = new List<MenuItem>();

        public void AddMenuItem(MenuItem item)
        {
            _menu.Add(item);
        }

        public List<MenuItem> GetMenu()
        {
            return _menu;
        }

        public bool DeleteMenuItem(MenuItem item)
        {
            bool deleteResult = _menu.Remove(item);
            return deleteResult;
        }

        /*public List<Entree> GetAllEntrees()
        {
            List<Entree> allEntrees = new List<Entree>();
            //pull one item and see if it is an Entree
            foreach (MenuItem entree in _menu)
            {
                if (entree is Entree)
                {
                    allEntrees.Add((Entree)entree);
                }
                //return allEntrees;
            }
            return allEntrees;
        }*/

    }
}
