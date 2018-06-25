using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;

namespace AsposeBootcampApplication
{
    public class DisableFields
    {
        public void Disable(string populatedFilePath, string readOnlyFilePath)
        {
            PdfReader reader = new PdfReader(populatedFilePath);
            List<string> readOnlyFields = CreateList();

            using (PdfStamper stamper = new PdfStamper(reader, new FileStream(readOnlyFilePath, FileMode.Create)))
            {
                AcroFields fields = stamper.AcroFields;

                foreach (var value in readOnlyFields)
                {
                    fields.SetFieldProperty(value, "setfflags", PdfFormField.FF_READ_ONLY, null);
                }

                stamper.Close();
            }

        }

        private static List<string> CreateList()
        {
            return new List<string>
            {
                "First Name",
                "Surname",
                "DateOfBirthField"
            };
        }
    }
}
