using EmotionApi.Data.Models;
using EmotionApi.Features.Quotes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmotionApi.Features.Quotes.Services
{
    public interface IQuoteService
    {
      public Task<QuoteResponseModel> Get_Quote(QuoteRequestModel model);
      public Task<List<Quote>> Get_Quotes();
      public Task<List<Quote>>Get_Quotes_by_Country(int countryId);
    }
}
