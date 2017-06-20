using System.Collections.Generic;

namespace DotnetSimpleMVC.Models
{
	public interface IWorldRepository
	{
		IEnumerable<Trip> GetAllTrips();
	}
}