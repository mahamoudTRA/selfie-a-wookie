using System;
namespace SelfieAWookie.API.UI.Application.Dtos
{
    public class AuthenticateUserDTO
    {
        public string? Login { get; set; }

        public string? Password { get; set; }

        public string? Name { get; set; }

        public string? Token { get; set; }
    }
}

