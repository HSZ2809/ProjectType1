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
        [SerializeField] private IWeapon[] weapon = new IWeapon[5];

        [Header("Connected Joystick")]
        [SerializeField] private Joystick joystick;

        [Header("Status")]
        [SerializeField] int level = 1;
        [SerializeField] private float hp = 0.0f;
        [SerializeField] private float moveSpeed = 0.0f;
        [SerializeField] private float attackPower = 0.0f;
        [SerializeField] private float attackSpeed = 0.0f;
        [SerializeField] private int exp = 0;

        private int amountOfWeaponItem = 1;
        private int amountOfPassiveItem = 0;

        public float AttackPower { get{ return attackPower; } }
        public bool FullArmed 
        {
            get{ return (weapon[weapon.Length - 1] != null) ? true : false; }
        }

        private void Update() 
        {
            // float h = Input.GetAxis("Horizontal");
            // float v = Input.GetAxis("Vertical");

            float h = joystick.GetHorizontalAxis();
            float v = joystick.GetVerticalAxis();

            Vector3 movePosition = new Vector3( h, v, 0 ).normalized;

            //Vector3 moveDirection = new Vector3(h, v, 0);
            Vector3 moveDirection = movePosition;
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
                AddExp(other.GetComponent<dropedEXP>().Exp);
                Destroy(other.gameObject);
            }
        }

        public void RegistrationWeapon(IWeapon newWeapon)
        {
            for(int i = 0; i < weapon.Length; i++)
            {
                if(weapon[i] == null)
                {
                    weapon[i] = newWeapon;
                    weapon[i].ShootWeapon(attackSpeed);
                    return;
                }
            }

            Debug.Log("Weapon Overflow!");
        }

        public void AddExp(int _exp)
        {
            exp += _exp;

            if(exp > 10)
            {
                exp -= 10;
                level += 1;

                staff_Play.ShowOptions(amountOfWeaponItem, amountOfPassiveItem);
            }
        }
    }
}