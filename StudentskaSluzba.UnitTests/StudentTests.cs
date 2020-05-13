using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentskaSluzba.Controllers;
using StudentskaSluzba.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StudentskaSluzba.UnitTests
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentValidacija_UspesnaValidacija_ReturnsTrue()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentImeNull_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student {
                    Ime = null,
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentPrezimeNull_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = null,
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentAdresaNull_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic",
                    Adresa = null,
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentGradNull_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23",
                    Grad = null
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentImeImaZnak_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan!",
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentImeImaBroj_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan3",
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentPrezimeImaZnak_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic!",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentPrezimeImaBroj_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic3",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentAdresaImaZnak_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23!",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentGradImaZnak_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad!"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_StudentGradImaBroj_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Jovkovic",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad3"
                });
            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StudentValidacija_PrezimeIImeJEdnaki_ReturnsFalse()
        {
            //Arrange
            var controller = new StudentController();
            //Act
            var result = controller.StudentValidacija(
                new Student
                {
                    Ime = "Ivan",
                    Prezime = "Ivan",
                    Adresa = "Novosadskog sajma 23",
                    Grad = "Novi Sad"
                });
            //Assert
            Assert.IsFalse(result);
        }

    }
}
