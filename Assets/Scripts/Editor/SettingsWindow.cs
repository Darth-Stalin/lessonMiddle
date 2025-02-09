using System.Collections;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Unity.Entities;
using UnityEditor;
using UnityEngine;

public class SettingsWindow : EditorWindow
{
    private string[] settingsList;
    private bool buttonPressed;

    [UnityEditor.MenuItem("Window/Game Settings Window")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SettingsWindow));
    }

    void OnGUI()
    {
        settingsList = AssetDatabase.FindAssets("t:settings");
        GUILayout.Label("Game Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);
        foreach (var file in settingsList)
        {
            GUILayout.Label(AssetDatabase.GUIDToAssetPath(file), EditorStyles.label);
        }

        buttonPressed = GUILayout.Button("Adjust Healt");
        if (buttonPressed)
        {
            foreach (var file in settingsList)
            {
                var settingsFile = AssetDatabase.LoadAssetAtPath<Settings>(AssetDatabase.GUIDToAssetPath(file));
                settingsFile.HeroHealth +=12;
            }
            AssetDatabase.SaveAssets();
        }
        
    }
}
