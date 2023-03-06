using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ModularCharacter
{
    [CreateAssetMenu(fileName = "Cmodel", menuName = "CharacterModule / Model", order = 1)]
    public class CModel : ScriptableObject
    {
        [SerializeField]
        private GameObject model;
        [SerializeField]
        private ModelType type;
        [SerializeField]
        private int priority;

        public GameObject GetModel()
        {
            return model;
        }
        public ModelType GetModelType()
        {
            return type;
        }
        public int GetPriority() 
        {
            return priority; 
        }

        public static List<GameObject> GetModels(List<CModel> cModels)
        {
            List<GameObject> list = new List<GameObject>();
            foreach (CModel cModel in cModels)
            {
                list.Add(cModel.model);
            }
            return list;
        }
    }

    public enum ModelType { BaseModel, Accessory, ArmAccessory, Necklace, Shirt, Pants, Tattoo, Nose }//placeholder categories, can be replaced with anything
}