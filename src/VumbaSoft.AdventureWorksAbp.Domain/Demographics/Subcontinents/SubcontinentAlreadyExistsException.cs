using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

public class SubcontinentAlreadyExistsException : BusinessException
{
    public SubcontinentAlreadyExistsException(string name) : base(AdventureWorksAbpDomainErrorCodes.SubContinentNameAlreadyExists)
    {
        WithData("name", name);
    }
}
