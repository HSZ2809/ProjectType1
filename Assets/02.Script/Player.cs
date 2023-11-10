using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private Collider2D playerCollider = null;
    [SerializeField] private GameObject shootDirection = null;
    [SerializeField] private Transform muzzle = null;

    [Header("Status")]
    [SerializeField] private float hp = 0.0f;
    [SerializeField] private float moveSpeed = 0.0f;
    [SerializeField] private float attackSpeed = 0.0f;

    private void Start()
    {

    }

    private void Update() 
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(h, v, 0);
        moveDirection *= moveSpeed;

        transform.Translate(moveDirection * Time.deltaTime);

        if(h != 0 || v != 0)
        {
            float angle = Mathf.Atan2(v, h) * Mathf.Rad2Deg;
            shootDirection.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Monster")
        {
            float damage = other.gameObject.GetComponent<Monster>().AttackPower;
            hp -= damage;
            Debug.Log("Player : hit! - damage : " + damage);
        }
    }
}