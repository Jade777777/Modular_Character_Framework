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
}
