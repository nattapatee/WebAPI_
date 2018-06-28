using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace SearchApi.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class SearchController : ControllerBase
    {
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
        [HttpPost]
        //ค้นหาไฟล์และที่อยู่REsult
        public IActionResult searchFile ([FromBody] SearchRe request)
        {
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
