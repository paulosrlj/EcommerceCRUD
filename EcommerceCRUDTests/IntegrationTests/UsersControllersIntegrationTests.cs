using EcommerceCRUD.Controllers;
using EcommerceCRUD.Database;
using EcommerceCRUD.Models.DTO.Entities;
using EcommerceCRUD.Models.DTO.Input;
using EcommerceCRUD.Repositories;
using EcommerceCRUD.Repositories.Interfaces;
using EcommerceCRUD.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCRUDTests.IntegrationTests
{
    public class UsersControllersIntegrationTests
    {

        private readonly DbContextOptions<EcommerceCRUDContext> _contextOpts;

        public UsersControllersIntegrationTests()
        {
            _contextOpts = new DbContextOptionsBuilder<EcommerceCRUDContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

        }

        private UserController GetTestingObject()
        {
            var ctxOpts = new DbContextOptionsBuilder<EcommerceCRUDContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            UserController userController;

            using (var context = new EcommerceCRUDContext(ctxOpts))
            {
                var repository = new UserRepository(context);
                var userService = new UserService(repository);
                userController = new UserController(userService);
            }

            return userController;
        }

        //[Fact]
        //public async Task ShouldCreateUser()
        //{
        //    // Arrange
        //    using (var context = new EcommerceCRUDContext(_contextOpts))
        //    {
        //        var repository = new UserRepository(context);
        //        await repository.Create(GetDomainUser());
        //    }


        //}

        private static User GetDomainUser()
        {
            return new User()
            {
                Id = Guid.Parse("93c0c612-5d09-42f1-ace0-689a3e54ee49"),
                Email = "test@mail.com",
                HashedPassword = "123456",
                Name = "Test User"
            };
        }

        private static InputUser GetInputUser()
        {
            return new InputUser()
            {
                Email = "test@mail.com",
                Password = "123456",
                Name = "Test User"
            };
        }
    }
}
