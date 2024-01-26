using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class Staff_MonsterSpawner : MonoBehaviour
    {
        [Header("Spwan Location")]
        [SerializeField] private Transform[] spawnLocation = null;

        [Header("Monster Prefabs")]
        [SerializeField] private Monster[] monster = null;

        private int random = 0;
        
        private void Update()
        {
            
        }

        public void testSpwan()
        {
            Instantiate(monster[0], spawnLocation[random].position, spawnLocation[random].rotation);
            
            random += 1;
            if(random >= 4)
                random = 0;
        }
    }
}