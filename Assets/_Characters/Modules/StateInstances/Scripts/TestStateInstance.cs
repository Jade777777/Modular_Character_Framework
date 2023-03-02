using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
namespace ModularCharacter
{
    public class TestStateInstance : StateInstance
    {
        
        [SerializeField]
        CharacterInputType testInput;





        protected override void Enter()
        {
            
            //Debug.Log("Entering state " + gameObject);
        }

        protected override void Exit(CharacterInputType input)
        {
            base.Exit(input);
        }
        public override void ControlEnd()
        {
            //Debug.Log("Control End");
        }

        public override void ControlStart()
        {
            //Debug.Log("Control Start");
        }

        public override void OnAttack(InputValue input)
        {
            Debug.Log("ATTACK!");
            Exit(testInput);
        }

        public override void OnJump(InputValue input)
        {
            Debug.Log("Jump");
        }

        public override void OnLook(InputValue input)
        {

        }

        public override void OnMove(InputValue input)
        {
            Debug.Log("Move " + input.Get<Vector2>());
        }




    }
}