using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Storage.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Model.Requests;
using System.Configuration;
using System.IO;

namespace AsposeBootcampApplication
{
    public class UploadPdfFile
    {
        private readonly string _appKey;
        private readonly string _appSID;

        public UploadPdfFile()
        {
            _appKey = ConfigurationManager.AppSettings["APP_KEY"];
            _appSID = ConfigurationManager.AppSettings["APP_SID"];
        }
        public UploadResponse UploadFile(string name, string pdfPath)
        {
            var storageApi = new StorageApi(_appKey, _appSID);

            using (var stream = new FileStream(pdfPath, FileMode.Open))
            {
                var request = new PutCreateRequest(name, stream);
                var storeFile = storageApi.PutCreate(request);
                return storeFile;
            }

        }
    }
}

