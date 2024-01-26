using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ZUN
{
    public class Btn_SelectItem : MonoBehaviour
    {
        public Staff_Play staff_Play = null;
        public TextMeshProUGUI textMeshProUGUI = null;
        public Image image = null;
        public string itemSN = null;

        public void ItemSelect()
        {
            staff_Play.SelectItem(itemSN);
        }
    } 
}