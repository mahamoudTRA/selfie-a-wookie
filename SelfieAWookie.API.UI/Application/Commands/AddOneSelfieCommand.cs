using System;
using MediatR;
using SelfieAWookie.API.UI.Application.Dtos;

namespace SelfieAWookie.API.UI.Application.Commands
{
    public class AddOneSelfieCommand : IRequest<SelfieDTO>
    {
        public SelfieDTO?  Item { get; set; }
    }
}

