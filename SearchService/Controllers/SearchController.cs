using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchService.Infrastructure;

namespace SearchService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IHotelSearcher hotelSearcher;

        public SearchController(IHotelSearcher hotelSearcher)
        {
            this.hotelSearcher = hotelSearcher;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> SearchHotels([FromQuery]string searchTerm)
        {
            return Ok(hotelSearcher.Search(searchTerm));
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> SearchUsers()
        {
            return new string[] { "value1", "value2" };
        }



        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
