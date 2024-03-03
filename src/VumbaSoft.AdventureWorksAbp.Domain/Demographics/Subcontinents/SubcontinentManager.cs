using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;


public class SubcontinentManager : DomainService
{
    private readonly ISubcontinentRepository _subcontinentRepository;
    public SubcontinentManager(ISubcontinentRepository subcontinentRepository)
    {
        _subcontinentRepository = subcontinentRepository;
    }


}
