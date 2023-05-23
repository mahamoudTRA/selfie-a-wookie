using System;
namespace SelfieAWookie.Core.Domain.Models
{
    public class Picture
    {
        public int Id { get; set; }

        public string? Url { get; set; }

        public DateOnly CreateDate { get; set; }

        public List<Selfie>? Selfies { get; set; }
    }
}

