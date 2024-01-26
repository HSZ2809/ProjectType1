using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZUN;

namespace ZUN
{
    public class PassiveItem : Item
    {
        [SerializeField] protected Character character = null;
            
        private void Start()
        {
            character.RegistrationPassive(this);
        }
    }
}