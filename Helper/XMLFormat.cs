using System.Xml.Serialization;

namespace Upload_File_Pjt.Helper
{
    public class TransactionsData
    {
        public List<Transaction> Transactions { get; set; }

        public TransactionsData() { Transactions = new List<Transaction>(); }
    }

    public class Transaction
    {
        [XmlAttribute("id")]
        public string Id { get; set; }
        [XmlElement]
        public string TransactionDate { get; set; }
        [XmlElement]
        public PaymentDetails PaymentDetails { get; set; }
        [XmlElement]
        public string Status { get; set; }
        
    }

    public class PaymentDetails
    {
        [XmlElement]
        public string Amount { get; set; }
        [XmlElement]
        public string CurrencyCode { get; set; }
    }
}
