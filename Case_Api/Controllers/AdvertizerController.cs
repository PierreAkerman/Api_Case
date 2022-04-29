using Case_Api.Data;
using Case_Api.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Case_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertizerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdvertizerController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Ads.Select(ad => new AdvertizerDto
            {
                Id = ad.Id,
                Title = ad.Title,
                DateCreated = ad.DateCreated,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,

            }).ToList());
        }
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var ad = _context.Ads.FirstOrDefault(e => e.Id == id);
            if (ad == null)
                return NotFound();
            var result = new AdvertizerDto
            {
                Id = ad.Id,
                Title = ad.Title,
                DateCreated = ad.DateCreated,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
            };
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Create(CreateAdvertizerDto ad)
        {
            var advertizer = new Advertizer()
            {
                Title = ad.Title,
                DateCreated = ad.DateCreated,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
            };
            _context.Ads.Add(advertizer);
            _context.SaveChanges();

            var adDto = new AdvertizerDto()
            {
                Id = advertizer.Id,
                Title = advertizer.Title,
                DateCreated = advertizer.DateCreated,
                Description = advertizer.Description,
                ImageUrl = advertizer.ImageUrl,
                Price = advertizer.Price,
            };
            return CreatedAtAction(nameof(GetOne), new { id = advertizer.Id }, adDto);
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateAdvertizerDto advertizer)
        {
            var ad = _context.Ads.FirstOrDefault(e => e.Id == id);
            if (ad == null) return NotFound();

            ad.Title = advertizer.Title;
            ad.DateCreated = advertizer.DateCreated;
            ad.Description = advertizer.Description;
            ad.ImageUrl = advertizer.ImageUrl;
            ad.Price = advertizer.Price;

            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var ad = _context.Ads.FirstOrDefault(e => e.Id == id);
            if (ad == null) return NotFound();
            _context.Ads.Remove(ad);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
