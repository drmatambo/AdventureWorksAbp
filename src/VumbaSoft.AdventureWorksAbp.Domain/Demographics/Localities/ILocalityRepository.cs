using System;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public interface ILocalityRepository : IRepository<Locality, Guid>
{
}
