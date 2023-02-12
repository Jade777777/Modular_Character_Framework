using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCore : MonoBehaviour
{
    [SerializeField]
    private CharacterInput characterInput;


    [SerializeField]
    private CState defaultModule;//only active if all else is 0. 


    //character modules. Data only changes from outside events such as aquiring a new item.
    [SerializeField]
    private List<CState> characterStates; 
    [SerializeField]
    private List<CModel> characterModels;//this can be anything from the base model to glowing eyes. We first find the ModelType BaseModel with the highest priority and then layer accessories on top.
    [SerializeField]
    private List<CAtribute> characterAtributes;


    private CharacterStateMachine characterStateMachine; 
    
    public PersistantData persistantData;//data stored between states(things like current health, speed, and whatnot)



    private void Awake()
    {
        characterStateMachine = new CharacterStateMachine(this);
    }

    public PersistantData GetPersistantData()
    {
        return persistantData;
    }
    public List<CState> GetCharacterStates()
    {
        return characterStates;
    }
    public CState GetDefaultModule()
    {
        return defaultModule;
    }
    public CharacterInput GetCharacterInput()
    {
        return characterInput;
    }
    public CharacterStateMachine GetCharacterStateMachine()
    {
        return characterStateMachine;
    }






    public GameObject GenerateModel()
    {
        //TODO: Low Priority. Write code to generate a model for this character. Combine all of the character models  based off of priority as long as they don't overlap. 
        //This should be moved to a new class.
        return null;
    }

}


