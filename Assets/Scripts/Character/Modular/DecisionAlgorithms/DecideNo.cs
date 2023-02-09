using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "decideNo", menuName = "DecisionAlgorithm/DecideNo", order = 1)]
public class DecideNo : BaseDecisionAlgorithm
{
    public override float CheckDecesion(Character character)
    {
        return 0;
    }

}
