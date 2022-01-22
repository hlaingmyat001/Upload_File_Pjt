using CsvHelper;
using System.Data;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;
using TinyCsvParser;
using Upload_File_Pjt.Models;
using Upload_File_Pjt.Repository;

namespace Upload_File_Pjt.Helper
{
    public class UploadHelper
    {

        private readonly UploadRepository uploadRepository;

        public UploadHelper(UploadRepository _xMLUploadRepository)
        {
            uploadRepository = _xMLUploadRepository;
        }
        public bool parseXML(string filePath)
        {
            using (var fileStream = File.Open(filePath, FileMode.Open))
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(TransactionsData));
                    var xmlData = (TransactionsData)serializer.Deserialize(fileStream);
                    CultureInfo cultures = new CultureInfo("en-US");

                    List<XMLUpload> xmlDataList = new List<XMLUpload>();
                    foreach (var item in xmlData.Transactions)
                    {
                        XMLUpload xMLUpload = new XMLUpload();
                        xMLUpload.tranId = item.Id;
                        xMLUpload.amount = Convert.ToDecimal(item.PaymentDetails.Amount,cultures);
                        xMLUpload.status = item.Status;
                        xMLUpload.tranDate = Convert.ToDateTime(item.TransactionDate);
                        xMLUpload.currencyCode = item.PaymentDetails.CurrencyCode;
                        xmlDataList.Add(xMLUpload);
                    }
                    uploadRepository.addNewXML(xmlDataList);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                  return false;
                }
                
            }
        }

        public bool parseCSV(string filePath)
        {
            try
            {
                CultureInfo cultures = new CultureInfo("en-US");
                CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
                var csvParser = new CsvParser<CSVFormat>(csvParserOptions, new CsvAutomobileMapping());

                var records = csvParser.ReadFromFile(filePath, Encoding.UTF8);

                IEnumerable<CSVFormat> csvData = records.Select(x => x.Result).ToList();

                List<CSVUpload> csvDataList = new List<CSVUpload>();
                foreach (CSVFormat csvFormat in csvData)
                {
                    CSVUpload csvUpload = new CSVUpload();
                    csvUpload.tranIdentificator = csvFormat.transactionId;
                    csvUpload.amount = Convert.ToDecimal(csvFormat.amount,cultures);
                    csvUpload.currencyCode = csvFormat.currencyCode;
                    csvUpload.tranDate = DateTime.ParseExact(csvFormat.transactionDate, "dd/MM/yyyy hh:mm:ss", null);
                    csvUpload.status = csvFormat.status;
                    csvDataList.Add(csvUpload);
                }

                uploadRepository.addNewCSV(csvDataList);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex);
                return false;
            }
        }
    }
}
