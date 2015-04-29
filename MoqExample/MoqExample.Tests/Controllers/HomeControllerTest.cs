using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoqExample;
using MoqExample.Controllers;
using Moq;
using MoqExample.Data.Interfaces;
using Ploeh.AutoFixture;
using MoqExample.Data.Types;
using System;

namespace MoqExample.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private Mock<IDataAccessRepository> _dataAccessRepository;
        private Fixture _fixture = new Fixture();

        [TestMethod]
        public void GetProjectCount_TestIfTheProjectCountIsValid()
        {
            int projectId = 3;
            int noOfExpectedProjects = 123;

            _dataAccessRepository = new Mock<IDataAccessRepository>();
            _dataAccessRepository.Setup(x => x.GetNoOfProjects(It.Is<int>(p => p == projectId))).Returns(noOfExpectedProjects);

            HomeController controller = new HomeController(_dataAccessRepository.Object);


            var actualProjectCount = controller.GetProjectCount(projectId);

            Assert.AreEqual(noOfExpectedProjects, actualProjectCount);
        }

        [TestMethod]
        public void GetProjectCount_TestIfTheProjectCountIsValidAndCalledOnlyOnce()
        {
            int projectId = 3;
            int noOfExpectedProjects = 123;

            _dataAccessRepository = new Mock<IDataAccessRepository>();
            _dataAccessRepository.Setup(x => x.GetNoOfProjects(It.Is<int>(p => p == projectId))).Returns(noOfExpectedProjects);

            HomeController controller = new HomeController(_dataAccessRepository.Object);


            var actualProjectCount = controller.GetProjectCount(projectId);

            Assert.AreEqual(noOfExpectedProjects, actualProjectCount);
            _dataAccessRepository.Verify(x => x.GetNoOfProjects(It.Is<int>(p => p == projectId)), Times.Once);
        }

        [TestMethod]
        public void CheckTheSampleModel_CheckIfReturedModelIsValid()
        {
            var inputComplexType = _fixture
                .Build<SampleComplexType>()
                .Without(x => x.GuidProperty)
                .With(k=>k.IntProperty, (new Random()).Next())
                .Create();

            _fixture.Register<Guid>(() => new Guid("11111111-90F8-4A03-AA16-CEC2911B1111"));
            var listOfInputComplexTypes = _fixture.CreateMany<SampleComplexType>(5);
            var listOfGuids = _fixture.CreateMany<Guid>(5);

            _dataAccessRepository = new Mock<IDataAccessRepository>();
            _dataAccessRepository.Setup(x => x.CheckTheComplexType(It.Is<SampleComplexType>(s => s == inputComplexType))).Returns(true);
            HomeController controller = new HomeController(_dataAccessRepository.Object);

            Assert.IsTrue(controller.CheckTheSampleModel(inputComplexType));
            _dataAccessRepository.VerifyAll();
        }

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void CheckTheSampleModel_ExceptionIsBeingThrown()
        {
            _dataAccessRepository = new Mock<IDataAccessRepository>();
            _dataAccessRepository.Setup(x => x.CheckTheComplexType(It.IsAny<SampleComplexType>())).Throws(new NotSupportedException("test"));

            HomeController controller = new HomeController(_dataAccessRepository.Object);
            controller.CheckTheSampleModel(_fixture.Create<SampleComplexType>());
        }
    }
}
