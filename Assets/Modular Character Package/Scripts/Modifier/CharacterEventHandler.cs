using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
namespace ModularCharacter
{
    public class CharacterEventHandler
    {

        public enum EventType { Hit, Jump, Block, Attack, HeavyAttack }
        [System.Serializable]
        public struct EventMods
        {
            public EventType eventType;
            public List<CModifier> mods;
        }

        private CharacterCore characterCore;
        private Dictionary<EventType, List<CModifier>> eventModifiers;

        public CharacterEventHandler(CharacterCore characterCore, List<EventMods> mods)
        {
            this.characterCore = characterCore;
            foreach (EventMods eventMods in mods)
            {
                Debug.Assert(!eventModifiers.ContainsKey(eventMods.eventType));

                eventModifiers[eventMods.eventType] = eventMods.mods;
            }
        }


        public void ActivateEvent(EventType eventType)
        {
            foreach (CModifier modifier in eventModifiers[eventType])
            {
                characterCore.modifierHandler.ActivateMod(modifier);
            }
        }
        public void AddEventMod(EventType eventType, CModifier mod)
        {
            eventModifiers[eventType].Add(mod);
        }
        public void RemoveEventMod(EventType eventType, CModifier mod)
        {
            eventModifiers[eventType].Remove(mod);
        }
    }
}