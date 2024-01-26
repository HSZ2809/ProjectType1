using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace ZUN
{
    public class Staff_Play : MonoBehaviour
    {
        [Header("Connected Components")]
        [SerializeField] private Canvas selectWindow = null;
        [SerializeField] private Btn_SelectItem[] Btn_Options = null;
        private Character character = null;

        [Header("Item List")]
        [SerializeField] private WeaponItem[] weaponItems = null;
        [SerializeField] private PassiveItem[] passiveItems = null;

        private readonly Dictionary<string, Item> itemDictionary = new();

        private void Awake()
        {
            character = GameObject.FindGameObjectWithTag("Character").GetComponent<Character>();

            FillItemDictionary(weaponItems, itemDictionary);
            FillItemDictionary(passiveItems, itemDictionary);
        }

        private void Start()
        {
            SpawnInitialWeapon();
        }

        public void ShowOptions(int amountOfWeaponItem, string[] WISNs, int amountOfPassiveItem)
        {
            Time.timeScale = 0;

            selectWindow.gameObject.SetActive(true);

            List<string> shuffle = new List<string>();

            foreach(var item in itemDictionary)
            {
                shuffle.Add(item.Key);
            }

            for(int i = 0; i < Btn_Options.Length; i++)
            {
                int randomIndex = UnityEngine.Random.Range(0, shuffle.Count);
                string pichedSN = shuffle[randomIndex];

                itemDictionary.TryGetValue(pichedSN, out Item item);

                shuffle.RemoveAt(randomIndex);

                Btn_Options[i].image.sprite = item.Sprite;
                Btn_Options[i].textMeshProUGUI.text = item.UpgradeInfos[0];
                Btn_Options[i].itemSN = item.SerialNumber;
            }
        }

        private void FillItemDictionary<T>(T[] items, Dictionary<string, T> itemDictionary) where T : Item
        {
            foreach(var item in items)
            {
                if(itemDictionary.ContainsKey(item.SerialNumber))
                {
                    Debug.LogWarning($"Duplicate SerialNumber found for {typeof(T).Name} with SerialNumber {item.SerialNumber}");
                }
                else
                {
                    itemDictionary[item.SerialNumber] = item;
                }
            }
        }

        private void SpawnInitialWeapon()
        {
            if(itemDictionary.TryGetValue(character.InitialWeaponSN, out Item initialWeapon))
            {
                Instantiate(initialWeapon, character.gameObject.transform);
            }
            else
            {
                Debug.LogWarning("Initial Weapon Not Found");
            }
        }
        
        public void SelectItem(string _itemSN)
        {
            

            selectWindow.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}