using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HowToSetBones : EditorWindow
{
    [MenuItem("HowTo/뼈대 세팅법")]
    public static void ShowWindow()
    {
        GetWindow<HowToSetBones>("How to set bones");

    }
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("1. Humanoid 컴포넌트를 추가한다.");
        EditorGUILayout.LabelField("2. Set Bones 버튼을 누른다.");
        EditorGUILayout.EndVertical();
    }
}
