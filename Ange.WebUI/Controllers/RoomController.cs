namespace Ange.WebUI.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.Room.Queries.GetRoomDetail;
    using Application.Room.Queries.GetRoomsList;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class RoomController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RoomListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetRoomListQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RoomDetailModel>> Get(Guid id)
        {
            return Ok(await Mediator.Send(new GetRoomDetailQuery {Id = id}));
        }
    }
}