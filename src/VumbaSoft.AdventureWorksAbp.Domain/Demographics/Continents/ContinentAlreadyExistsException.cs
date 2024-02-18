using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class ContinentAlreadyExistsException : BusinessException
{
    public ContinentAlreadyExistsException(string name) : base(AdventureWorksAbpDomainErrorCodes.ContinentNameAlreadyExists)
    {
        WithData("name", name);
    }    
}
