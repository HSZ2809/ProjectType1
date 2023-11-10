using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Collider2D playerCollider = null;
    [SerializeField] private GameObject shootDirection = null;
    [SerializeField] private Transform muzzle = null;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float attackSpeed = 3f;
    [SerializeField] private bool permitToFire = true;

    private void Start()
    {
        if(permitToFire)
            InvokeRepeating("Shoot", attackSpeed, 1);
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
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!permitToFire)
            {
                permitToFire = true;
                InvokeRepeating("Shoot", attackSpeed, 1);
            }
            else
            {
                permitToFire = false;
                CancelInvoke("Shoot");
            }

        }
    }

    private void OnCollisionStay2D(Collision2D other) 
    {
        Debug.Log("hit!");
    }

    private void Shoot()
    {
        Instantiate(bullet, muzzle.position, muzzle.rotation);
    }
}
