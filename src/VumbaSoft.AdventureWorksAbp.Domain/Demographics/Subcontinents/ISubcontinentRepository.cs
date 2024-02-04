using System;
using Volo.Abp.Domain.Repositories;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public interface ISubcontinentRepository : IRepository<Subcontinent, Guid>
{
}
