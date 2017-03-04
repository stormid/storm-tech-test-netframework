using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    [Category("Media")]
    public class WhenAccessingAValidCard : MediaServiceContext
    {
        protected string _result;

        protected override void Because()
        {
            _result = _mediaService.GetCardPath("HERO_09");
        }

        [Test]
        public void ShouldReturnExpectedFilePath()
        {
            _result.ShouldContain("HERO_09.png");
        }
    }
}
