using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Komodo_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Komodo_Cafe_Tests
{
    [TestClass]
    public class MethodTests
    {
        [TestMethod]
        public void AddMenuToItemShouldReturnTrue()
        {
            MenuRepository _menu = new MenuRepository();
            MenuItem item = new MenuItem();
            bool testResult = _menu.AddMenuItem(item);
            Console.WriteLine(testResult);
        }
        [TestMethod]
        public void DeleteMenuItemShouldReturnTrue()
        {
            var _menu = new MenuRepository();
            MenuItem item = new MenuItem("Chicken Tenders", "8 tenders and 2 sides", 15, 8);
            _menu.AddMenuItem(item);
            bool testResult = _menu.DeleteMenuItem(item);
            Console.WriteLine(testResult);
        }

    }
}
