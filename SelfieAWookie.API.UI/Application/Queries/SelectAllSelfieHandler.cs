using System;
using MediatR;
using SelfieAWookie.API.UI.Application.Dtos;
using SelfieAWookie.Core.Domain.Repositories;

namespace SelfieAWookie.API.UI.Application.Queries
{
    public class SelectAllSelfieHandler : IRequestHandler<SelectAllSelfieQuerie, List<SelfieResumeDTO>>
    {
        private readonly ISelfieRepository _selfieRepository;

        public SelectAllSelfieHandler(ISelfieRepository selfieRepository)
        {
            _selfieRepository = selfieRepository;
        }

        public async Task<List<SelfieResumeDTO>> Handle(SelectAllSelfieQuerie request, CancellationToken cancellationToken)
        {
            var selfies = await _selfieRepository.GetAll(request.WookieId);

            var result = selfies.Select(x => new SelfieResumeDTO()
            {
                Title = x.Title,
                NombreSelfieFromWookie = (x.Wookie?.Selfies?.Count).GetValueOrDefault(0),
                Wookie = x.Wookie?.Name,
                ImagePath = x.Picture!.Url
            }).ToList();

            return await Task.FromResult(result);
        }
    }
}

