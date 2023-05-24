using System;
using MediatR;
using SelfieAWookie.API.UI.Application.Dtos;
using SelfieAWookie.API.UI.Application.Queries;
using SelfieAWookie.Core.Domain.Repositories;

namespace SelfieAWookie.API.UI.Application.Commands
{
    public class AddOneSelfieHandler: IRequestHandler<AddOneSelfieCommand, SelfieDTO>
    {
        private readonly ISelfieRepository _selfieRepository;

        public AddOneSelfieHandler(ISelfieRepository selfieRepository)
        {
            _selfieRepository = selfieRepository;
        }

        public async Task<SelfieDTO> Handle(AddOneSelfieCommand request, CancellationToken cancellationToken)
        {
            var addedSelfie = await _selfieRepository.AddOneSelfie(new Core.Domain.Models.Selfie()
            {
                Title = request?.Item?.Title,
                PictureId = request!.Item!.PictureId,
                WookieId = request.Item.WookieId,
                Description = request.Item.Description
            });

            if(addedSelfie != null)
            {
                return await Task.FromResult(request.Item);
            }

            throw new Exception();
        }
    }
}

