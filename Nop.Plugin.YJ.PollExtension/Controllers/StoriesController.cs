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
using System.Threading.Tasks;

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
        public IActionResult GetRandomPoll()
        {
            Random r = new Random();
            System.Threading.Tasks.Task<int> noOfPolls = _yPollRepository.Table.CountAsync<Poll>();
            int pollNumber = r.Next(0, noOfPolls.Result-1);
            IEnumerator<Poll> enumerator = _yPollRepository.Table.GetEnumerator();
            int position = 0;
            Poll selectedPoll;
            while (enumerator.MoveNext())
            {
                selectedPoll = enumerator.Current;
                if((selectedPoll!=null)&&(position == pollNumber))
                {
                    return Json(selectedPoll);
                }
                else if((selectedPoll == null)&&(position >= pollNumber))
                {
                    enumerator.Reset();
                    if(enumerator.MoveNext())
                    {
                        selectedPoll = enumerator.Current;
                        return Json(selectedPoll);
                    }
                }
                position = position + 1; 
            }
            return new Nop.Web.Framework.Mvc.NullJsonResult();
            // int pollNumber = _pollExtensionService.GetRandomPollNumber();
            // return _pollExtensionService.GetPollRecord(new Poll {Id = pollNumber});
        }

        [HttpGet]
        [Route("GetPollById/{pollId:int}")]
        public IActionResult GetPollById(int pollId)
        {
            return Json(_yPollRepository.GetById(pollId));
          //  return _pollExtensionService.GetPollRecord(new Poll { Id = pollId });
        }

        [HttpGet]
        [Route("GetPollAnswerImage/{pollAnswerId:int}")]
        public FileResult GetPollAnswerImage([FromRoute]int pollAnswerId)
        {
            PollAnswer pollAnswer = _yPollAnswerRepository.GetById(pollAnswerId);
            var filename = pollAnswer.PollAnswerImagePath;
        //   var path = _pollExtensionService.GetPollAnswerRecordById(pollAnswerId).PollAnswerImagePath;
            return new FileStreamResult(new FileStream(System.Configuration.ConfigurationManager.AppSettings["pollMediaPath"] + filename, FileMode.Open), "image/jpg");
        }

        [HttpGet]
        [Route("GetPollAnswerProduct/{pollAnswerId:int}")]
        public IActionResult GetPollAnswerProduct([FromRoute]int pollAnswerId)
        {
            PollAnswer pollAnswer = _yPollAnswerRepository.GetById(pollAnswerId);
            var productId = pollAnswer.PollProductId;
            //   var path = _pollExtensionService.GetPollAnswerRecordById(pollAnswerId).PollAnswerImagePath;
            return Json(productId);
        }

        [HttpGet]
        [Route("GetPollAnswers/{pollId:int}")]
        public IActionResult GetPollAnswers([FromRoute]int pollId)
        {
            Poll poll = _yPollRepository.GetById(pollId);
            ICollection<PollAnswer> pollAnswers = poll.PollAnswers;
            // ICollection<PollAnswer> pollAnswers = _pollExtensionService.GetPollRecord(new Poll { Id = pollId }).PollAnswers;
            List<int> pollAnswerIdList = new List<int>();
            foreach (PollAnswer answer in pollAnswers)
            {
                pollAnswerIdList.Add(answer.Id);
            }
            return Json(pollAnswerIdList);
        }

        [HttpGet]
        [Route("GetAllPolls")]
        public IActionResult GetAllPolls()
        {
            System.Threading.Tasks.Task<List<Poll>> poll = _yPollRepository.Table.ToListAsync<Poll>();
            ICollection<Poll> pollList = poll.Result;
            // ICollection<PollAnswer> pollAnswers = _pollExtensionService.GetPollRecord(new Poll { Id = pollId }).PollAnswers;
            List<int> pollIdList = new List<int>();
            foreach (Poll pollObj in pollList)
            {
                pollIdList.Add(pollObj.Id);
            }
            return Json(pollIdList);
        }

    }
}
