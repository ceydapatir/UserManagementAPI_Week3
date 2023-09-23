using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace UserManagement_API.Operations.UpdateUsers
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        // Data check rules for PUT method
        public UpdateUserValidator(){
            RuleFor(i => i.UserId).NotEmpty().GreaterThan(0);
            RuleFor(i => i.Model.Name).NotNull().MaximumLength(20);
            RuleFor(i => i.Model.Surname).NotNull().MaximumLength(20);
            RuleFor(i => i.Model.CitizenNum).NotNull().Length(11);
            RuleFor(i => i.Model.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.Now.Date.AddYears(-18));
            RuleFor(i => i.Model.Mail).NotNull();
            RuleFor(i => i.Model.Phone).NotEmpty().GreaterThan(0);
        }
    }
}