using System.IO;
using Storm.InterviewTest.Hearthstone.Core.Features.Media;
using Storm.InterviewTest.Hearthstone.Core.Features.Media.Services;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    public class MediaServiceContext : ContextSpecification
    {
        protected IMediaService _mediaService;

        protected override void SharedContext()
        {
            _mediaService = new MediaService(Path.Combine(Directory.GetCurrentDirectory(), "TestMedia"));
        }
    }
}
