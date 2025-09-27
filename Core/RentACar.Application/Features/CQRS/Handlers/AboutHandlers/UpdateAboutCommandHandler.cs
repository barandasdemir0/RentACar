using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;
        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var value = await _repository.GetByIdAsync(updateAboutCommand.AboutID);
            value!.AboutTitle = updateAboutCommand.AboutTitle;
            value.AboutDescription = updateAboutCommand.AboutDescription;
            value.AboutImageUrl = updateAboutCommand.AboutImageUrl;
            await _repository.UpdateAsync(value);
        }
    }
}
