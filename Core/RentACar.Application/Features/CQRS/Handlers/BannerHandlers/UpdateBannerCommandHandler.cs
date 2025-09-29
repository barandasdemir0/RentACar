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
    public class UpdateBannerCommandHandler
    {
        // Implementation for updating a banner would go here
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBannerCommand updateBannerCommand)
        {
           var values = await _repository.GetByIdAsync(updateBannerCommand.BannerID);
            if (values != null)
            {
                values.BannerTitle = updateBannerCommand.BannerTitle;
                values.BannerDescription = updateBannerCommand.BannerDescription;
                values.BannerVideoDescription = updateBannerCommand.BannerVideoDescription;
                values.BannerVideoUrl = updateBannerCommand.BannerVideoUrl;
                values.BannerImageUrl = updateBannerCommand.BannerImageUrl;
                await _repository.UpdateAsync(values);
            }
        }
    }
}
