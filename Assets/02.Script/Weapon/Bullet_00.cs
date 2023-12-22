using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ZUN
{
    public class Bullet_00 : MonoBehaviour
    {
        [SerializeField] private float damage = 1.0f;
        [SerializeField] private float moveSpeed = 1.0f;

        public float Damage
        {
            set{ damage = value; }
        }

        private void OnEnable() 
        {
            StartCoroutine(DisableBullet());
        }

        private void Update()
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == "Monster")
            {
                Monster monster = other.gameObject.GetComponent<Monster>();
                monster.Hit(damage);
            }
        }

        // 일정 시간 후 비활성화
        IEnumerator DisableBullet()
        {
            yield return new WaitForSeconds(3.0f);
            gameObject.SetActive(false);
        }
    }
}