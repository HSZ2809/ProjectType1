using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ZUN
{    
    public class Btn_MainLobby : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private UnityEngine.SceneManagement.LoadSceneMode mode;

        private Manager_Scene manager_Scene;

        private void Awake()
        {
            manager_Scene = GameObject.FindGameObjectWithTag("Manager_Scene").GetComponent<Manager_Scene>();
        }

        public void MainLobby()
        {
            manager_Scene.LoadScene(sceneName, mode);
        }
    }
}