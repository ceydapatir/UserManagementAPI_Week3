using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using UserManagement_API.Data.Context;
using UserManagement_API.Models.DTO;
using UserManagement_API.Models.ViewModel;
using UserManagement_API.Operations.CreateUsers;
using UserManagement_API.Operations.DeleteUsers;
using UserManagement_API.Operations.GetUsers;
using UserManagement_API.Operations.UpdateUsers;

namespace UserManagement_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserDBContext _context;
        private readonly IMapper _mapper;

        public UsersController(UserDBContext context, IMapper mapper){
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Movies
        [HttpGet]
        public IActionResult GetUsers() { 
            GetUsersQuery query = new GetUsersQuery(_context, _mapper);
            List<UserViewModel> MovieList;
            try
            {
                MovieList = query.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(MovieList); 
        }

        // POST: api/Movies
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDTO model) { 
            CreateUserCommand command = new CreateUserCommand(_context, _mapper, model);
            CreateUserValidator validator = new CreateUserValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // PUT: api/Movies/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDTO model) { 
            UpdateUserCommand command = new UpdateUserCommand(_context, _mapper, model, id);
            UpdateUserValidator validator = new UpdateUserValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }

        // DELETE: api/Movies/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id) { 
            DeleteUserCommand command = new DeleteUserCommand(_context, id);
            DeleteUserValidator validator = new DeleteUserValidator();
            try
            {
                validator.ValidateAndThrow(command); // Data check
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(); 
        }
    }
}