using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cstate", menuName = "CharacterModule/State", order = 1)]
public class CState : ScriptableObject
{
    
    
    [SerializeField]
    private GameObject moduleState;//This gameobject contains all of the logic for the state of the character. It's a gameobject so it can be literaly anything as long as it has a script that dervives from StateInstance
    [SerializeField]
    private List<StateType> stateType;
    [SerializeField]
    private List<DecisionData> decisionData;    //deffine how the state is entered, method to enable the state to exit
    [SerializeField]
    private int priority = 100;


    public GameObject GetModuleState()
    {
        return moduleState;
    }
    public List<StateType> GetStateType()
    {
        return stateType;
    }
    private float GetDecisionValue(Character character, List<StateType> currentState, CharacterInputType currentInput)//Get how likeley this decision is to occur
    {
        float decisionValue = 0;
        foreach(DecisionData data in decisionData)
        {
            decisionValue = Mathf.Max(decisionValue, data.GetDecisionValue(character, currentState, currentInput));
        }
        return decisionValue;
    }
    public static CState DecideNewState(List<CState> states, Character character, List<StateType> currentState, CharacterInputType currentInput)
    {
        CState finalState = null;
        float finalValue = 0;
        foreach(CState checkState in states)
        {
            float checkValue = checkState.GetDecisionValue(character, currentState, currentInput);


            if(checkValue > finalValue)
            {
                finalState = checkState;
                finalValue = checkValue;
            }
            else if(finalState!=null && checkValue == finalValue)
            {
                if(checkState.priority == finalState.priority)
                {
                    throw new System.Exception("Can't decide between multiple states with the same decision value, and the same priority");
                    //Debug.LogError("Can't decide between multiple states with the same decision value, and the same priority");
                }
                else if (checkState.priority> finalState.priority)
                {
                    finalState = checkState;
                }
            }



        }

        return finalState;
    }


}



public enum StateType { Idle, Running, Jumping, Sliding, Attacking, Dodging}

public enum CharacterInputType { Dodge, Jump, Run, Duck }

[System.Serializable]
public  class DecisionData// decide if the state is available for transfer, and give it a score of 0 to 1
{

    [SerializeField]
    private List<StateType> validState;// if it's in this state, the transition is possible
    [SerializeField]
    private List<CharacterInputType> validInput;//if the input is valid, the transistion is possible
    [SerializeField]
    private List<BaseDecisionAlgorithm> decisionAlgorithms;//if the decision value is greater than 0 the transition is possible. All Decision values are multiplied together to gather the final value. The highest value is activated.
    public float GetDecisionValue(Character character, List<StateType> currentStates, CharacterInputType currentInput)
    {
        float decisionValue = 1;

        bool containsState = false;
        foreach(StateType s in currentStates)
        {
            containsState = containsState || validState.Contains(s);
        }

        decisionValue *= containsState ? 1 : 0;

        decisionValue *= validInput.Contains(currentInput) ? 1 : 0;

        foreach (BaseDecisionAlgorithm decisionAlgorithm in decisionAlgorithms) 
        {
            decisionValue *= decisionAlgorithm.CheckDecesion(character);
        }

        return decisionValue;
    }
}

