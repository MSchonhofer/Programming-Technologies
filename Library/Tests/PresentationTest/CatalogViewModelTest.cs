using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation;
using Presentation.ViewModel;
using Service.API;
using Data.API;

namespace Tests.PresentationTest
{
    [TestClass]
    public class CatalogViewModelTest
    {
        private IDataRepository? dataRepository;
        private IService? service;

        [TestMethod]

        public void CatalogInitializeTest()
        {
            
            CatalogViewModel cVM = new CatalogViewModel(service);
            Assert.IsNotNull(cVM.AddCatalogCommand);
            Assert.IsNotNull(cVM.UpdateCatalogByIndexCommand);
            Assert.IsNotNull(cVM.UpdateCatalogByTitleCommand);
            Assert.IsNotNull(cVM.DeleteCatalogByIndexCommand);
            Assert.IsNotNull(cVM.DeleteCatalogByTitleCommand);

            Assert.IsTrue(cVM.AddCatalogCommand.CanExecute(null));
            Assert.IsTrue(cVM.UpdateCatalogByIndexCommand.CanExecute(null));
            Assert.IsTrue(cVM.DeleteCatalogByIndexCommand.CanExecute(null));
            Assert.IsTrue(cVM.DeleteCatalogByTitleCommand.CanExecute(null));
        }
    }
}
