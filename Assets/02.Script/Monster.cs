using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private float hp = 0.0f;
        [SerializeField] private float attackPower = 0.0f;

        public float Hp
        {
            get{ return hp; }
            set{ hp += value; }
        }

        public float AttackPower
        {
            get{ return attackPower; }
        }

        public void Hit(float damage)
        {
            hp -= damage;
            Debug.Log("Monster : hit! - damage : " + damage);

            if(hp < 0)
            {
                gameObject.SetActive(false);
                Debug.Log("Monster : Died");
            }
        }
    }
}