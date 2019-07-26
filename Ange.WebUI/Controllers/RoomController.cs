namespace Ange.WebUI.Controllers
{
    using System.Threading.Tasks;
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
    }
}