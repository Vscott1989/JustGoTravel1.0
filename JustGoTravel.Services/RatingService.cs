using JustGoTravel.Data;
using JustGoTravel.Models.Rating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Services
{
   public class RatingService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        private readonly Guid _userId;

        public RatingService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateRating(RatingCreate model)
        {
            var entity = new Rating()
            {
                AuthorID = _userId,
                StarRating = model.StarRating,
                HotelRating = model.HotelRating,
                FoodRating = model.FoodRating,
            };
            
            
                _context.Ratings.Add(entity);
                return _context.SaveChanges() == 1;
            
        }
        public IEnumerable<RatingListItem> GetRating()
        {            
                var query = _context
                    .Ratings
                    .Where(e => e.AuthorID == _userId)
                    .Select(e => new RatingListItem
                    {
                        ID = e.ID,
                        StarRating = e.StarRating,
                        HotelRating = e.HotelRating,
                        FoodRating = e.FoodRating
                        
                    });
                return query.ToArray();    
        }

    }
}
