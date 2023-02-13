using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterInput))]
public class CharacterCore : MonoBehaviour
{
    [SerializeField]
    private CharacterInput characterInput;

    //Passed from the editor to the core systems in the Awake function
    [SerializeField]
    private CState defaultModule;//only active if all else is 0. 



    [SerializeField]
    private List<CState> states;//characters are at there core a combination of states. Grounded, underwater, jumping.
    [SerializeField]
    private List<CModel> models;//this can be anything from the base model to glowing eyes. We first find the ModelType BaseModel with the highest priority and then layer accessories on top.
    [SerializeField]
    private List<CAttribute> attributes;
    [SerializeField]
    private List<CModifier> modifiers;

    public CharacterStateMachine stateMachine { get; private set; }
    public CharacterModelGenerator modelGenerator { get; private set; }
    public CharacterAttributeHandler attributeHandler { get; private set; }
    public CharacterModifierHandler modifierHandler { get; private set; }

    
    



    private void Awake()
    {
        characterInput = GetComponent<CharacterInput>();
        stateMachine = new CharacterStateMachine(this, defaultModule, states);
        modelGenerator = new CharacterModelGenerator(models);
        attributeHandler = new CharacterAttributeHandler(attributes);
    }



    public CharacterInput GetCharacterInput()
    {
        return characterInput;
    }
    public CharacterStateMachine GetCharacterStateMachine()
    {
        return stateMachine;
    }






    public GameObject GenerateModel()
    {
        //TODO: Low Priority. Write code to generate a model for this character. Combine all of the character models  based off of priority as long as they don't overlap. 
        //This should be moved to a new class.
        return null;
    }

}


