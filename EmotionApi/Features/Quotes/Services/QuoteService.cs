using Catstagram.Server.Data;
using EmotionApi.Data.Models;
using EmotionApi.Features.Quotes.Models;
using EmotionApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionApi.Features.Quotes.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly ApplicationDbContext _context;

        public QuoteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<QuoteResponseModel> Get_Quote(QuoteRequestModel model)
        {
            var result = await _context.Quotes.Where(q => q.author.CountryId == model.CountryId && q.Lang == model.Lang && q.MoodId == model.MoodId)
                .Select(q => new QuoteResponseModel
                {
                    Quote = q.Context,
                    AuthorName = q.author.Name
                }).ToListAsync();

            return result.PickRandom();
        }

        
        public async Task<List<Quote>> Get_Quotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        public async Task<List<Quote>> Get_Quotes_by_Country(int countryId)
        {
            var result = await _context.Quotes.Where(q => q.author.CountryId == countryId).ToListAsync();

            return result;
        }
    }

}
