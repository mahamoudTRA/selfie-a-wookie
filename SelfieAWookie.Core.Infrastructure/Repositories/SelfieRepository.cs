using System;
using System.Net;
using Microsoft.EntityFrameworkCore;
using SelfieAWookie.Core.Domain.Models;
using SelfieAWookie.Core.Infrastructure.Data;
using SelfieAWookie.Core.Domain.Repositories;

namespace SelfieAWookie.Core.Infrastructure.Repositories
{
    public class SelfieRepository: ISelfieRepository
    {
        private readonly DataContext _context;

        public SelfieRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Picture> AddOnePicture(string url)
        {
            var result = await _context.AddAsync(new Picture()
            {
                Url = url
            });

            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Selfie> AddOneSelfie(Selfie selfie)
        {
            var addedItem = await _context.Selfies.AddAsync(selfie);
            await _context.SaveChangesAsync();
            return addedItem.Entity;
        }

        public async Task<ICollection<Selfie>> GetAll(int wookieId)
        {
            /* 
             * ça c'est la methode classique
             Pour recuperer les selfies avec le wookie correspondant,
             il faut creer un Dto et recuperer les champs 1 par 1 pour ne pas avoir de cycle d'objet
             
             
            var selfies = _context.Selfies.AsQueryable();
            var wookies = await _context.Wookies.ToListAsync();


            var result = from selfie in selfies
                         join
                         wookie in wookies on selfie.WookieId equals wookie.Id
                         select new Selfie { Id = selfie.Id, Wookie = new Wookie { Id = wookie.Id, Name = wookie.Name } };
            //result = result.ToList();
            */

            var query = _context.Selfies.Include(x => x.Wookie).AsQueryable();

            if(wookieId > 0)
            {
                query = query.Where(x => x.WookieId == wookieId);
            }

            return await query.ToListAsync();
        }
    }
}

