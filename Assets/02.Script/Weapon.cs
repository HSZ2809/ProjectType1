using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private Transform muzzle = null;
    [SerializeField] private GameObject bullet = null;
    [SerializeField] private float attackPower = 0.0f;
    [SerializeField] private float reloadTime = 1.0f;

    public float AttackPower
    {
        get{ return attackPower; }
    }

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        muzzle = player.transform.Find("Shoot_Direction").GetChild(0);
    }

    private void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(reloadTime);
            Instantiate(bullet, muzzle.position, muzzle.rotation);
        }
    }
}