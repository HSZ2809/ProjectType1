using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Staff_Play : MonoBehaviour
{
    [SerializeField] private Player player = null;
    [SerializeField] private Weapon weapon = null;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown("k"))
        {
            GiveWeapon();
        }
    }

    public void GiveWeapon()
    {
        Instantiate(weapon, player.gameObject.transform);
    }
}