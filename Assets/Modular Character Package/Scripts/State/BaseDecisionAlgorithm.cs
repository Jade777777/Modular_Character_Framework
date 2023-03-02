using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ModularCharacter
{
    public abstract class BaseDecisionAlgorithm : ScriptableObject
    {
        public abstract float CheckDecesion(CharacterCore character);
    }
}