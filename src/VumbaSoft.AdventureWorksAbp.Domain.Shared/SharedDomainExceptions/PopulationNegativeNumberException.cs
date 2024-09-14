using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp;

namespace VumbaSoft.AdventureWorksAbp.SharedDomainExceptions;

public class PopulationNegativeNumberException : BusinessException
{
    public PopulationNegativeNumberException(string population) 
        : base(AdventureWorksAbpDomainErrorCodes.PopulationNegativeNumberNotAllowed)
    {
        WithData("population", population);
    }
}
