using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetSimpleMVC.Models
{
	public class WorldRepository : IWorldRepository
	{
		private WorldContext _context;

		public WorldRepository(WorldContext context)
		{
			_context = context;
		}

		public IEnumerable<Trip> GetAllTrips()
		{
			return _context.Trips.ToList();
		}
	}
}
