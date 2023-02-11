using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{



    [SerializeField]
    private CState defaultModule;//only active if all else is 0. 



    //character modules. Data only changes from outside events such as aquiring a new item.
    [SerializeField]
    private List<CState> characterStates; 
    [SerializeField]
    private List<CModel> characterModels;//this can be anything from the base model to glowing eyes. We first find the ModelType BaseModel with the highest priority and then layer accessories on top.
    [SerializeField]
    private List<CAtribute> characterAtributes;




    //character active info
    [SerializeField]
    private CState currentModule; // we save the entire module instead of something like the index because the size of the list is highly dynamic.
    [SerializeField]
    private StateInstance currentStateInstance;

    public PersistantData persistantData;//data stored between states(things like current health, speed, and whatnot)




    [SerializeField]
    private CharacterInput characterInput;


    private void Start()
    {

        Transition(defaultModule);//transition to the default module on game start
    }


    public void OverrideControl(CharacterControlOverride cco)//Allow the characterInput to control outside forces such as doors, minigames, and other context specific actions.
    {
        characterInput.OverrideControl(cco);
    }
    public void RestoreControl()//reset the control target to the character
    {
        OverrideControl(currentStateInstance);
    }



    public GameObject GenerateModel()
    {
        //TODO: Low Priority. Write code to generate a model for this character. Combine all of the character models  based off of priority as long as they don't overlap. 
        return null;
    }

    public void Transition(CharacterInputType input)// Calculates the next apropriate state to transition to
    {
        //TODO: High Priority. Determine the next state to transition to through a Utility style aproach.
        CState characterModule = CState.DecideNewState(characterStates, this, currentModule.GetStateType(), input);

        Transition(characterModule);
    }

    public void Transition(CState characterModule)//choose a new state, This module doesn't need to be housed within this class.
    {
        
        if(characterModule == null)
        {
            characterModule = defaultModule;
            Debug.LogWarning("NO VALID STATE, Transitioning to default module.");
        }

        OverrideControl(null);

        currentModule = characterModule;

        currentStateInstance = StateInstance.EnterNewStateInstance(characterModule.GetModuleState(), this);
        Debug.Log("Transition to new state! " + currentModule + ", "+currentStateInstance);
    }

    public PersistantData GetTransitionData()
    {
        return persistantData;
    }
  
}


