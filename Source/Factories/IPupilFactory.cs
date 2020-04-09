namespace Grade.Promoter.Factories
{
    using System.Collections.Generic;
    using Grade.Promoter.Models;
    using Grade.Promoter.ViewModels;

    public interface IPupilFactory
    {
        Pupil Create(List<ExamResult> list);
    }
}
