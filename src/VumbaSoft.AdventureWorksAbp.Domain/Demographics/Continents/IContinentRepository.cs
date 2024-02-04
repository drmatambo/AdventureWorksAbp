using System;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public interface IContinentRepository : IRepository<Continent, Guid>
{
}
