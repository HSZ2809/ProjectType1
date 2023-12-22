using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ZUN
{
    public class Btn_OpenMenu : MonoBehaviour
    {
        [SerializeField] private GameObject menu = null;

        public void OpenMenu()
        {
            menu.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}