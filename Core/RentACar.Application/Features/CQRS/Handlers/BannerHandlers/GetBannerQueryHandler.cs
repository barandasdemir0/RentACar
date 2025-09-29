using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Results.BannerResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }

        public async Task<List< GetBannerQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerID = x.BannerID,
                BannerTitle = x.BannerTitle,
                BannerDescription = x.BannerDescription,
                BannerVideoDescription = x.BannerVideoDescription,
                BannerVideoUrl = x.BannerVideoUrl,
                BannerImageUrl = x.BannerImageUrl
            }).ToList();
        }
    }
}
