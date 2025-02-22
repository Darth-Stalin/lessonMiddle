using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CanEditMultipleObjects]
[CustomEditor(typeof(Settings))]
public class SettingsInspector : Editor
{
    private SerializedProperty Health;
    private bool setHealth;

    private void OnEnable()
    {
        Health = serializedObject.FindProperty("HeroHealth");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(Health);
        GUILayout.Label(Health.intValue.ToString());
        setHealth = GUILayout.Button("Set Health bacl to 100");
        if (setHealth)
        {
            Health.intValue = 100;
        }
        serializedObject.ApplyModifiedProperties();
    }
}
