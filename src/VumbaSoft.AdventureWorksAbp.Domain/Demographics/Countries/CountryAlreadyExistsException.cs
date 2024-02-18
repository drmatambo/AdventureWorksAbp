using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;

public class CountryAlreadyExistsException : BusinessException
{
    public CountryAlreadyExistsException(string name) : base(AdventureWorksAbpDomainErrorCodes.CountryNameAlreadyExists)
    {
        WithData("name", name);
    }
}
