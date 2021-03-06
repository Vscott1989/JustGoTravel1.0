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
                HotelRating = model.HotelRating,
                FoodRating = model.FoodRating,
                VacationPackID = model.VacationPackID
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
                    VactionPackID = e.VacationPackID,
                    VacationPackName = _context.Ratings
                    .FirstOrDefault(x => x.VacationPackID == e.VacationPackID)
                    .VacationPack.Title
                    

                });
            return query.ToArray();
        }
        public RatingDetail GetRatingById(int id)
        {
            var entity = _context
                .Ratings
                .Single(e => e.ID == id && e.AuthorID == _userId);
            return new RatingDetail
            {
                ID = entity.ID,
                VacationPackID = entity.VacationPackID,
                VacationPackName = _context.Ratings
                 .FirstOrDefault(x => x.VacationPackID == entity.VacationPackID)
                 .VacationPack.Title,
                StarRating = entity.StarRating,
                HotelRating = entity.HotelRating,
                FoodRating = entity.FoodRating,

            };
        }
        public bool UpdateRating(RatingEdit model)
        {
            var entity = _context
                .Ratings
                .Single(e => e.ID == model.ID && e.AuthorID == _userId);


            entity.HotelRating = model.HotelRating;
            entity.FoodRating = model.FoodRating;


            return _context.SaveChanges() == 1;

        }
        public bool DeleteRating(int id)
        {
            var entity = _context
                .Ratings
                .Single(e => e.ID == id && e.AuthorID == _userId);
            _context.Ratings.Remove(entity);

            return _context.SaveChanges() == 1;
        }
    }
}
