using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleTask;

namespace SimpleTaskTests
{
    [TestClass]
    public class TaskTest
    {
        [TestMethod]
        public void TestExceptionCase()
        {
            BankAccount bank = new BankAccount("Amanda", 0);
            try
            {
                bank.Debit(3);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, "amount <= 0 or amount > balance");
                return;
            }
            catch (Exception e)
            {
                StringAssert.Contains(e.Message, "balance = 0");
                return;
            }
            Assert.Fail("Failed exception");
        }
        
        [TestMethod]
        public void TestCreditCase()
        {
            BankAccount bank = new BankAccount("Amanda", 3);
            bank.Credit(3);
            Assert.AreEqual(6, bank.Balance);
        }

        [TestMethod]
        public void TestDebitCase()
        {
            BankAccount bank = new BankAccount("Amanda", 3);
            bank.Debit(3);
            Assert.AreEqual(0, bank.Balance);
        }
    }
}
