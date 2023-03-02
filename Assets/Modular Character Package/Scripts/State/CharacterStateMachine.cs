using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ModularCharacter
{
    public class CharacterStateMachine
    {
        private CharacterCore character;

        private CState defaultModule;//only active if all else is 0. 

        private List<CState> characterStates;

        private CState currentModule; // we save the entire module instead of something like the index because the size of the list is highly dynamic.

        private StateInstance currentStateInstance;

        public PersistantData persistantData;//data stored between states(things like current health, speed, and whatnot)

        public CharacterStateMachine(CharacterCore character, CState defaultModule, List<CState> characterStates)
        {
            persistantData.position = character.transform.position;
            persistantData.rotation = character.transform.rotation;
            this.character = character;
            this.defaultModule = defaultModule;
            this.characterStates = characterStates;
            Transition(defaultModule);//transition to the default module on game start
        }


        public void AddState(CState state)
        {
            characterStates.Add(state);
        }
        public void RemoveState(CState state)
        {
            characterStates.Remove(state);
        }

        public void RestoreControl()//reset the control target to the character
        {
            character.GetCharacterInput().OverrideControl(currentStateInstance);
        }


        public void Transition(CharacterInputType input)// Calculates the next apropriate state to transition to
        {
            //TODO: High Priority. Determine the next state to transition to through a Utility style aproach.
            CState characterModule = CState.DecideNewState(characterStates, character, currentModule.GetStateType(), input);

            Transition(characterModule);
        }

        public void Transition(CState characterModule)//choose a new state, This module doesn't need to be housed within this class.
        {

            if (characterModule == null)
            {
                characterModule = defaultModule;
                Debug.LogWarning("NO VALID STATE, Transitioning to default module.");
            }

            character.GetCharacterInput().OverrideControl(null);


            currentModule = characterModule;

            currentStateInstance = StateInstance.EnterNewStateInstance(characterModule.GetModuleState(), character, persistantData);
            Debug.Log("Transition to new state! " + currentModule + ", " + currentStateInstance);
        }



    }
}