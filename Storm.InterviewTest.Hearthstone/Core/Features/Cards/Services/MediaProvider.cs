using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Storm.InterviewTest.Hearthstone.Core.Features.Cards.Services
{
    //task 4
    public class MediaProvider : IMediaProvider
    {
        private string _mediaSourceUrl;
        private string _mediaDirectory;

        public MediaProvider(string mediaDirectory, string mediaSource)
        {
            _mediaSourceUrl = mediaSource;
            _mediaDirectory = mediaDirectory;
            Directory.CreateDirectory(_mediaDirectory);
        }

        public string GetFilePath(string id)
        {
            var cardFilename = string.Format("{0}.png", id);       
            var localFile = Path.Combine(_mediaDirectory, cardFilename);

            if (!System.IO.File.Exists(localFile))
            {
                DownloadFromSource(id, localFile);
            }

            return localFile;

        }

        private void DownloadFromSource(string cardId, string localFile)
        {
            var client = new WebClient();

            try {
                client.DownloadFile(string.Format(_mediaSourceUrl, cardId), localFile);
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}