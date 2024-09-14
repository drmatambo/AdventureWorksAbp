using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class NegativeNumberNotAllowedException : BusinessException
{
    public NegativeNumberNotAllowedException(string population) 
        : base(AdventureWorksAbpDomainErrorCodes.PopulationNegativeNumberNotAllowed)
    {
        WithData("population", population);
    }
}
