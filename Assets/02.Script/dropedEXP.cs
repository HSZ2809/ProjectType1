using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class dropedEXP : MonoBehaviour
    {
        [SerializeField] private int exp = 0;

        public int Exp
        {
            get{ return exp; }
        }
    }
}