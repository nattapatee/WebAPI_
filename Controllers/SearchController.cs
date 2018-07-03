using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System.IO;

namespace SearchApi.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class SearchController : ControllerBase
    {
        ILogger<SearchController> logger;

        public SearchController(ILogger<SearchController> logger) {
            this.logger = logger;
        }
        
        //ค้นหาไฟล์ว่ามีไฟล์ไหมในตำแหน่งนนี้ๆ
        private(bool,string) Varlidate (SearchRe request)
        {
            
            if(string.IsNullOrEmpty(request.Path)||!Directory.Exists(request.Path)){
                return (false,"Invalid Path");
            } else if (string.IsNullOrEmpty(request.Pattern))
            {
                return (false,"Invalid Pattern000");
            }
           
            //ทำงานต่อ
            return (true,"");
        }

        //หาชื่อไฟล์
        private string[] GetFile (string path,string Pattern) =>
            Directory.GetFiles(path,Pattern,SearchOption.AllDirectories);
  
        

        // POST api/values
       
        //ค้นหาไฟล์และที่อยู่REsult
         [HttpPost]
         public IActionResult SearchFile ([FromBody] SearchRe request)
        {
        logger.LogInformation("กำลังค้นหา {@Resut}", request);
        
          var(ok,error) = Varlidate(request);

          if(ok)
          {
              var file = GetFile(request.Path,request.Pattern);
              return Ok(file);
          }
          else 
          {
              return BadRequest(error);
          }
        }        


    }
}
