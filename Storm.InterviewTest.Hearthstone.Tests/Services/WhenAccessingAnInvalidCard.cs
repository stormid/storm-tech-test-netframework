using NUnit.Framework;
using Storm.InterviewTest.Hearthstone.Tests.Specification;

namespace Storm.InterviewTest.Hearthstone.Tests.Services
{
    [Category("Media")]
    public class WhenAccessingAnInvalidCard : MediaServiceContext
    {
        protected string _result;

        protected override void Because()
        {
            _result = _mediaService.GetCardPath("HERO_666");
        }

        [Test]
        public void ShouldReturnExpectedNullResult()
        {
            _result.ShouldEqual(null);
        }
    }
}
