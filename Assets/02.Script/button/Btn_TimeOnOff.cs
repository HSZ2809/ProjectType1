using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class Btn_TimeOnOff : MonoBehaviour
    {
        public void TimeOn()
        {
            Time.timeScale = 1;
        }

        public void TimeOff()
        {
            Time.timeScale = 0;
        }
    }
}