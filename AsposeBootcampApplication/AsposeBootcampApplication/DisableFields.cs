using iTextSharp.text.pdf;
using System.IO;

namespace AsposeBootcampApplication
{
    public class DisableFields
    {
        public void Disable(string populatedFilePath, string readOnlyFile)
        {
            PdfReader reader = new PdfReader(populatedFilePath);

            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(readOnlyFile, FileMode.Create)))
            {
                AcroFields fields = stamper.AcroFields;

                fields.SetFieldProperty("First Name", "setfflags", PdfFormField.FF_READ_ONLY, null);
                fields.SetFieldProperty("Surname", "setfflags", PdfFormField.FF_READ_ONLY, null);
                fields.SetFieldProperty("DateOfBirthField", "setfflags", PdfFormField.FF_READ_ONLY, null);

                stamper.Close();
            }
            
        }
    }
}
