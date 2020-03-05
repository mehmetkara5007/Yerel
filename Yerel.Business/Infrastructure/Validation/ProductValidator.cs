using FluentValidation;
using Yerel.Entities;

namespace Yerel.Business.Infrastructure.Validation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(t => t.Brand).NotEmpty();
            RuleFor(t => t.Category).NotEmpty();
        }
    }
}
