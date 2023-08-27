using System;
namespace SelfieAWookie.API.UI.Application.Dtos
{
    public class SelfieDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? ImagePath { get; set; }
        public string? Description { get; set; }
        public int WookieId { get; set; }
        public int PictureId { get; set; }
    }
}

