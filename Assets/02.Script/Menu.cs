using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private GameObject OpenMenu = null;

        public void Continue()
        {
            OpenMenu.SetActive(true);
            gameObject.SetActive(false);
        }

        public void EXIT()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}