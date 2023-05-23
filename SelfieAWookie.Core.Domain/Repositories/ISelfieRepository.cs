using System;
using SelfieAWookie.Core.Domain.Models;

namespace SelfieAWookie.Core.Domain.Repositories
{
    public interface ISelfieRepository
    {
        Task<Selfie> AddOneSelfie(Selfie selfie);
        Task<ICollection<Selfie>> GetAll(int wookieId);

        Task<Picture> AddOnePicture(string url);
        //Task<int> AddOnePicture(int selfieId, string url);
    }
}

