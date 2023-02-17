using AutoFixture.Xunit2;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using Moq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.DbContexts;
using TaskManagerApp.Models;
using TaskManagerApp.Services;
using Xunit;

namespace TaskManagerApp.UnitTests.Services
{
    public class HomeService
    {
        [Theory, AutoData]
        public void CreateAccount_ForCorretData_ReturnFalse()
        {
            //arrange
            var systemDbContextMock = new Mock<DataContext>();
            systemDbContextMock.Setup(x => x.Users.Add(It.IsAny<User>())).Returns((User u) => u);

            var accountService = new AccountService(systemDbContextMock.Object);

            //act
            accountService.CreateAccount(new ViewModels.RegisterViewModel { FirstName = "Tom", Email = "Tom@wp.pl", Password = "MocneHasło123", CellPhone = "878987890", LastName = "Kowalski", ConfirmPassword = "MocneHasło123" });

            //assert
            systemDbContextMock.Verify(x => x.SaveChanges(), Times.Once);

        }
    }
}
