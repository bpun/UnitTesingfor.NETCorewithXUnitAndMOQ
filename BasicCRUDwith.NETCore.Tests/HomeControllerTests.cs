using BasicCRUDwith.NETCore.Controllers;
using BasicCRUDwith.NETCore.DbContexts;
using BasicCRUDwith.NETCore.Models;
using BasicCRUDwith.NETCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BasicCRUDwith.NETCore.Tests
{
    public class HomeControllerTests
    {
        private HomeController _homeController;
        private IBaseRepository<Student> _iRepository;

        [Fact]
        public void CreateActionReturnsCreateView()
        {
             _homeController = new HomeController(_iRepository);
            var result = _homeController.Create() as ViewResult;

          
            Assert.Equal("Create", result.ViewName);
        }


        [Fact]
        public void TestEditViewData()
        {
            var mock = new Mock<IBaseRepository<Student>>();
            mock
                 .Setup(x => x.GetById(3))
                 .Returns(new Student
                 {
                     Name = "Shyam",
                     Contact = "0909090333343",
                     Address = "Ktm"
                 });
          
            _homeController = new HomeController(mock.Object);
            var data= _homeController.Edit(3) as ViewResult;
            var result = (Student)data.Model;

            Assert.Equal("Shyam",result.Name);           
        }

        [Fact]
        public void CreateActionPostMethod()
        {
            var student = new Student
            {
                Name = "Mario",
                Contact = "09867356353",
                Address = "Pokhara"
            };
            var mock = new Mock<IBaseRepository<Student>>();
            mock
                 .Setup(x => x.Add(student));

            _homeController = new HomeController(mock.Object);
            var data = _homeController.Create(student) as ViewResult;

            Assert.Equal("Index", data.ViewName);
        }

        [Fact]
        public void IndexActionReturnsStudentList()
        {
            var students = GetStudentList();
            var mock = new Mock<IBaseRepository<Student>>();
            mock
                 .Setup(x => x.GetAll())
                 .Returns(students);

            _homeController = new HomeController(mock.Object);
            var data = _homeController.Index() as ViewResult;
            var result = (List<Student>) data.Model;

            Assert.Equal(4, result.Count);
        }

        [Fact]
        public void DeleteActionReturnsIndexViewIfDeleted()
        {
            var student = new Student
            {
                ID = 3,
                Name = "Mario",
                Contact = "09867356353",
                Address = "Pokhara"
            };
            var mock = new Mock<IBaseRepository<Student>>();
            mock
                 .Setup(x => x.Delete(student));

            _homeController = new HomeController(mock.Object);
            var data = _homeController.Create(student) as ViewResult;

            Assert.Equal("Index", data.ViewName);
        }

        private IQueryable<Student> GetStudentList()
        {
            var students = new List<Student>
            {
                new Student
                {
                     Name = "Mario",
                     Contact = "09867356353",
                     Address = "Pokhara"
                },
                new Student
                {
                     Name = "Sonia",
                     Contact = "09867356353",
                     Address = "Chitwan"
                },
                new Student
                {
                     Name = "Rosia",
                     Contact = "09867356353",
                     Address = "Pokhara"
                },
                new Student
                {
                     Name = "Rohan",
                     Contact = "09867356353",
                     Address = "Baglung"
                }
            };
            return students.AsQueryable();
        }
    }
}
