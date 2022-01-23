using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Upload_File_Pjt.Helper;
using Upload_File_Pjt.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Upload_File_Pjt.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class XMLApiController : ControllerBase
    {
        private readonly UploadContext _context = null;
        private ApiHelper _apiHelper = new ApiHelper();

        public XMLApiController(UploadContext context)
        {
            _context = context;
        }

        // GET: api/<XMLApiController>
        [HttpGet]
        public List<apiReturnFormat> Get()
        {
            var xmlData  = _context.xmlUploads.ToList();
            return _apiHelper.convertJSONDataForXML(xmlData);
           
        }

        // GET api/XMLApi/byCurrency/USD
        [HttpGet("byCurrency/{currency}")]
        public List<apiReturnFormat> GetByCurrency(string currency)
        {
            var xmlData = _context.xmlUploads.ToList().Where(x=>x.currencyCode.Equals(currency)).ToList();
            return _apiHelper.convertJSONDataForXML(xmlData);
        }

        // GET api/XMLApi/byDateRange/2019-01-01,2019-01-10
        [HttpGet("byDateRange/{dateRange}")]
        public List<apiReturnFormat> GetByDateRange(string dateRange)
        {
            try
            {
                DateTime from = DateTime.ParseExact(dateRange.Split(',')[0], "yyyy-MM-dd", null);
                DateTime to = DateTime.ParseExact(dateRange.Split(',')[1], "yyyy-MM-dd", null);
                var xmlData = _context.xmlUploads.ToList().Where(x => x.tranDate>from && x.tranDate<to).ToList();
                return _apiHelper.convertJSONDataForXML(xmlData);
            }catch (Exception ex)
            {
                return null;
            }
          
        }

        // GET api/XMLApi/byStatus/Done
        [HttpGet("byStatus/{status}")]
        public List<apiReturnFormat> GetByStatus(string status)
        {
            var xmlData = _context.xmlUploads.ToList().Where(x => x.status.Equals(status)).ToList();
            return _apiHelper.convertJSONDataForXML(xmlData);

        }

    }
}
