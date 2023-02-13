using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CAttribute
{
    [SerializeField]
    private float value;
    [SerializeField]
    private StatType type;
}

public enum StatType { Dexterity, Health, Vitality, Strength, Intrinsic  }//placeholder categories, can be replaced with anything