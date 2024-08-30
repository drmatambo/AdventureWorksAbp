using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents
{
    public class ContinentWithDetails : FullAuditedAggregateRoot<Guid>
    {
        public Guid Id { get; set; }
        public String Name { get; set; }

        public Int64 Population { get; set; }

        public String Remarks { get; set; }

        public Collection<Subcontinent> Subcontinents { get; set; }// = new();
    }
}
