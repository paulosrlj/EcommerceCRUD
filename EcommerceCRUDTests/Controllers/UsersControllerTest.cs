using EcommerceCRUD.Controllers;
using EcommerceCRUD.Models.DTO.Entities;
using EcommerceCRUD.Models.DTO.Input;
using EcommerceCRUD.Models.DTO.Output;
using EcommerceCRUD.Repositories;
using EcommerceCRUD.Repositories.Interfaces;
using EcommerceCRUD.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceCRUDTests.Controllers
{
    public class UsersControllerTest
    {
        private Mock<IUserService> _mockUserService;

        private readonly UserController _testingObject;

        public UsersControllerTest()
        {
            _mockUserService = new Mock<IUserService>();

            _testingObject = new UserController(_mockUserService.Object);
        }

        [Fact]
        public async Task ShouldReturnAOutputUserById()
        {
            User user = GetDomainUser();

            var outputUser = new OutputUser()
            {
                Id = Guid.Parse("93c0c612-5d09-42f1-ace0-689a3e54ee49"),
                Email = "test@mail.com",
                Name = "Test User"
            };

            //Mock
            _mockUserService.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(user);

            var result = await _testingObject.Get("93c0c612-5d09-42f1-ace0-689a3e54ee49") as OkObjectResult;
            var data = result.Value as ResponseObject;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(data.Data, outputUser);
        }

        [Fact]
        public async Task ShouldCreateAndReturnAUser()
        {
            User user = GetDomainUser();
            OutputUser outputUser = GetOutputUser();
            InputUser inputUser = GetInputUser();

            //Mock
            _mockUserService.Setup(x => x.Create(It.IsAny<User>())).ReturnsAsync(user);

            var result = await _testingObject.Create(inputUser) as OkObjectResult;

            var data = result.Value as ResponseObject;

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(data.Data, outputUser);

            static InputUser GetInputUser()
            {
                return new InputUser()
                {
                    Email = "test@mail.com",
                    Password = "123456",
                    Name = "Test User"
                };
            }
        }

        [Fact]
        public async Task ShouldUpdateUserOnce()
        {
            InputUser inputUser = GetInputUser();

            //Mock
            _mockUserService.Setup(x => x.Update(It.IsAny<string>(), It.IsAny<InputUser>()));

            var result = await _testingObject.Update
                ("93c0c612-5d09-42f1-ace0-689a3e54ee49", inputUser
                );

            _mockUserService.Verify(x => x.Update(It.IsAny<string>(), It.IsAny<InputUser>()), Times.Once);

            Assert.IsType<OkResult>(result);   
        }

        [Fact]
        public async Task ShouldDeleteUserOnce()
        {
            //Mock
            _mockUserService.Setup(x => x.Delete(It.IsAny<string>()));

            var result = await _testingObject.Delete
                ("93c0c612-5d09-42f1-ace0-689a3e54ee49"
                );

            _mockUserService.Verify(x => x.Delete(It.IsAny<string>()), Times.Once);

            Assert.IsType<OkResult>(result);
        }

        private static OutputUser GetOutputUser()
        {
            return new OutputUser()
            {
                Id = Guid.Parse("93c0c612-5d09-42f1-ace0-689a3e54ee49"),
                Email = "test@mail.com",
                Name = "Test User"
            };
        }

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
