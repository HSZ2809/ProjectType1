using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZUN
{
    public class Character : MonoBehaviour
    {
        [Header("Connected Components")]
        [SerializeField] private Staff_Play staff_Play = null;
        [Space]
        [SerializeField] private Collider2D playerCollider = null;
        [SerializeField] private GameObject shootDirection = null;
        [SerializeField] private Transform muzzle = null;
        [SerializeField] private WeaponItem[] weaponItems = new WeaponItem[6];
        [SerializeField] private PassiveItem[] passiveItems = new PassiveItem[6];

        [Header("Connected Joystick")]
        [SerializeField] private Joystick joystick;

        [Header("Status")]
        [SerializeField] int level = 1;
        [SerializeField] private float hp = 0.0f;
        [SerializeField] private float moveSpeed = 0.0f;
        [SerializeField] private float attackPower = 0.0f;
        [SerializeField] private float attackSpeed = 0.0f;
        [SerializeField] private int exp = 0;
        [SerializeField] private string initialWeaponSN = "default";

        [SerializeField] private int amountOfWeaponItem = 0;
        [SerializeField] private int amountOfPassiveItem = 0;

        public float AttackPower { get{ return attackPower; } }
        public string InitialWeaponSN { get{ return initialWeaponSN; } }

        private void Update() 
        {
            float h = joystick.GetHorizontalAxis();
            float v = joystick.GetVerticalAxis();

            Vector3 moveDirection = new Vector3( h, v, 0 ).normalized;
            moveDirection *= moveSpeed;

            transform.Translate(moveDirection * Time.deltaTime);

            if(h != 0.0f || v != 0.0f)
            {
                float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
                shootDirection.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
            }
        }

        private void OnCollisionStay2D(Collision2D other) 
        {
            if(other.gameObject.CompareTag("Monster"))
            {
                float damage = other.gameObject.GetComponent<Monster>().AttackPower;
                hp -= damage;
                Debug.Log("Player : hit! - damage : " + damage);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("Exp"))
            {
                AddExp(other.GetComponent<DropedEXP>().Exp);
                Destroy(other.gameObject);
            }
        }

        public void RegistrationWeapon(WeaponItem newWeapon)
        {
            if(amountOfWeaponItem < weaponItems.Length)
            {
                weaponItems[amountOfWeaponItem] = newWeapon;
                weaponItems[amountOfWeaponItem].ActivateWeapon(attackSpeed);
                amountOfWeaponItem += 1;
                return;
            }
            else
                Debug.Log("Weapon Overflow!");
        }

        public void RegistrationPassive(PassiveItem newPassive)
        {
            if(amountOfPassiveItem < passiveItems.Length)
            {
                passiveItems[amountOfPassiveItem] = newPassive;
                amountOfPassiveItem += 1;
                return;
            }
            else
                Debug.Log("Passive Overflow!");
        }

        public void AddExp(int _exp)
        {
            exp += _exp;

            if(exp >= 10)
            {
                exp -= 10;
                level += 1;

                staff_Play.ShowOptions(amountOfWeaponItem, GetWISNs(), amountOfPassiveItem);
            }
        }

        private string[] GetWISNs()
        {
            string[] SNs = new string[6];

            for(int i = 0; i < 6; i++)
            {
                if(weaponItems[i] == null)
                    break;
                else
                {
                    SNs[i] = weaponItems[i].SerialNumber;
                }
            }

            return SNs;
        }
    }
}