using System;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public interface ICountryRepository : IRepository<Country, Guid>
{
}
