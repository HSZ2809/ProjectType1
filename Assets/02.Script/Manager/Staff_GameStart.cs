using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZUN
{
    public class Staff_GameStart : MonoBehaviour
    {
        [SerializeField] private Button button_Start;
        [SerializeField] private string sceneName;
        [SerializeField] private UnityEngine.SceneManagement.LoadSceneMode mode;
        private Manager_Scene manager_Scene;

        private void Awake()
        {
            manager_Scene = GameObject.FindGameObjectWithTag("Manager_Scene").GetComponent<Manager_Scene>();
        }

        private void Start()
        {
            button_Start.onClick.AddListener(GameStart);
        }

        public void GameStart()
        {
            manager_Scene.LoadScene(sceneName, mode);
        }
    }
}
