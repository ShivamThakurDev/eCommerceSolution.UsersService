using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email address format");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit")
                .Matches(@"[\W]").WithMessage("Password must contain at least one special character");
            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person name is required")
                .MinimumLength(1).MaximumLength(50);
            RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required")
                .IsInEnum().WithMessage("Invalid Gender value");
        }
    }
}
