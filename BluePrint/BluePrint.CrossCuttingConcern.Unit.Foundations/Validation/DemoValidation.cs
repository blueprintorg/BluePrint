using BluePrint.Model.Unit.Foundations.Dtos;
using FluentValidation;

namespace BluePrint.CrossCuttingConcern.Unit.Foundations.Validation
{
    public class DemoValidation : AbstractValidator<DemoDto>
    {
        public DemoValidation()
        {
            RuleFor(d => d.DemoName).NotEmpty();
        }
    }
}
