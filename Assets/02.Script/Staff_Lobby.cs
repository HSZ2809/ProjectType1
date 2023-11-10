using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ZUN
{
    public class Staff_Lobby : MonoBehaviour
    {
        [Header ("New game")]
        [SerializeField] private Button button_New_Game;
        [SerializeField] private string sceneName_New_Game;
        [SerializeField] private UnityEngine.SceneManagement.LoadSceneMode mode_New_Game;

        [Header ("EXIT")]
        [SerializeField] private Button button_EXIT;

        private Manager_Scene manager_Scene;

        private void Awake()
        {
            manager_Scene = GameObject.FindGameObjectWithTag("Manager_Scene").GetComponent<Manager_Scene>();
        }

        private void Start()
        {
            button_New_Game.onClick.AddListener(NewGame);
            button_EXIT.onClick.AddListener(EXIT);
        }

        public void NewGame()
        {
            manager_Scene.LoadScene(sceneName_New_Game, mode_New_Game);
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
