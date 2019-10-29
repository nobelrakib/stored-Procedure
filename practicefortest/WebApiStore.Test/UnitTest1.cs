using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using Autofac.Extras.Moq;
using WebApi.Store.Services;
using WebApi.Store.Repositories;
using WebApi.Core;

namespace WebApiStore.Test
{
    [TestFixture,ExcludeFromCodeCoverage]
    public class Tests
    {
        private IStudentService _Studentservices;
        private AutoMock _mock;
        [SetUp]
        public void ClassSetup()
        {
            _mock = AutoMock.GetLoose();
        }
        [TearDown]
        public void ClassCleanUp()
        {
            _mock?.Dispose();
        }
        [OneTimeSetUp]
        public void TestSetup()
        {
            //var student = new Student
            //{
            //    StudentId = 5,
            //    Name = "Camera",
            //    Fine = 90
            //};

            //var studentrepository = _mock.Mock<IStudentRepository>();
            //var UnitOfWorkMock = _mock.Mock<>();

        }
        [OneTimeTearDown]
        public void TestCleanUp()
        {

        }

        [Test]
        public void Test1()
        {
           // Assert.Pass();
        }
        [Test]
        public void Test2()
        {
            Assert.Pass();
        }
    }
}