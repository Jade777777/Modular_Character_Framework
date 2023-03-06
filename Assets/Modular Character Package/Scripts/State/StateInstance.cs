using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace ModularCharacter
{
    public abstract class StateInstance : MonoBehaviour, CharacterControlOverride
    {
        protected CharacterCore character;
        [SerializeField]
        private Transform targetRootBone;
        [SerializeField]
        private Transform targetSMRContainer;

        #region Entry/Exit
        public static StateInstance EnterNewStateInstance(GameObject statePrefab, CharacterCore character, PersistantData persistantData)//state instance factory
        {
            GameObject stateInstanceGO = Instantiate(statePrefab, persistantData.position, persistantData.rotation, character.transform.parent);


            StateInstance stateInstance = stateInstanceGO.GetComponent<StateInstance>();
            stateInstance.character = character;


            character.GetCharacterInput().OverrideControl(stateInstance);


            stateInstance.Enter();
            return stateInstance;
        }

        protected abstract void Enter();
        protected virtual void Start()
        {
            character.modelGenerator.AttatchCharacterModel(targetRootBone, targetSMRContainer);
        }
        protected virtual void Exit(CharacterInputType input)// This is the only way the state can be exited.
        {
            character.stateMachine.persistantData.position = transform.position;
            character.stateMachine.persistantData.rotation = transform.rotation;
            Debug.Log("Exiting state!");
            Destroy(gameObject);//we can replace this with object pooling in the future if necessary     
            character.GetCharacterStateMachine().Transition(input);
        }
        #endregion

        #region Input
        public abstract void OnMove(InputValue input);
        public abstract void OnLook(InputValue input);
        public abstract void OnAttack(InputValue input);
        public abstract void OnJump(InputValue input);

        public abstract void ControlEnd();
        public abstract void ControlStart();
        #endregion

    }
}