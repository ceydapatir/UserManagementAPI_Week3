using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace UserManagement_API.Operations.GetUsers
{
    public class GetUserByIdValidator : AbstractValidator<GetUserByIdQuery>
    {
        // Data check rules for GET method
        public GetUserByIdValidator(){
            RuleFor(i => i.UserId).NotEmpty().GreaterThan(0);
        }
    }
}