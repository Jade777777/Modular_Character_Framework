using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public abstract class StateInstance : MonoBehaviour, CharacterControlOverride
{
    private Character character;
    
    #region Entry/Exit
    public static StateInstance EnterNewStateInstance(GameObject statePrefab, Character character)//state instance factory
    {
        GameObject stateInstanceGO = Instantiate(statePrefab);
        StateInstance stateInstance = stateInstanceGO.GetComponent<StateInstance>();
        stateInstance.character = character;
        character.OverrideControl(stateInstance);
        stateInstance.Enter();
        return stateInstance;
    }

    protected abstract void Enter();
    protected virtual void Exit(CharacterInputType input)// This is the only way the state can be exited.
    {
        Debug.Log("Exiting state!");
        Destroy(gameObject);//we can replace this with object pooling in the future if necessary     
        character.Transition(input);
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
