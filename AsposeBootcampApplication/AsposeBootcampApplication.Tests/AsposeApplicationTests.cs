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
            var fileName = "AsposeBootcampForm1.pdf";
            PopulateFormFields sut = new PopulateFormFields();

            //Act
            var actual = sut.Populate(fileName);

            //Assert
            Assert.AreEqual("OK", actual);

        }

        [Test]
        public void GivenRecords_ShouldSaveANewFileWithReadOnlyFieldsAndReturnResponse200()
        {
            //Arrange
            string populatedFile = "AsposeBootcampFormPopulated.pdf";
            string readOnlyFile = "AsposeBootcampFormReadOnly.pdf";
            var sut = new DisableFields();

            var baseDirectory = TestContext.CurrentContext.TestDirectory;
            var populatedFilePath = Path.Combine(baseDirectory, populatedFile);
            var readOnlyFilePath = Path.Combine(baseDirectory, readOnlyFile);

            //Act
            sut.Disable(populatedFilePath, readOnlyFilePath);

            //Assert
            var populatedFileByteSize = File.ReadAllBytes(populatedFilePath);
            var readonlyFileByteSize = File.ReadAllBytes(readOnlyFilePath);
            Assert.AreNotEqual(populatedFileByteSize, readonlyFileByteSize);

        }
        
    }
   
}
