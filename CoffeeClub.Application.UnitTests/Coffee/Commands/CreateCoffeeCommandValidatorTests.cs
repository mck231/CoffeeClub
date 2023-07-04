using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using CoffeeClub.Application.Features.Coffee.Commands.CreateCoffee;

namespace CoffeeClub.Application.UnitTests.Coffee.Commands
{
    [TestClass]
    public class CreateCoffeeCommandValidatorTests
    {
        private CreateCoffeeCommandValidator _validator;

        [TestInitialize]
        public void Setup()
        {
            _validator = new CreateCoffeeCommandValidator();
        }

        [TestMethod]
        public void BeValidUrl_ValidUrl_ReturnsTrue()
        {
            // Arrange
            var validUrl = "https://www.example.com";

            // Act
            var result = _validator.Validate(new CreateCoffeeCommand { Name = "Coffee Name",
            Description = "Coffee Description",
            Price = 10.99m,
            PurchasingLink = validUrl,
            Size = "12 oz",
            Origin = "Colombia",
            RoastType = "Medium Roast"
        });

            // Assert
            result.IsValid.ShouldBeTrue();
        }

        [TestMethod]
        public void BeValidUrl_InvalidUrl_ReturnsFalse()
        {
            // Arrange
            var invalidUrl = "invalid-url";

            // Act
            var result = _validator.Validate(new CreateCoffeeCommand
            {
                Name = "Coffee Name",
                Description = "Coffee Description",
                Price = 10.99m,
                PurchasingLink = invalidUrl,
                Size = "12 oz",
                Origin = "Colombia",
                RoastType = "Medium Roast"
            });

            // Assert
            result.IsValid.ShouldBeFalse();
            result.Errors[0].ErrorMessage.ShouldBe("'Purchasing Link' must be in a valid URL format.");
        }
    }
}
