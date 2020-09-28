using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe
{
    public class MenuRepository
    {
        protected readonly List<MenuItem> _menu = new List<MenuItem>();

        public bool AddMenuItem(MenuItem item)
        {
            int _startingCount = _menu.Count;
            _menu.Add(item);
            bool wasAdded = (_menu.Count > _startingCount) ? true : false;
            return wasAdded;
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
