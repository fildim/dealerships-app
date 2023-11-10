using AutoMapper;
using DEALERSHIPS_APP.Models;

namespace DEALERSHIPS_APP.Mappings
{
	public class OwnershipHistoryMapper : Profile
	{
		public OwnershipHistoryMapper()
		{
			CreateMap<OwnershipHistory, OwnershipHistory>();
		}
	}
}
