using System;
using System.Collections.Generic;
using DriverManager.DataProviders.Interfaces;
using DriverManager.Enums;
using DriverManager.Models;
using DriverManager.Models.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DriverManager.UnitTests
{
    [TestFixture]
    public class DriverModelTestFixture
    {
        private const int Success = 0;
        private const int NullParameter = 1;
        private const int InvalidParameters = 2;

        #region GetAllDrivers

        [Test]
        public void GetAllDriversValid()
        {
            //Arrange
            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.GetAll()
                .Returns(new List<IDriver>
                {
                    new Driver{FirstName = "Peter",LastName = "Davidson"}
                });

            //Act
            var driverListViewModel = new DriverModel(driverDataProvider);
            var result = driverListViewModel.GetAllDrivers();

            //Assert
            Assert.AreEqual(1, result.Count);
        }

        #endregion

        #region GetDriverByName

        [Test]
        public void GetDriverByNameValid()
        {
            IDriver driverToFind = new Driver
                                       {
                                           FirstName = "Dave",
                                           LastName = "Grayson",
                                       };

            //Arrange
            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.GetByName(driverToFind.FullName).Returns(driverToFind);

            //Act
            var driverListViewModel = new DriverModel(driverDataProvider);
            var result = driverListViewModel.GetDriverByName(driverToFind.FullName);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(driverToFind.FirstName, result.FirstName);
            Assert.AreEqual(driverToFind.LastName, result.LastName);
        }

        [Test]
        public void GetDriverByNameEmptyName()
        {
            IDriver result = null;
            //Arrange
            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.GetByName(Arg.Any<string>()).Returns(x => null);

            //Act
            var driverListViewModel = new DriverModel(driverDataProvider);

            try
            {
                result = driverListViewModel.GetDriverByName(string.Empty);
                Assert.Fail("Exception should be thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is ArgumentException);
                Assert.AreEqual(ex.Message, "Name Cannot Be Empty");
            }

            //Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetDriverByNameUnknownDriver()
        {
            IDriver result = null;
            IDriver driverToFind = new Driver
            {
                FirstName = "Dave",
                LastName = "Grayson",
            };
            //Arrange
            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.GetByName(driverToFind.FullName).Returns(x => null);

            //Act
            var driverListViewModel = new DriverModel(driverDataProvider);

            result = driverListViewModel.GetDriverByName(driverToFind.FullName);

            //Assert
            Assert.IsNull(result);
        }

        #endregion

        #region GetDriverById

        [Test]
        public void GetDriverByIDValid()
        {
            IDriver driverToFind = new Driver
            {
                ID = 1,
                FirstName = "Dave",
                LastName = "Grayson",
            };

            //Arrange
            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.GetById(driverToFind.ID).Returns(driverToFind);

            //Act
            var driverListViewModel = new DriverModel(driverDataProvider);
            var result = driverListViewModel.GetDriverDetails(driverToFind.ID);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(driverToFind.ID, result.ID);
            Assert.AreEqual(driverToFind.FirstName, result.FirstName);
            Assert.AreEqual(driverToFind.LastName, result.LastName);
        }

        #endregion

        #region SaveDriver
        [Test]
        public void SaveDriverValid()
        {
            //Arrange
            IDriver driverToSave = new Driver
            {
                ID = 1,
                FirstName = "Dave",
                LastName = "Grayson",
                Country = "Scotland",
                CardNumber = "098765789"
            };

            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.Save(driverToSave).Returns(OpResult.Success);

            //Act
            var driverModel = new DriverModel(driverDataProvider);
            OpResult result = driverModel.SaveDriver(driverToSave);

            //Assert
            Assert.AreEqual(OpResult.Success, result);
        }

        [Test]
        public void SaveDriverInvalidNullDriver()
        {
            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.Save(null).Returns(OpResult.NullParameter);

            //Act
            var driverModel = new DriverModel(driverDataProvider);
            OpResult result = driverModel.SaveDriver(null);

            //Assert
            Assert.AreEqual(OpResult.NullParameter, result);
        }

        [Test]
        public void SaveDriverInvalidDriverAlreadyExists()
        {
            IDriver driverToSave = new Driver
            {
                ID = 1,
                FirstName = "Dave",
                LastName = "Grayson",
                Country = "Scotland",
                CardNumber = "098765789"
            };

            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.Save(driverToSave).Returns(OpResult.ObjectExists);

            //Act
            var driverModel = new DriverModel(driverDataProvider);
            OpResult result = driverModel.SaveDriver(driverToSave);

            //Assert
            Assert.AreEqual(OpResult.ObjectExists, result);
        }

        [Test]
        public void SaveDriverInvalidDriverDetails()
        {
            IDriver driverToSave = new Driver
            {
                ID = 1,
                FirstName = string.Empty,
                LastName = "Grayson",
                Country = "Scotland",
                CardNumber = "098765789"
            };

            var driverDataProvider = Substitute.For<IDriverDataProvider>();
            driverDataProvider.Save(driverToSave).Returns(OpResult.Success);

            //Act
            var driverModel = new DriverModel(driverDataProvider);
            OpResult result = driverModel.SaveDriver(driverToSave);

            //Assert
            Assert.AreEqual(OpResult.InvalidParameters, result);
        }
        #endregion

        #region DeleteDriver
        [Test]
        public void DeleteDriverValid()
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteDriverInvalidNullDriver()
        {
            Assert.Fail();
        }

        [Test]
        public void DeleteDriverInvalidDriverNotExists()
        {
            Assert.Fail();
        }
        #endregion

        #region UpdateDriver
        [Test]
        public void UpdateDriverValid()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateDriverInvalidNullDriver()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateDriverInvalidDriverNotExists()
        {
            Assert.Fail();
        }

        [Test]
        public void UpdateDriverInvalidDriverDetails()
        {
            Assert.Fail();
        }
        #endregion

    }
}
