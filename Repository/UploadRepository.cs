using Upload_File_Pjt.Models;

namespace Upload_File_Pjt.Repository
{
    public class UploadRepository
    {
        private readonly UploadContext _context = null;

        public UploadRepository(UploadContext context)
        {
            _context = context;
        }

        public bool addNewXML(List<XMLUpload> xMLUploadList)
        {
            foreach (var xMLUpload in xMLUploadList)
            {
                var newXML = new XMLUpload()
                {
                    tranId = xMLUpload.tranId,
                    tranDate = xMLUpload.tranDate,
                    amount = xMLUpload.amount,
                    currencyCode = xMLUpload.currencyCode,
                    status = xMLUpload.status
                };
                _context.Add(newXML);
            }
            _context.SaveChanges();

            return true;
        }

        public bool addNewCSV(List<CSVUpload> csvUploadList)
        {
            foreach(var csvUpload in csvUploadList)
            {
                var newCSV = new CSVUpload()
                {
                    tranIdentificator = csvUpload.tranIdentificator,
                    tranDate = csvUpload.tranDate,
                    currencyCode = csvUpload.currencyCode,
                    amount = csvUpload.amount,
                    status = csvUpload.status
                };
                _context.Add(newCSV);
            }
            _context.SaveChanges();

            return true;
        }

    }
}
