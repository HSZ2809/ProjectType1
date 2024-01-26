using UnityEngine;
using UnityEditor;

namespace ZUN
{
    [CustomEditor(typeof(Staff_Play))]
    public class Staff_Play_Editor : Editor
    {
        private SerializedProperty weaponItems;

        private void OnEnable()
        {
            weaponItems = serializedObject.FindProperty("WeaponItemBox");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            // EditorGUILayout.PropertyField(weaponItems);

            // weaponItems = EditorGUILayout.ObjectField("WeaponItems", weaponItems as Object, typeof(MonoBehaviour), true) as IWeaponItem;
        }
    }
}