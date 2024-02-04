using System;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public interface IRegionRepository : IRepository<Region, Guid>
{
}
