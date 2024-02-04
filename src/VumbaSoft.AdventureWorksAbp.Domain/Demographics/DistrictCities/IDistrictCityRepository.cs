using System;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public interface IDistrictCityRepository : IRepository<DistrictCity, Guid>
{
}
