using System.Collections.Generic;

public class CharacterAttributeHandler
{

    private List<CAttribute> attributes;
    private Dictionary<StatType,CAttribute> sortedAttributes;

    public CharacterAttributeHandler(List<CAttribute> attributes)
    {
        this.attributes = attributes;
    }

    public float GetAttributeValue(StatType statType)
    {
        return 0;
    }
    public void AddStat(CAttribute attribute) 
    {
        attributes.Add(attribute); 
    }
    public void RemoveStat(CAttribute attribute)
    {
        attributes.Remove(attribute);
    }
}
