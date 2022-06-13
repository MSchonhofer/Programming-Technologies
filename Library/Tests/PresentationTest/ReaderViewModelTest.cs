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
    public class ReaderViewModelTest
    {
        private IDataRepository? dataRepository;
        private IService? service;

        [TestMethod]

        public void ReaderInitializeTest()
        {
            
            ReaderViewModel rVM = new ReaderViewModel(service);
            Assert.IsNotNull(rVM.AddReaderCommand);
            Assert.IsNotNull(rVM.UpdateReaderCommand);
            Assert.IsNotNull(rVM.DeleteReaderCommand);

            Assert.IsTrue(rVM.AddReaderCommand.CanExecute(null));
            Assert.IsTrue(rVM.UpdateReaderCommand.CanExecute(null));
            Assert.IsTrue(rVM.DeleteReaderCommand.CanExecute(null));
        }
    }
}
