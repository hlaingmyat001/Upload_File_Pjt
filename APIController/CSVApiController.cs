using Microsoft.AspNetCore.Mvc;
using Upload_File_Pjt.Helper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Upload_File_Pjt.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSVApiController : ControllerBase
    {
        private readonly UploadContext _context = null;
        private ApiHelper _apiHelper = new ApiHelper();

        public CSVApiController(UploadContext context)
        {
            _context = context;
        }

        // GET: api/<CSVApiController>
        [HttpGet]
        public List<apiReturnFormat> Get()
        {
            var csvData = _context.cSVUploads.ToList();
            return _apiHelper.convertJSONDataForCSV(csvData);

        }

        // GET api/CSVApi/byCurrency/USD
        [HttpGet("byCurrency/{currency}")]
        public List<apiReturnFormat> GetByCurrency(string currency)
        {
            var csvData = _context.cSVUploads.ToList().Where(x => x.currencyCode.Equals(currency)).ToList();
            return _apiHelper.convertJSONDataForCSV(csvData);
        }

        // GET api/CSVApi/byDateRange/2019-01-01,2019-01-10
        [HttpGet("byDateRange/{dateRange}")]
        public List<apiReturnFormat> GetByDateRange(string dateRange)
        {
            try
            {
                DateTime from = DateTime.ParseExact(dateRange.Split(',')[0], "yyyy-MM-dd", null);
                DateTime to = DateTime.ParseExact(dateRange.Split(',')[1], "yyyy-MM-dd", null);
                var csvData = _context.cSVUploads.ToList().Where(x => x.tranDate > from && x.tranDate < to).ToList();
                return _apiHelper.convertJSONDataForCSV(csvData);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        // GET api/CSVApi/byStatus/Done
        [HttpGet("byStatus/{status}")]
        public List<apiReturnFormat> GetByStatus(string status)
        {
            var csvData = _context.cSVUploads.ToList().Where(x => x.status.Equals(status)).ToList();
            return _apiHelper.convertJSONDataForCSV(csvData);

        }
    }
}
