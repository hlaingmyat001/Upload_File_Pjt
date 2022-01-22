using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace Upload_File_Pjt.Helper
{
    public class CSVFormat
    {
        public string transactionId { get; set; }
        public string amount { get; set; }
        public string currencyCode { get; set; }
        public string transactionDate { get; set; }
        public string status { get; set; }
    }

    class CsvAutomobileMapping : CsvMapping<CSVFormat>
    {
        public CsvAutomobileMapping() : base()
        {
            MapProperty(0, x => x.transactionId);
            MapProperty(1, x => x.amount);
            MapProperty(2, x => x.currencyCode);
            MapProperty(3, x => x.transactionDate);
            MapProperty(4, x => x.status);
        }
    }

   
}
