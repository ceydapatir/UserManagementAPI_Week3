using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace UserManagement_API.Operations.DeleteUsers
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        // Data check rules for DELETE method
        public DeleteUserValidator(){
            RuleFor(i => i.UserId).NotEmpty().GreaterThan(0);
        }
    }
}