namespace Ange.WebUI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.User.Commands.CreateUser;
    using Application.User.Commands.DeleteUser;
    using Application.User.Commands.UpdateUser;
    using Application.User.Queries.GetUserDetail;
    using Application.User.Queries.GetUserList;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUserListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDetailModel>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetUserDetailQuery {Id = id}));
        }

        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserListViewModel>> GetByName(string name)
        {
            return Ok(await Mediator.Send(new GetUserListQuery {Name = name}));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteUserCommand {Id = id});

            return NoContent();
        }
    }
}