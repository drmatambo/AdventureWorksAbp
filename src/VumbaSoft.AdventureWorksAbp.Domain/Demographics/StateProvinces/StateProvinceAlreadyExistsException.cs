using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.StateProvinces;

public class StateProvinceAlreadyExistsException : BusinessException
{
    public StateProvinceAlreadyExistsException(string name) : base(AdventureWorksAbpDomainErrorCodes.StateProvinceNameAlreadyExists)
    {
        WithData("name", name);
    }
}
