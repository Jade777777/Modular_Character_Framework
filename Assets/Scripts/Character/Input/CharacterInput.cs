using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterInput : MonoBehaviour, CharacterControlInput
{
    private CharacterControlOverride cco;
    public void OnAttack(InputValue input)
    {
        if (cco != null)
            cco.OnAttack(input);
    }
    public void OnLook(InputValue input)
    {
        if (cco != null)
            cco.OnLook(input);
    }
    public void OnMove(InputValue input)
    {
        if (cco != null)
            cco.OnMove(input);
    }
    public void OnJump(InputValue input)
    {
        if (cco != null)
            cco.OnJump(input);
    }
    public void OverrideControl(CharacterControlOverride cco)
    {

        if (this.cco != null)
        {
            this.cco.ControlEnd();
        }

        this.cco = cco;

        if (cco != null)
        {
            cco.ControlStart();
        }
    }
}


public interface CharacterControlOverride : CharacterControlInput
{
    void ControlStart();
    void ControlEnd();
}
public interface CharacterControlInput //Orginazational purposes only. this should only be used by character control override andcharacter Input. start, end, and other helper functions from the characters input.
{ 
    void OnMove(InputValue input);
    void OnLook(InputValue input);
    void OnAttack(InputValue input);
    void OnJump(InputValue input);

}
