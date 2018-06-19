using Aspose.Pdf.Cloud.Sdk.Api;
using Aspose.Pdf.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Api;
using Aspose.Storage.Cloud.Sdk.Model.Requests;
using NUnit.Framework;
using System;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsposeBootcampApplication.Tests
{
    [TestFixture]
    public class AsposeApplicationTests
    {
        public static string APP_SID = "a5a98e2d-8812-42bf-bbbe-26d520d42df1";
        public static string APP_KEY = "fb4958b7801be5848696dc825cbe0896";


        [Test]
        public void GivenAPdfFile_ShouldUploadToTheCloudAndReturnResponse200()
        {

            //Arrange
            string name = "AsposeBootcampForm.pdf";

            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var pdfPath = Path.Combine(baseDirectory, name);

            UploadPdfFile sut = new UploadPdfFile();

            //Act
            var actual = sut.UploadFile(name, pdfPath);

            //Assert
            Assert.AreEqual(200, actual.Code);

        }

        [Test]
        public void GivenRecords_ShouldPopulateFieldsAndReturnResponse200()
        {
            //Arrange
            var fileName = "AsposeBootcampForm.pdf";
            PopulateFormFields sut = new PopulateFormFields();

            //Act
            var actual = sut.Populate(fileName);

            //Assert
            Assert.AreEqual("OK", actual);

        }

        [Test]
        public void GivenRecords_ShouldSetFieldsToReadOnlyAndReturnResponse200()
        {
            //Arrange
            string populatedFile = @"C:\Users\moniqueg\Desktop\src\AsposeBootcampFormPopulated.pdf";
            string readOnlyFile = @"C:\Users\moniqueg\Desktop\src\AsposeBootcampFormReadOnly.pdf";
            DisableFields sut = new DisableFields();

            //Act
            var actual = sut.Disable(populatedFile, readOnlyFile);

            //Assert
            Assert.AreEqual(readOnlyFile, actual);
        }


    }
}
