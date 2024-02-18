using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Localities;

public class LocalityAlreadyExistsException : BusinessException
{
    public LocalityAlreadyExistsException(string name) : base(AdventureWorksAbpDomainErrorCodes.LocalityNameAlreadyExists)
    {
        WithData("name", name);
    }
}
