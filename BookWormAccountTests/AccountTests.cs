using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookWormAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWormAccount.Tests
{
    [TestClass()]
    public class AccountTests
    {
        private Account acc;

        [TestInitialize]
        public void CreateDefaultAccount()
        {
            acc = new Account("L Homer");
        }

        // Testing DepositBooks
        [TestMethod()]
        [DataRow(5)]
        [DataRow(3)]
        [TestCategory("DepositBooks")]
        public void DepositBooks_APositiveAmount_AddToBooks(int amount)
        {
            acc.DepositBooks(amount);

            Assert.AreEqual(amount, acc.Books);
        }

        [TestMethod()]
        [TestCategory("DepositBooks")]
        public void DepositBooks_APositiveAmount_ReturnsUpdatedBooks()
        {
            // AAA - Arrange Act Assert
            // Arrange 
            int depositBooks = 3;
            int expectedReturn = 3;

            // Act
            int returnValue = acc.DepositBooks(depositBooks);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-3)]
        [DataRow(0)]
        [TestCategory("DepositBooks")]
        public void DepositBooks_ZeroOrLess_ThrowsArgumentException(int invalidAmount)
        {
            // Arrange
            // Nothing to add

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.DepositBooks(invalidAmount));
        }

        // Testing DepositHours
        [TestMethod()]
        [DataRow(3)]
        [DataRow(7)]
        [TestCategory("DepositHours")]
        public void DepositHours_APositiveAmount_AddToHours(int amount)
        {
            acc.DepositHours(amount);

            Assert.AreEqual(amount, acc.Hours);
        }

        [TestMethod()]
        [TestCategory("DepositHours")]
        public void DepositHours_APositiveAmount_ReturnsUpdatedBooks()
        {
            // AAA - Arrange Act Assert
            // Arrange 
            int depositHours = 1;
            int expectedReturn = 1;

            // Act
            int returnValue = acc.DepositHours(depositHours);

            // Assert
            Assert.AreEqual(expectedReturn, returnValue);
        }

        [TestMethod]
        [DataRow(-4)]
        [DataRow(-6)]
        [TestCategory("DepositHours")]
        public void DepositHours_ZeroOrLess_ThrowsArgumentException(int invalidAmount)
        {
            // Arrange
            // Nothing to add

            // Assert => Act
            Assert.ThrowsException<ArgumentOutOfRangeException>
                (() => acc.DepositHours(invalidAmount));
        }

        [TestMethod]
        public void UserName_SetAsNull_ThrowsArgumentNullException()
        {
            Assert.ThrowsException<ArgumentNullException>(() => acc.UserName = null);
        }

        [TestMethod]
        public void UserName_SetAsWhiteSpaceOrEmptyString_ThrowsArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => acc.UserName = String.Empty);
            Assert.ThrowsException<ArgumentException>(() => acc.UserName = "   ");
        }

        [TestMethod]
        [DataRow("Matthew")]
        [DataRow("Jack Brown")]
        [DataRow("Marcus Gold Thranzes")]
        public void UserName_SetAsUpTo20Characters_SetsSuccessfully(string userName)
        {
            acc.UserName = userName;
            Assert.AreEqual(userName, acc.UserName);
        }

        [TestMethod]
        [DataRow("Jacob the 4th")]
        [DataRow("Marcus Gold Threanzesi")]
        [DataRow("#$%$")]
        public void UserName_InvalidUserName_ThrowsArgumentException(string userName)
        {
            Assert.ThrowsException<ArgumentException>(() => acc.UserName = userName);
        }
    }
}