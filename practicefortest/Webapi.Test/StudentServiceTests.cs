using NUnit.Framework;
using System.Diagnostics.CodeAnalysis;
using Autofac.Extras.Moq;
using WebApi.Store.Services;
using WebApi.Store.Repositories;
using WebApi.Core;
using WebApi.Store;
using Autofac;
using Shouldly;
using System;

namespace Webapi.Test
{
    [TestFixture, ExcludeFromCodeCoverage]
    public class StudentServiceTests
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
            _mock = AutoMock.GetLoose();
        }
        [OneTimeTearDown]
        public void TestCleanUp()
        {
            _mock?.Dispose();
        }

        [Test]
        public void InsertStudent__WhenYouAddStudent__itWillbeAdded ()
        {
            //arrange
            var student = new Student
            {
                StudentId = 5,
                Name = "rakib",
                Fine = 90
            };
            int id = 90;
            string name = "rakib";
            var studentrepositorymock = _mock.Mock<IStudentRepository>();
            var UnitOfWorkMock = _mock.Mock<Iunitofwork>();

            studentrepositorymock.Setup(x => x.AddStudent(id, name));
            UnitOfWorkMock.Setup(x => x._StudentRepository).Returns(studentrepositorymock.Object);
            UnitOfWorkMock.Setup(x => x.Save());
            _Studentservices = _mock.Create<StudentService>(new TypedParameter(typeof(Iunitofwork),
                UnitOfWorkMock.Object));
            //Act
            _Studentservices.InsertStudent(id, name);
             //assert
            studentrepositorymock.VerifyAll();
            UnitOfWorkMock.VerifyAll();
        }
        [Test]
        public void GetStudentInfo__WhenStudentIsNull__ThrowInvalidOperationException()
        {
            //arrange
            int id = 5;
            //var student = new Student
            //{
            //    StudentId = 5,
            //    Name = "rakib",
            //    Fine = 90
            //};
            Student student = null;
            var studentrepositorymock = _mock.Mock<IStudentRepository>();
            var UnitOfWorkMock = _mock.Mock<Iunitofwork>();
            studentrepositorymock.Setup(x => x.GetStudentById(id)).Returns(student);
            UnitOfWorkMock.Setup(x => x._StudentRepository).Returns(studentrepositorymock.Object);
            _Studentservices = _mock.Create<StudentService>(new TypedParameter(typeof(Iunitofwork),
               UnitOfWorkMock.Object));

            // Act
            Should.Throw<InvalidOperationException>(() =>_Studentservices.GetStudentInfo(id));
            //Assert
            studentrepositorymock.VerifyAll();
            UnitOfWorkMock.VerifyAll();

        }
        [Test]
        public void GetStudentInfo__WhenStudentIsNotNull__ShowStudent()
        {
            //arrange
            int id = 5;
            var student = new Student
            {
                StudentId = 5,
                Name = "rakib",
                Fine = 90
            };
            //Student student = null;
            var studentrepositorymock = _mock.Mock<IStudentRepository>();
            var UnitOfWorkMock = _mock.Mock<Iunitofwork>();
            studentrepositorymock.Setup(x => x.GetStudentById(id)).Returns(student);
            UnitOfWorkMock.Setup(x => x._StudentRepository).Returns(studentrepositorymock.Object);
            _Studentservices = _mock.Create<StudentService>(new TypedParameter(typeof(Iunitofwork),
               UnitOfWorkMock.Object));
            
            var studentTest= _Studentservices.GetStudentInfo(id);
            //Assert
            studentTest.ShouldBe(student);
            studentrepositorymock.VerifyAll();
            UnitOfWorkMock.VerifyAll();

        }
    }
}