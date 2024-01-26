using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace ZUN
{
    public class Staff_GameAwake : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private UnityEngine.SceneManagement.LoadSceneMode mode;
        private Manager_Scene manager_Scene;

        private void Awake()
        {
            manager_Scene = GameObject.FindGameObjectWithTag("Manager_Scene").GetComponent<Manager_Scene>();
        }

        private void Start()
        {
            manager_Scene.LoadScene(sceneName, mode);
        }
    }
}