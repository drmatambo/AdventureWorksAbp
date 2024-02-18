using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.DistrictCities;

public class DistrictCityAlreadyExistsException : BusinessException
{
    public DistrictCityAlreadyExistsException(string name) : base(AdventureWorksAbpDomainErrorCodes.DistrictCityNameAlreadyExists)
    {
        WithData("name", name);
    }
}
