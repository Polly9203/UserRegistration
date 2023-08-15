using Microsoft.AspNetCore.Mvc;
using UserRegistration.BLL.Registration;
using UserRegistration.BLL.Registration.Commands;
using UserRegistration.BLL.Registration.Models;

namespace UserRegistration.PL.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IRegistrationCommandHandler _registrationCommandHandler;
        public UserController(IRegistrationCommandHandler registrationCommandHandler)
        {
            _registrationCommandHandler = registrationCommandHandler;
        }

        [HttpPost]
        [Route("registration")]
        [ProducesResponseType(typeof(RegistrationResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RegistrationResult>> Registration(RegistrationCommand command)
        {
            var validationResult = await new RegistrationCommandValidator().ValidateAsync(command);
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
                var result = _registrationCommandHandler.RegistrateUser(command);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
