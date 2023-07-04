using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CoffeeClub.Application.Features.Coffee.Commands.CreateCoffee
{
    public class CreateCoffeeCommandValidator : AbstractValidator<CreateCoffeeCommand>
    {
        public CreateCoffeeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("'Name' must not be empty.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("'Description' must not be empty.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("'Price' must be greater than 0.");
            RuleFor(x => x.PurchasingLink).NotEmpty().Must(BeValidUrl).WithMessage("'Purchasing Link' must be in a valid URL format.");
            RuleFor(x => x.Size).NotEmpty().WithMessage("'Size' must not be empty.");
            RuleFor(x => x.Origin).NotEmpty().WithMessage("'Origin' must not be empty.");
            RuleFor(x => x.RoastType).NotEmpty().WithMessage("'Roast Type' must not be empty.");
        }

        private bool BeValidUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return false;

            // Use regular expression to validate URL format
            var regex = new Regex(@"^(http(s)?:\/\/)[-a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)$");
            return regex.IsMatch(url);
        }


        private bool BeValidSizeFormat(string size)
        {
            if (string.IsNullOrEmpty(size))
                return false;

            // Split the size by space
            var parts = size.Split(' ');

            // Check if there are two parts (number and text)
            if (parts.Length != 2)
                return false;

            // Check if the first part is a number
            if (!decimal.TryParse(parts[0], out _))
                return false;

            // Check if the second part is text (e.g., 'oz', 'mg', etc.)
            var validUnits = new[] { "oz", "mg" }; // Add more valid units as needed
            if (!validUnits.Contains(parts[1]))
                return false;

            return true;
        }
    }

}
