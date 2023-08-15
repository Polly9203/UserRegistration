using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using UserRegistration.BLL.Models.Registration;
using UserRegistration.BLL.Services;
using UserRegistration.BLL.Validators;

namespace UserRegistration.PL.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _registrationCommandHandler;
        public UserController(IUserService registrationCommandHandler)
        {
            _registrationCommandHandler = registrationCommandHandler;
        }

        [HttpPost]
        [Route("registration")]
        [ProducesResponseType(typeof(RegistrationResultModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegistrationResultModel>> Registration(RegistrationModel command)
        {
            var validationResult = await new RegistrationModelValidator().ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => new
                {
                    Field = error.PropertyName,
                    Message = error.ErrorMessage
                });

                return BadRequest(errors);
            }

            try
            {
                var result = _registrationCommandHandler.CreateUser(command);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                var error = new ValidationFailure(ex.Source, ex.Message);
                var errorOutput = new
                {
                    Field = error.PropertyName,
                    Message = error.ErrorMessage
                };

                return BadRequest(errorOutput);
            }
        }
    }
}
