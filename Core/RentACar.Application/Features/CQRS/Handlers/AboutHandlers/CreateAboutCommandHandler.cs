﻿using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public CreateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAboutCommand createAboutCommand)
        {
            await _repository.CreateAsync(new About
            {
                AboutTitle = createAboutCommand.AboutTitle,
                AboutDescription = createAboutCommand.AboutDescription,
                AboutImageUrl = createAboutCommand.AboutImageUrl
            });
        }
    }
}
