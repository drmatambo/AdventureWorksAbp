using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using VumbaSoft.AdventureWorksAbp.Demographics.Subcontinents;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Continents;

public class Continent : FullAuditedAggregateRoot<Guid>
{
    public virtual String Name { get; set; }
    public virtual Int64 Population { get; set; }
    public virtual ICollection<Subcontinent> Subcontinents { get; set; }
    public virtual String Remarks { get; set; }

    protected Continent()
    {
    }

    public Continent(
        Guid id,
        String name,
        Int64 population,
        String remarks
    ) : base(id)
    {
        //SetName(name);
        //TODO: Pending continent data validating
        Name = name;
        Population = population;
        Remarks = remarks;
        Subcontinents = new Collection<Subcontinent>();
    }

    internal Continent ChangeName(string name)
    {
        SetName(name);
        return this;
    }

    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: AdventureWorksAbpSharedConsts.NameMaxLength
        );
    }
}

