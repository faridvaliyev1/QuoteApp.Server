using Catstagram.Server.Features;
using EmotionApi.Features.Quotes.Models;
using EmotionApi.Features.Quotes.Services;
using EmotionApi.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace EmotionApi.Features.Quotes
{
    [Authorize]
    public class QuoteController : ApiController
    {
        private readonly IQuoteService _quoteService;
        private static IWebHostEnvironment _hostEnvironment;
        
        public QuoteController(IQuoteService quoteService,IWebHostEnvironment hostEnvironment)
        {
            _quoteService = quoteService;
            _hostEnvironment = hostEnvironment;
        }
                  
        public class FileUploadModel
        {
           public QuoteRequestModel model { get; set; }

           public IFormFile file { get; set; }
        }

        [HttpPost]
        [Route(nameof(Quote))]
        public async Task<ActionResult<QuoteResponseModel>> Quote(FileUploadModel model)
        {
           if(model.file.Length>0)
            {
                try
                {
                    if(!Directory.Exists(_hostEnvironment.WebRootPath+"\\uploads"))
                    {
                        Directory.CreateDirectory(_hostEnvironment.WebRootPath + "\\upload");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_hostEnvironment.WebRootPath + "\\uploads\\" + model.file.FileName))
                    {
                       await model.file.CopyToAsync(fileStream);
                       fileStream.Flush();
                        
                    }
                }
                catch
                {
                    return BadRequest();
                }


                var path = _hostEnvironment.WebRootPath + "\\uploads\\" + model.file.FileName;

                string emotion =await HelpFunctions.detectEmotion(path);


            }
           else
            {
                return BadRequest();
            }
        }

    }
}
