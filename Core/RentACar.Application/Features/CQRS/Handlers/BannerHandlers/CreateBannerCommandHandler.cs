using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class CreateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public CreateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBannerCommand createBannerCommand)
        {
            await _repository.CreateAsync(new Banner
            {

                BannerTitle = createBannerCommand.BannerTitle,
                BannerDescription = createBannerCommand.BannerDescription,
                BannerVideoDescription = createBannerCommand.BannerVideoDescription,
                BannerVideoUrl = createBannerCommand.BannerVideoUrl,
                BannerImageUrl = createBannerCommand.BannerImageUrl

            });
        }
    }
}
