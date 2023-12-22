using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class Weapon_01 : MonoBehaviour, IWeapon
    {
        [SerializeField] private Character character = null;
        [SerializeField] private Transform muzzle = null;
        [SerializeField] private Bullet_01 bullet = null;

        [Header("Weaopn SPEC")]
        [SerializeField] private float defaultDamage = 0.0f;
        [SerializeField] private float reloadTime = 1.0f;

        [Header("Magazine")]
        [SerializeField] private List<Bullet_01> magazine = null;

        public float BulletDamage { get{ return defaultDamage + character.AttackPower; } }

        IEnumerator enumerator;

        private void Awake() 
        {
            character = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
            muzzle = character.transform.Find("Shoot_Direction").GetChild(0);
        }

        private void Start()
        {
            character.RegistrationWeapon(this);
        }

        public void ShootWeapon(float attackSpeed)
        {
            enumerator = Shoot(attackSpeed);
            StartCoroutine(enumerator);
        }

        IEnumerator Shoot(float attackSpeed)
        {
            Bullet_01 firstInstance = Instantiate(bullet, muzzle.position, muzzle.rotation);
            firstInstance.Damage = BulletDamage;
            magazine.Add(firstInstance);

            while(true)
            {
                yield return new WaitForSeconds(reloadTime * attackSpeed);

                for(int i = 0; i < magazine.Count; i++)
                {
                    if(magazine[i].gameObject.activeSelf == false)
                    {
                        magazine[i].gameObject.transform.position = muzzle.position;
                        magazine[i].gameObject.transform.localRotation = muzzle.rotation;
                        magazine[i].Damage = BulletDamage;
                        magazine[i].gameObject.SetActive(true);
                        break;
                    }    
                    
                    if(i == magazine.Count - 1)
                    {
                        Bullet_01 bulletInstance = Instantiate(bullet, muzzle.position, muzzle.rotation);
                        bulletInstance.Damage = BulletDamage;
                        magazine.Add(bulletInstance);
                        break;
                    }
                }
            }
        }
    }
}