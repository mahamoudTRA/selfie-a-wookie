using System;
using MediatR;
using SelfieAWookie.API.UI.Application.Dtos;

namespace SelfieAWookie.API.UI.Application.Queries
{
    public class SelectAllSelfieQuerie : IRequest<List<SelfieResumeDTO>>
    {
        public int WookieId { get; set; }
    }
}

