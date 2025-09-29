using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACar.Application.Features.CQRS.Queries.BannerQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;
        private readonly GetBannerQueryHandler _getBannerQueryHandler;
        private readonly RemoveBannerCommandHandler _removeBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, GetBannerByIdQueryHandler getBannerByIdQueryHandler, GetBannerQueryHandler getBannerQueryHandler, RemoveBannerCommandHandler removeBannerCommandHandler, UpdateBannerCommandHandler updateBannerCommandHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
            _getBannerQueryHandler = getBannerQueryHandler;
            _removeBannerCommandHandler = removeBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var results = await _getBannerQueryHandler.Handle();
            return Ok(results);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BannerById(int id)
        {
            var result = await _getBannerByIdQueryHandler.Handle(new GetBannerByIdQuery(id));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> BannerCreate(CreateBannerCommand createBannerCommand)
        {
            await _createBannerCommandHandler.Handle(createBannerCommand);
            return Ok("Banner bilgisi eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> BannerUpdate(UpdateBannerCommand updateBannerCommand)
        {
            await _updateBannerCommandHandler.Handle(updateBannerCommand);
            return Ok("Banner bilgisi güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> BannerDelete(int id)
        {
            await _removeBannerCommandHandler.Handle(new RemoveBannerCommand(id));
            return Ok("Banner bilgisi silindi");
        }
    }
}
