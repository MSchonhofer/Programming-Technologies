using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation.ViewModel;
using Presentation.API;


namespace TestViewModel
{
    [TestClass]
    public class ViewModelTest
    {
        private IModel model;

        [TestMethod]
        public void ViewModelInitializeRelayCommandTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsNotNull(vm.AddActionCommand);
            Assert.IsNotNull(vm.AddCatalogCommand);
            Assert.IsNotNull(vm.AddReaderCommand);
            Assert.IsNotNull(vm.DeleteReaderCommand);
            Assert.IsNotNull(vm.DeleteCatalogCommand);
            Assert.IsNotNull(vm.UpdateCatalogCommand);
            Assert.IsNotNull (vm.UpdateReaderCommand);
        }
        [TestMethod]
        public void AddActionCommandWindowTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsTrue(vm.AddActionCommand.CanExecute(null));
        }
        [TestMethod]
        public void AddCatalogCommandWindowTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsTrue(vm.AddCatalogCommand.CanExecute(null));
        }
        [TestMethod]
        public void AddReaderCommandWindowTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsTrue(vm.AddReaderCommand.CanExecute(null));
        }
        [TestMethod]
        public void UpdateCatalogCommandWindowTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsTrue(vm.UpdateCatalogCommand.CanExecute(null));
        }
        [TestMethod]
        public void UpdateReaderCommandWindowTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsTrue(vm.UpdateReaderCommand.CanExecute(null));
        }
        [TestMethod]
        public void DeleteCatalogCommandWindowTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsTrue(vm.DeleteCatalogCommand.CanExecute(null));
        }
        [TestMethod]
        public void DeleteReaderCommandWindowTest()
        {
            ViewModel vm = new ViewModel(model);
            Assert.IsTrue(vm.DeleteReaderCommand.CanExecute(null));
        }
    }
}
