using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateMachine
{
    private CharacterCore character;
    //character active info
    [SerializeField]
    private CState currentModule; // we save the entire module instead of something like the index because the size of the list is highly dynamic.
    [SerializeField]
    private StateInstance currentStateInstance;

    public CharacterStateMachine(CharacterCore character)
    {
        this.character = character;
        Transition(character.GetDefaultModule());//transition to the default module on game start
    }


    public void RestoreControl()//reset the control target to the character
    {
        character.GetCharacterInput().OverrideControl(currentStateInstance);
    }


    public void Transition(CharacterInputType input)// Calculates the next apropriate state to transition to
    {
        //TODO: High Priority. Determine the next state to transition to through a Utility style aproach.
        CState characterModule = CState.DecideNewState(character.GetCharacterStates(), character, currentModule.GetStateType(), input);

        Transition(characterModule);
    }

    public void Transition(CState characterModule)//choose a new state, This module doesn't need to be housed within this class.
    {

        if (characterModule == null)
        {
            characterModule = character.GetDefaultModule();
            Debug.LogWarning("NO VALID STATE, Transitioning to default module.");
        }

        character.GetCharacterInput().OverrideControl(null);
        

        currentModule = characterModule;

        currentStateInstance = StateInstance.EnterNewStateInstance(characterModule.GetModuleState(), character);
        Debug.Log("Transition to new state! " + currentModule + ", " + currentStateInstance);
    }



}
