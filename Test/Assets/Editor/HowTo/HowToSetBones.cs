using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HowToSetBones : EditorWindow
{
    [MenuItem("HowTo/���� ���ù�")]
    public static void ShowWindow()
    {
        GetWindow<HowToSetBones>("How to set bones");

    }
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("1. Humanoid ������Ʈ�� �߰��Ѵ�.");
        EditorGUILayout.LabelField("2. Set Bones ��ư�� ������.");
        EditorGUILayout.EndVertical();
    }
}
