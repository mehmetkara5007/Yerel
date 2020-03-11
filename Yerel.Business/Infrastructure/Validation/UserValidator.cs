using FluentValidation;
using Yerel.Entities;

namespace Yerel.Business.Infrastructure.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(t => t.Name).NotEmpty();
            RuleFor(t => t.Email).NotEmpty();
        }
    }
}
