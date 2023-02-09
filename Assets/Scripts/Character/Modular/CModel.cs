using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cmodel", menuName = "CharacterModule / Model", order = 1)]
public class CModel : ScriptableObject
{
    [SerializeField]
    private GameObject model;
    [SerializeField]
    private ModelType type;
    [SerializeField]
    private int priority;
}

public enum ModelType { BaseModel, Accessory, ArmAccessory, Necklace, Shirt, Pants, Tattoo, Nose }//placeholder categories, can be replaced with anything
