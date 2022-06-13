using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.PresentationTest
{
    [TestClass]
    public class RentBookViewModelTest
    {
        private IDataRepository? dataRepository;
        private IService? service;

        [TestMethod]
        public void RentInitializeTest()
        {
            RentBookViewModel rbVM = new RentBookViewModel(service);
            Assert.IsNotNull(rbVM.RentBookCommand);

            Assert.IsTrue(rbVM.RentBookCommand.CanExecute(null));
        }
    }
}
