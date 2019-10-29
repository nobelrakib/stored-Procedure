using System.Collections.Generic;
using System.Text;
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
    class IssueBookServiceTest
    {
        private IIssueBookService _IssueBookService;
        private IBookService _BookService;
        private IStudentService _StudentService;
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
        public void IssueBook__WhentStudentandBookIsValid__itWillbeAdded()
        {
            //arrange
            var issuedate = DateTime.Now;
            //issuedate = issuedate.AddDays(-8);
            //var expectedfineamount = 10;
            var expectedcopycount = 0;
            var studentbook = new StudentBook
            {
                StudentId = 5,
                bookbarcode = "bjit",
                IssueDate = issuedate,
                //ReturneDate=DateTime.Now
            };
            var book = new Book
            {
                Author = "subeen",
                Barcode = "bjit",
                Edition = "4th",
                Title = "UnitTEsting",
                CopyCount = 1
            };
            var student = new Student
            {
                StudentId = 5,
                Fine = 0,
            };

            var bookrepositorymock = _mock.Mock<IBookRepository>();
            var studentbookrepositorymock = _mock.Mock<IStudentBookRepository>();
            var studentrepositorymock = _mock.Mock<IStudentRepository>();
            var UnitOfWorkMock = _mock.Mock<Iunitofwork>();

            bookrepositorymock.Setup(x => x.GetBookByBarcode(studentbook.bookbarcode))
                .Returns(book);
            studentrepositorymock.Setup(x => x.GetStudentById(studentbook.StudentId))
                .Returns(student);

            studentbookrepositorymock.Setup(x => x.IssueBook(studentbook.StudentId, studentbook.bookbarcode, student, book));
                

            UnitOfWorkMock.Setup(x => x._StudentBookRepository).Returns(studentbookrepositorymock.Object);
            UnitOfWorkMock.Setup(x => x._BookRepository).Returns(bookrepositorymock.Object);
            UnitOfWorkMock.Setup(x => x._StudentRepository).Returns(studentrepositorymock.Object);
            _IssueBookService = _mock.Create<IssueBookService>(new TypedParameter(typeof(Iunitofwork),
                UnitOfWorkMock.Object));
            _BookService = _mock.Create<BookService>(new TypedParameter(typeof(Iunitofwork),
               UnitOfWorkMock.Object));
            _StudentService = _mock.Create<StudentService>(new TypedParameter(typeof(Iunitofwork),
               UnitOfWorkMock.Object));
            //act
            _IssueBookService.BookIssue(studentbook.StudentId, studentbook.bookbarcode);
            var returnbook = _BookService.GetBookInfo(book.Barcode);
            var returnstudent = _StudentService.GetStudentInfo(student.StudentId);
            //assert
            returnbook.CopyCount.ShouldBe(expectedcopycount);
           // returnstudent.Fine.ShouldBe(expectedfineamount);
            bookrepositorymock.VerifyAll();
            studentbookrepositorymock.VerifyAll();
            studentrepositorymock.VerifyAll();
        }

    }
}
