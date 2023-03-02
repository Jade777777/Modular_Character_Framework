using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModifierHandler 
{
    private List<CModifier> modifiers;

    public CharacterModifierHandler(List<CModifier> modifiers)
    {
        this.modifiers = modifiers;
    }

    public void ActivateMod(CModifier modifier)
    {
        //TODO: establish connection with character core allong with timeline
        modifiers.Add(modifier);
    }
    public void ClearMod(CModifier modifier)
    {
        modifiers.Remove(modifier);
    }
}
