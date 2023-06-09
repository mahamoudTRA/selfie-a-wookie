﻿using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SelfieAWookie.API.UI.Application.Dtos;
using SelfieAWookie.Core.Domain.Models;
using SelfieAWookie.Core.Domain.Repositories;

namespace SelfieAWookie.API.UI.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    public class SelfieController: ControllerBase
    {
        private readonly ISelfieRepository _selfieRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SelfieController(ISelfieRepository selfieRepository, IWebHostEnvironment hostEnvironment)
        {
            _selfieRepository = selfieRepository;
            _hostEnvironment = hostEnvironment;
        }

        [HttpPost("addOneSelfie")]
        public async Task<IActionResult> AddOneSelfie(SelfieDTO selfieDTO)
        {
            IActionResult result = BadRequest();
            Selfie selfieAdded = await _selfieRepository.AddOneSelfie(new Selfie()
            {
                Title = selfieDTO.Title,
                ImagePath = selfieDTO.ImagePath,
                WookieId = selfieDTO.WookieId
            });

            if(selfieAdded != null)
            {
                selfieDTO.Id = selfieAdded.Id;
                result = Ok(selfieDTO);
            }

            
            return Ok(selfieAdded);
        }

        [HttpGet("getAllSelfie")]
        public async Task<IActionResult> GetAll([FromQuery] int wookieId = 0)
        {
            var query = await _selfieRepository.GetAll(wookieId);

            var result = query.Select(x => new SelfieResumeDTO
            {
                Title = x.Title,
                Wookie = x.Wookie?.Name,
                NombreSelfieFromWookie = (x.Wookie?.Selfies?.Count).GetValueOrDefault(0)
            }).ToList();


            return Ok(result);
        }

        //[HttpPost("addPicture")]
        //public async Task<IActionResult> AddPicture()
        //{
        //    using var stream = new StreamReader(Request.Body);

        //    var content = await stream.ReadToEndAsync();
        //    return Ok();
        //}

        [HttpPost("addPicture")]
        public async Task<IActionResult> AddPicture(IFormFile picture)
        {
            string filePath = Path.Combine(_hostEnvironment.ContentRootPath, @"image/selfies");

            if(!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            filePath = Path.Combine(filePath, picture.FileName);

            using var stream = new FileStream(filePath, FileMode.OpenOrCreate);

            try
            {
                await picture.CopyToAsync(stream);
            }
            catch
            {
                throw;
            }

            var itemFile = await _selfieRepository.AddOnePicture(filePath);
            
            return Ok(itemFile);
        }
    }
}

