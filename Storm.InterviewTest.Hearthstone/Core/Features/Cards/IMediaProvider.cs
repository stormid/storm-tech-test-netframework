using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards
{
    //task 4
    public interface IMediaProvider
    {
        string GetFilePath(string id);
    }
}