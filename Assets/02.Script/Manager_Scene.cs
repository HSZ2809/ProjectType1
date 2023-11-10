using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ZUN
{    
    public class Manager_Scene : MonoBehaviour
    {
        private bool isSceneChangeable = true;

        public void LoadScene(string sceneName, LoadSceneMode mode)
        {
            isSceneChangeable = false;

            StartCoroutine(LoadTargetScene(sceneName, mode));
        }

        IEnumerator LoadTargetScene(string sceneName, LoadSceneMode mode)
        {
            #if UNITY_EDITOR
                Debug.Log("Manager_Scene >> Scene Load : " + sceneName + ", LoadSceneMode : " + mode);
            #endif

            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, mode);
            isSceneChangeable = true;

            yield return true;
        }
    }
}