using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public abstract class WeaponItem : Item
    {
        [SerializeField] protected Character character = null;
        
        private void Start()
        {
            character.RegistrationWeapon(this);
        }
        
        public virtual void ActivateWeapon(float attackSpeed)
        {

        }
    }
}
