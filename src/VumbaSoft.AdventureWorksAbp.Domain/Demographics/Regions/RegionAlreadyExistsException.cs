using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Regions;

public class RegionAlreadyExistsException : BusinessException
{
    public RegionAlreadyExistsException(string name) : base(AdventureWorksAbpDomainErrorCodes.RegionNameAlreadyExists)
    {
        WithData("name", name);
    }
}
