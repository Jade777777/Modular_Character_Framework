using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "decideYes", menuName = "DecisionAlgorithm/DecideYes", order = 1)]
public class DecideYes : BaseDecisionAlgorithm
{
    public override float CheckDecesion(CharacterCore character)
    {
        return 1;
    }

}
