using Newtonsoft.Json;
using Upload_File_Pjt.Models;

namespace Upload_File_Pjt.Helper
{
    public class ApiHelper
    {
        public List<apiReturnFormat> convertJSONDataForXML(List<XMLUpload> xmlList)
        {
            List<apiReturnFormat> jsonList = new List<apiReturnFormat>();

            foreach (XMLUpload xmlUpload in xmlList)
            {
                apiReturnFormat json = new apiReturnFormat();
                json.id = xmlUpload.tranId;
                json.payment = xmlUpload.amount + " " + xmlUpload.currencyCode;
                switch(xmlUpload.status)
                {
                    case "Approved":json.status = "A";break;
                    case "Rejected": json.status = "R"; break;
                    case "Done": json.status = "D"; break;
                        default:json.status = "NONE";break;
                }
                jsonList.Add(json);
            }
            return jsonList;
        }

        public List<apiReturnFormat> convertJSONDataForCSV(List<CSVUpload> csvList)
        {
            List<apiReturnFormat> jsonList = new List<apiReturnFormat>();

            foreach (CSVUpload csvUpload in csvList)
            {
                apiReturnFormat json = new apiReturnFormat();
                json.id = csvUpload.tranIdentificator;
                json.payment = csvUpload.amount + " " + csvUpload.currencyCode;
                switch (csvUpload.status)
                {
                    case "Approved": json.status = "A"; break;
                    case "Failed": json.status = "R"; break;
                    case "Finished": json.status = "D"; break;
                    default: json.status = "NONE"; break;
                }
                jsonList.Add(json);
            }
            return jsonList;
        }
    }

    public class apiReturnFormat
    {
        public string id { get; set; }
        public string payment { get; set; }
        public string status { get; set; }
    }
}
