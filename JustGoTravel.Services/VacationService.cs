using JustGoTravel.Data;
using JustGoTravel.Models.VacationPack;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Services
{
    public class VacationService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;

        public VacationService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateVacationPack(VacationCreate model)
        {
            var vacationPack = new VacationPack
            {
                Title = model.Title,
                TripLength = model.TripLength,
                TotalCost = model.TotalCost,
                Location = model.Location,
                Included = model.Included,
                Description = model.Description,
                TimeOfPublication = DateTimeOffset.Now,
                AgentID = model.AgentID,
                AuthorId = _userId

            };
            _context.VacationPacks.Add(vacationPack);
            return _context.SaveChanges() == 1;

        }
        public IEnumerable<VacationListItem> GetVacations()
        {

            var VacationEntities = _context.VacationPacks.ToList();
            var VacationList = VacationEntities.Select(e => new VacationListItem
            {
                ID = e.ID,
                AgentID = e.AgentID,
                Title = e.Title,
                TripLength = e.TripLength,
                TotalCost = e.TotalCost,
                Location = e.Location,
                Included = e.Included,
                Description = e.Description,
                TimeOfPublication = e.TimeOfPublication
            });
            return VacationList;
        }
        public VacationDetail GetVacationByID(int id)
        {
            var entity = _context
                .VacationPacks
                .Single(e => e.ID == id);
            return new VacationDetail
            {
                ID = entity.ID,
                AgentID = entity.AgentID,
                Title = entity.Title,
                TripLength = entity.TripLength,
                TotalCost = entity.TotalCost,
                Location = entity.Location,
                Included = entity.Included,
                Description = entity.Description,
                TimeOfPublication = entity.TimeOfPublication,
                ModifiedUtc = entity.ModifiedUtc
            };
        }
        public bool UpdateVacation(VacationEdit model)
        {
            var entity = _context
                .VacationPacks
                .Single(e => e.ID == model.ID && e.AuthorId == _userId);

            entity.AgentID = model.AgentID;
            entity.Title = model.Title;
            entity.TripLength = model.TripLength;
            entity.TotalCost = model.TotalCost;
            entity.Location = model.Location;
            entity.Included = model.Included;
            entity.Description = model.Description;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _context.SaveChanges() == 1;
        }
        public bool DeleteVacation(int id)
        {
            var entity = _context
                .VacationPacks
                .Single(e => e.ID == id && e.AuthorId == _userId);
            _context.VacationPacks.Remove(entity);

            return _context.SaveChanges() == 1;
        }
    }
}

