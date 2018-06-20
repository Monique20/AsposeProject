using NUnit.Framework;
using System.IO;

namespace AsposeBootcampApplication.Tests
{
    [TestFixture]
    public class AsposeApplicationTests
    {
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
