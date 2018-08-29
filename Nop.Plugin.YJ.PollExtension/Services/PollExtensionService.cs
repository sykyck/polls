using System;
using System.Collections.Generic;
using System.Text;
using Nop.Core.Data;
using Nop.Core;
using Nop.Plugin.YJ.PollExtension.Domain;
using Nop.Core.Domain.Polls;

namespace Nop.Plugin.YJ.PollExtension.Services
{
    public class PollExtensionService : IPollExtensionService
    {
        //private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<PollAnswer> _yPollAnswerRepository;
        private readonly IRepository<Poll> _yPollRepository;

        public PollExtensionService(IRepository<Poll> yPollRepository, IRepository<PollAnswer> yPollAnswerRepository)
        {
            this._yPollAnswerRepository = yPollAnswerRepository;
            this._yPollRepository = yPollRepository;
        }

        public PollAnswer GetPollAnswerRecord(PollAnswer record)
        {
           return _yPollAnswerRepository.GetById(record);
        }

        public PollAnswer GetPollAnswerRecordById(int pollAnswerId)
        {
            return _yPollAnswerRepository.GetById(new PollAnswer { Id = pollAnswerId });
        }

        public void AddPollAnswerRecord(PollAnswer record)
        {
            _yPollAnswerRepository.Insert(record);
        }

        public void DeletePollAnswerRecord(PollAnswer record)
        {
            _yPollAnswerRepository.Delete(record);
        }

        public void UpdatePollAnswerRecord(PollAnswer record)
        {
            _yPollAnswerRepository.Update(record);
        }

        public Poll GetPollRecord(Poll record)
        {
            return _yPollRepository.GetById(record);
        }

        public int GetRandomPollNumber()
        {
           Random r = new Random();
           return  1;
        }

        public void AddPollRecord(Poll record)
        {
           _yPollRepository.Insert(record);
        }

        public void DeletePollRecord(Poll record)
        {
           _yPollRepository.Delete(record);
        }

        public void UpdatePollRecord(Poll record)
        {
            _yPollRepository.Update(record);
        }
    }
}
