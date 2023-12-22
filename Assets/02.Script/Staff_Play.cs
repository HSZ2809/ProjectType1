using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace ZUN
{
    public class Staff_Play : MonoBehaviour
    {
        [SerializeField] private Canvas selectWindow = null;
        [SerializeField] private List<GameObject> weapon = null;

        private Character character = null;

        private void Awake()
        {
            character = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();
        }

        public void ShowOptions(int amountOfWeaponItem, int amountOfPassiveItem)
        {
            Time.timeScale = 0;

            selectWindow.gameObject.SetActive(true);

            /*
            1. 조건에 맞는 선택지를 생성한다.
            2. 각 버튼에 선택지를 할당, 또는 버튼을 생성해서 할당한다.
            3. 그 이후에 플로우는 버튼이 클릭되면 진행.
            */
        }
        
        public void GiveWeapon()
        {
            Instantiate(weapon[0], character.gameObject.transform);
            // Instantiate(weapon[1], character.gameObject.transform);

            selectWindow.gameObject.SetActive(false);

            Time.timeScale = 1;
        }

        public enum Select
        {
            WEAPON,
            PASSIVE,
            ANOTHER
        }
    }
}