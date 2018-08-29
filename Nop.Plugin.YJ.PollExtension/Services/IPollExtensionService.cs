using System;
using System.Collections.Generic;
using System.Text;
using Nop.Plugin.YJ.PollExtension.Domain;
using Nop.Core.Domain.Polls;


namespace Nop.Plugin.YJ.PollExtension.Services
{
    public interface IPollExtensionService
    {
        PollAnswer GetPollAnswerRecord(PollAnswer record);

        PollAnswer GetPollAnswerRecordById(int pollAnswerId);

        void AddPollAnswerRecord(PollAnswer record);

        void DeletePollAnswerRecord(PollAnswer record);

        void UpdatePollAnswerRecord(PollAnswer record);

        Poll GetPollRecord(Poll record);

        int GetRandomPollNumber();
    }
}
