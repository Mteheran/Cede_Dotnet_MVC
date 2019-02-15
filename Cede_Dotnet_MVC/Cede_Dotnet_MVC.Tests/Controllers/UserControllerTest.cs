using Cede_Dotnet_MVC.Controllers;
using Cede_Dotnet_MVC.Services.Contract;
using Cede_Dotnet_MVC.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cede_Dotnet_MVC.Tests.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            UserController controller = new UserController(null);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ValidateUser()
        {
            // Arrange
            UserController controller = new UserController(null);

            // Act
            ViewResult result = controller.ValidateUser() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual(DateTime.Now.Date, ((UserValidation)result.Model).NitDate.Date);
        }

        [TestMethod]
        public void ValidateUserPost()
        {
            // Arrange
            var userService = new Moq.Mock<IUserService>();
            userService.Setup(p => p.ValidateUserByNitAndNitDate("", DateTime.Now)).Returns("");

            var userValidation = new UserValidation() { NitDate = DateTime.Now, Nit= null };
            UserController controller = new UserController(userService.Object);

            // Act
            ViewResult result = controller.ValidateUser(userValidation) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);
            Assert.AreEqual("Usuarios",result.ViewBag.title);            
        }
    }
}
