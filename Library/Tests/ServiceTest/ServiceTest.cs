using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;
using NSubstitute;
using Service.API;

namespace Tests.ServiceTest
{
    [TestClass]
    public class ServiceTest
    {
        private IDataRepository dataRepository = Substitute.For<IDataRepository>();

        [TestMethod]

        public void TestCatalogs()
        {
            IService service = IService.CreateService(dataRepository);
            service.AddCatalog(1, "Kochanowski", "Treny");
            dataRepository.Received(1).AddCatalog(1, "Kochanowski", "Treny");
            service.UpdateCatalog(1, "Sienkiewicz", "W pustyni i w puszczy");
            dataRepository.Received(1).UpdateCatalog(1, "Sienkiewicz", "W pustyni i w puszczy");
            service.DeleteCatalog(1);
            dataRepository.Received(1).DeleteCatalog(1);
        }
        [TestMethod]
        public void TestReaders()
        {
            IService service = IService.CreateService(dataRepository);
            service.AddReader(1, "Jan", "Kowalski");
            dataRepository.Received(1).AddReader(1, "Jan", "Kowalski");
            service.UpdateReader(1, "Marian", "Nowak");
            dataRepository.Received(1).UpdateReader(1, "Marian", "Nowak");
            service.DeleteReader(1);
            dataRepository.Received(1).DeleteReader(1);
        }
        [TestMethod]
        public void TestActions()
        {
            IService service = IService.CreateService(dataRepository);
            service.AddAction(1, 1, 1);
            dataRepository.Received(1).AddAction(1, 1, 1);
        }
    }
}
