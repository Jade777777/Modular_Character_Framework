using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CAttribute
{
    [SerializeField]
    private StatType type;

    [SerializeField]
    private float value;

    public float GetValue()
    {
        return value;
    }
    public StatType GetStatType()
    {
        return type;
    }
}

public enum StatType { Dexterity, Health, Vitality, Strength, Intrinsic  }//placeholder categories, can be replaced with anything