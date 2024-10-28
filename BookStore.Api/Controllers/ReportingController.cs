using BookStore.Datas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportingController : ControllerBase
    {
        private readonly ReportingService _reportingService;

        public ReportingController(ReportingService reportingService)
        {
            _reportingService = reportingService;
        }

        // Endpoint for Query 1
        [HttpGet("authors-with-more-than-five-books")]
        public async Task<IActionResult> GetAuthorsWithMoreThanFiveBooks()
        {
            var authors = await _reportingService.GetAuthorsWithMoreThanFiveBooks();
            return Ok(authors);
        }

        // Endpoint for Query 2
        [HttpGet("average-book-price-by-country")]
        public async Task<IActionResult> GetAverageBookPriceByCountry()
        {
            var averagePrices = await _reportingService.GetAverageBookPriceByCountry();
            return Ok(averagePrices);
        }

        // Endpoint for Query 3
        [HttpGet("books-by-year")]
        public async Task<IActionResult> GetBooksByYear([FromQuery] int year)
        {
            var books = await _reportingService.GetBooksWithAuthorNameByYear(year);
            return Ok(books);
        }
    }
}
