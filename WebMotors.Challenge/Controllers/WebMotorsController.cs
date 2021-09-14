using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMotors.Challenge.Application.Interfaces;
using WebMotors.Challenge.Domain.Models;
using WebMotors.Challenge.Mapper;
using WebMotors.Challenge.ViewModels;

namespace WebMotors.Challenge.Controllers
{
    [ApiController]
    [Route("")]
    public class WebMotorsController : ControllerBase
    {
        private readonly IOnlineChallengeAppService _onlineChallengeAppService;
        private readonly IAnnouncementAppService _announcementAppService;

        public WebMotorsController(IOnlineChallengeAppService onlineChallengeAppService, IAnnouncementAppService announcementAppService)
        {
            _onlineChallengeAppService = onlineChallengeAppService;
            _announcementAppService = announcementAppService;
        }

        [HttpGet, Route("makes")]
        public async Task<List<Make>> GetAllMakeAsync()
        {
            return await _onlineChallengeAppService.GetAllMakeAsync();
        }

        [HttpGet, Route("models")]
        public async Task<List<Model>> GetAllModelAsync(int makeId)
        {
            return await _onlineChallengeAppService.GetAllModelAsync(makeId);
        }

        [HttpGet, Route("versions")]
        public async Task<List<Version>> GetAllVersionAsync(int modelId)
        {
            return await _onlineChallengeAppService.GetAllVersionAsync(modelId);
        }

        [HttpGet, Route("announcements/{id}")]
        public async Task<Announcement> GetAnnouncement(int id)
        {
            return await _announcementAppService.GetAnnouncement(id);
        }

        [HttpGet, Route("announcements")]
        public async Task<List<Announcement>> GetAllAnnouncement()
        {
            return await _announcementAppService.GetAllAnnouncement();
        }

        [HttpPost, Route("announcements")]
        public async Task<ObjectResult> PostAnnouncement(AnnouncementViewModel announcement)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(_ => _.Errors);
                return StatusCode(StatusCodes.Status400BadRequest, errors);
            }

            var mapped = AnnouncementMapper.Map(announcement);
            await _announcementAppService.CreateAnnouncement(mapped);
            return StatusCode(StatusCodes.Status200OK, null);
        }

        [HttpPut, Route("announcements")]
        public async Task<ObjectResult> PutAnnouncement(AnnouncementViewModel announcement)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(_ => _.Errors);
                return StatusCode(StatusCodes.Status400BadRequest, errors);
            }

            var mapped = AnnouncementMapper.Map(announcement);
            await _announcementAppService.UpdateAnnonucement(mapped);
            return StatusCode(StatusCodes.Status200OK, null);
        }

        [HttpDelete, Route("announcements/{id}")]
        public async Task<ObjectResult> DeleteAnnouncement(int id)
        {
            if (id <= 0)
                return StatusCode(StatusCodes.Status400BadRequest, new List<ModelError> { new ModelError("Invalid ID") });

            await _announcementAppService.RemoveAnnouncement(id);
            return StatusCode(StatusCodes.Status200OK, null);
        }
    }
}
