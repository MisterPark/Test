using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HowTo : EditorWindow
{
    [MenuItem("HowTo/�߰����")]
    public static void ShowWindow()
    {
        GetWindow<HowTo>("Example");

    }
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.LabelField("HowTo �߰� ���");
        EditorGUILayout.LabelField("1. Editor ���� ������ C# Script ����");
        EditorGUILayout.LabelField("2. HowTo ��ũ��Ʈ ����, 1���� ������ ��ũ��Ʈ�� �ٿ��ֱ�");
        EditorGUILayout.LabelField("3. class �̸� ����");
        EditorGUILayout.LabelField("4. [MenuItem(HowTo/�̸�)] <= �̸��� ����");
        EditorGUILayout.LabelField("5. GetWindow<Ŭ������>() <= Ŭ�������� 3�� Ŭ���������� ����");

        EditorGUILayout.EndVertical();
    }
}
