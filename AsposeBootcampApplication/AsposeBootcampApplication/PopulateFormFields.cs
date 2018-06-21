using Aspose.Pdf.Cloud.Sdk.Api;
using Aspose.Pdf.Cloud.Sdk.Model;
using Aspose.Storage.Cloud.Sdk.Api;
using System.Collections.Generic;
using System.Configuration;

namespace AsposeBootcampApplication
{
    public class PopulateFormFields
    {
        private readonly string _appKey;
        private readonly string _appSID;

        public PopulateFormFields()
        {
            _appKey = ConfigurationManager.AppSettings["APP_KEY"];
            _appSID = ConfigurationManager.AppSettings["APP_SID"];
        }

        public string Populate(string fileName)
        {
            var target = new PdfApi(_appKey, _appSID);
            var storageApi = new StorageApi(_appKey, _appSID);

            Fields body = GetFieldDataList();

            FieldsResponse apiResponse = target.PutUpdateFields(fileName, body);

            if (apiResponse != null && apiResponse.Status.Equals("OK"))
            {
                Fields field = apiResponse.Fields;

            }

            return apiResponse.Status;

        }

        private static Fields GetFieldDataList()
        {
            return new Fields
            {
                List = new List<Field>
                {
                    new Field
                    {
                        Name = "First Name",
                        Values = new List<string>
                        {
                            "Jane"
                        }
                    },
                    new Field
                    {
                        Name = "Surname",
                        Values = new List<string>
                        {
                            "Doe"
                        }
                    },
                    new Field
                    {
                        Name = "DateOfBirthField",
                        Values = new List<string>
                        {
                            "1975-08-01"
                        }
                    },
                    new Field
                    {
                        Name = "GrossSalary",
                        Values = new List<string>
                        {
                            "1500"
                        }
                    },
                    new Field
                    {
                        Name = "Tax",
                        Values = new List<string>
                        {
                            "500"
                        }
                    },
                    new Field
                    {
                        Name = "AccomodationCost",
                        Values = new List<string>
                        {
                            "200"
                        }
                    },
                    new Field
                    {
                        Name = "CellphoneCost",
                        Values = new List<string>
                        {
                            "100"
                        }
                    },
                    new Field
                    {
                        Name = "CreditCardCost",
                        Values = new List<string>
                        {
                            "100"
                        }
                    },
                    new Field
                    {
                        Name = "OtherCost",
                        Values = new List<string>
                        {
                            "100"
                        }
                    }
                }
            };
        }
    }
}
