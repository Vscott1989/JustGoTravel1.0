using JustGoTravel.Data;
using JustGoTravel.Models.Agent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustGoTravel.Services
{
    public class AgentService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public AgentService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAgent(AgentCreate model)
        {
            var agent = new Agent()
            {
                AuthorId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Company = model.Company,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                LinkedIn = model.LinkedIn
            };
           
                _context.Agents.Add(agent);
                return _context.SaveChanges() > 0;
            
        }
        
        public IEnumerable<AgentListItem> GetAgents()
        {
                var query = _context
                    .Agents
                    .Where(e => e.AuthorId == _userId)
                    .Select(e => new AgentListItem
                    {
                        ID = e.ID,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Company = e.Company,
                        PhoneNumber= e.PhoneNumber,
                        Email = e.Email,
                        LinkedIn = e.LinkedIn

                    });
                return query.ToArray();
            
        }
    }
}
