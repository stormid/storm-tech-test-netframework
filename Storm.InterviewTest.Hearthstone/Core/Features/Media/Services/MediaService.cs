using System;
using System.IO;
using System.Net;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Media.Services
{
    public class MediaService : IMediaService
    {
        private readonly string localMediaPath;
        private const string cardImageUrl = "http://wow.zamimg.com/images/hearthstone/cards/enus/medium/{0}.png";

        public MediaService(string localMediaPath)
        {
            this.localMediaPath = localMediaPath;
            Directory.CreateDirectory(localMediaPath);
        }

        public string GetCardPath(string id)
        {
            var cardFilename = string.Format("{0}.png", id);
            var localFile = Path.Combine(localMediaPath, cardFilename);

            if (!File.Exists(localFile))
            {
                if (!DownloadFromSource(string.Format(cardImageUrl, id), localFile))
                {
                    return null;
                }
            }

            return localFile;
        }

        private bool DownloadFromSource(string url, string localFile)
        {
            var client = new WebClient();

            try
            {
                client.DownloadFile(url, localFile);
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}