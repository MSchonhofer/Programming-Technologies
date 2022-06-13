using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.ViewModel;

namespace Tests.PresentationTest
{
    [TestClass]
    public class ReturnBookViewModelTest
    {
        private IDataRepository? dataRepository;
        private IService? service;

        [TestMethod]

        public void ReturnInitializeTest()
        {
            ReturnBookViewModel rbVM = new ReturnBookViewModel(service);
            Assert.IsNotNull(rbVM.ReturnBookCommand);

            Assert.IsTrue(rbVM.ReturnBookCommand.CanExecute(null));
        }
    }
}
