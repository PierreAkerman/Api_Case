using Microsoft.EntityFrameworkCore;

namespace Case_Api.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedAds();
        }

        public void SeedAds()
        {
            if (!_context.Ads.Any(e => e.Title == "Apple"))
            {
                _context.Ads.Add(new Advertizer
                {
                    Title = "Apple",
                    DateCreated = DateTime.Now,
                    Description = "This is an Apple add to get you hooked on our products!",
                    ImageUrl = "https://unsplash.com/photos/wAygsCk20h8",
                    Price = 5000,
                });
            }
            if (!_context.Ads.Any(e => e.Title == "Microsoft"))
            {
                _context.Ads.Add(new Advertizer
                {
                    Title = "Microsoft",
                    DateCreated = DateTime.Now,
                    Description = "This is an Microsoft add to get you hooked on our products!",
                    ImageUrl = "https://unsplash.com/photos/1uQe5BIiH8w",
                    Price = 6000,
                });
            }
            _context.SaveChanges();
        }
    }
}
