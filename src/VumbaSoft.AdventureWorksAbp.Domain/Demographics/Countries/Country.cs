using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using VumbaSoft.AdventureWorksAbp.Demographics.Regions;

namespace VumbaSoft.AdventureWorksAbp.Demographics.Countries;
public class Country : FullAuditedAggregateRoot<Guid>
{
    public virtual Guid ContinentId { get; set; }
    public virtual Guid SubcontinentId { get; set; }
    public virtual String Name { get; set; }
    public virtual String FormalName { get; set; }
    public virtual String NativeName { get; set; }
    public virtual String IsoTreeCode { get; set; }
    public virtual String IsoTwoCode { get; set; }
    public virtual String CcnTreeCode { get; set; }
    public virtual String PhoneCode { get; set; }
    public virtual String Capital { get; set; }
    public virtual String Currency { get; set; }
    public virtual Int64 Population { get; set; }
    public virtual String Emoji { get; set; }
    public virtual String EmojiU { get; set; }
    //public virtual Subcontinent Subcontinent { get; set; } //Navigation property
    public virtual ICollection<Region> Regions { get; set; }
    public virtual String Remarks { get; set; }

    protected Country()
    {
    }

    public Country(
        Guid id,
        Guid continentId,
        Guid subcontinentId,
        String name,
        String formalName,
        String nativeName,
        String isoTreeCode,
        String isoTwoCode,
        String ccnTreeCode,
        String phoneCode,
        String capital,
        String currency,
        Int64 population,
        String emoji,
        String emojiU,
        String remarks
    ) : base(id)
    {
        ContinentId = continentId;
        SubcontinentId = subcontinentId;
        Name = name;
        FormalName = formalName;
        NativeName = nativeName;
        IsoTreeCode = isoTreeCode;
        IsoTwoCode = isoTwoCode;
        CcnTreeCode = ccnTreeCode;
        PhoneCode = phoneCode;
        Capital = capital;
        Currency = currency;
        Population = population;
        Emoji = emoji;
        EmojiU = emojiU;
        Remarks = remarks;
        Regions = new Collection<Region>();
    }
}

