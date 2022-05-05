using AutoMapper;
using Case_Api.Data;
using Case_Api.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Case_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertizerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdvertizerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_context.Ads.Select(ad => _mapper.Map<AdvertizerDto>(ad)));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOne(int id)
        {
            var ad = _context.Ads.FirstOrDefault(e => e.Id == id);
            if (ad == null)
                return NotFound();

            var model = _mapper.Map<AdvertizerDto>(ad);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult Create(CreateAdvertizerDto ad)
        {
            var model = _mapper.Map<Advertizer>(ad);
            _context.Ads.Add(model);
            _context.SaveChanges();

            var modelDto = _mapper.Map<AdvertizerDto>(model);

            return CreatedAtAction(nameof(GetOne), new { id = model.Id }, modelDto);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateAdvertizerDto advertizer)
        {
            var ad = _context.Ads.FirstOrDefault(e => e.Id == id);
            if (ad == null) 
                return NotFound();

            _mapper.Map(advertizer, ad);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var ad = _context.Ads.FirstOrDefault(e => e.Id == id);
            if (ad == null) 
                return NotFound();

            _context.Ads.Remove(ad);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
