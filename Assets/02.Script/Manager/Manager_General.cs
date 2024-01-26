using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class Manager_General : MonoBehaviour
    {
        public Manager_Scene manager_Scene;
        public Manager_Sound manager_Sound;

        private void Awake()
        {
            manager_Scene = GameObject.FindGameObjectWithTag("Manager_Scene").GetComponent<Manager_Scene>();
            manager_Sound = GameObject.FindGameObjectWithTag("Manager_Sound").GetComponent<Manager_Sound>();
        }
    }
}