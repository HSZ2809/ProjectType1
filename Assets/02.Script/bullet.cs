using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private Weapon weapon = null;
    [SerializeField] private float attackPower = 1.0f;

    [SerializeField] private float moveSpeed = 1.0f;

    private void OnEnable() 
    {
        attackPower = weapon.AttackPower;

        StartCoroutine("DisableBullet");
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
            monster.Hit(attackPower);
        }
    }

    // 일정 시간 후 비활성화
    IEnumerator DisableBullet()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}