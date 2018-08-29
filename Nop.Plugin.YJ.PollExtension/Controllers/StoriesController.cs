using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core;
using Microsoft.AspNetCore.Mvc;
using Nop.Web.Framework.Controllers;
using Microsoft.EntityFrameworkCore;
using Nop.Plugin.YJ.PollExtension.Services;
using Nop.Plugin.YJ.PollExtension.Domain;
using Nop.Core.Data;
using Nop.Core.Domain.Polls;
using System.IO;

namespace Nop.Plugin.YJ.PollExtension.Controllers
{
    [Route("ystories/")]
    public class StoriesController : BasePluginController
    {
        #region Fields

        //private readonly IPollExtensionService _pollExtensionService;
      //  private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PollAnswer> _yPollAnswerRepository;
        private readonly IRepository<Poll> _yPollRepository;
        #endregion

        #region Ctor
        //public StoriesController(IPollExtensionService pollExtensionService)
        public StoriesController(IRepository<Poll> yPollRepository, IRepository<PollAnswer> yPollAnswerRepository)
        {
            //this._pollExtensionService = pollExtensionService;
         //   this._unitOfWork = unitOfWork;
            this._yPollAnswerRepository = yPollAnswerRepository;
            this._yPollRepository = yPollRepository;
        }
        #endregion

        [HttpGet]
        [Route("GetRandomPoll")]
        public Poll GetRandomPoll()
        {
            Random r = new Random();
            System.Threading.Tasks.Task<int> noOfPolls = _yPollRepository.Table.CountAsync<Poll>();
            int pollNumber = r.Next(0, noOfPolls.Result-1);
            return _yPollRepository.GetById(pollNumber);
            // int pollNumber = _pollExtensionService.GetRandomPollNumber();
            // return _pollExtensionService.GetPollRecord(new Poll {Id = pollNumber});
        }

        [HttpGet]
        [Route("GetPollById")]
        public Poll GetPollById([FromRoute]int pollId)
        {
            return _yPollRepository.GetById(pollId);
          //  return _pollExtensionService.GetPollRecord(new Poll { Id = pollId });
        }

        [HttpPost]
        [Route("GetStoryImage")]
        public FileResult GetStoryImage([FromBody]int pollAnswerId)
        {
           PollAnswer pollAnswer = _yPollAnswerRepository.GetById(new PollAnswer { Id = pollAnswerId });
           var path = pollAnswer.PollAnswerImagePath;
        //   var path = _pollExtensionService.GetPollAnswerRecordById(pollAnswerId).PollAnswerImagePath;
           return new FileStreamResult(new FileStream(path, FileMode.Open), "image/jpeg");
        }

       [HttpPost]
       [Route("GetPollStories")]
       public List<FileResult> GetPollStories([FromBody]int pollId)
        {
            Poll poll = _yPollRepository.GetById(new Poll { Id = pollId });
            ICollection<PollAnswer> pollAnswers = poll.PollAnswers;
            // ICollection<PollAnswer> pollAnswers = _pollExtensionService.GetPollRecord(new Poll { Id = pollId }).PollAnswers;
            List<FileResult> pollAnswerImages = new List<FileResult>();
            foreach (PollAnswer answer in pollAnswers)
            {
                pollAnswerImages.Add(new FileStreamResult(new FileStream(answer.PollAnswerImagePath, FileMode.Open), "image/jpeg"));
            }
            return pollAnswerImages;
        }

    }
}
