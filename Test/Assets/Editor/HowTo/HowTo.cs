using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HowTo : EditorWindow
{
    [MenuItem("HowTo/추가방법")]
    public static void ShowWindow()
    {
        GetWindow<HowTo>("Example");

    }
    private void OnGUI()
    {
        EditorGUILayout.BeginVertical();

        EditorGUILayout.LabelField("HowTo 추가 방법");
        EditorGUILayout.LabelField("1. Editor 폴더 하위에 C# Script 생성");
        EditorGUILayout.LabelField("2. HowTo 스크립트 복사, 1에서 생성한 스크립트로 붙여넣기");
        EditorGUILayout.LabelField("3. class 이름 변경");
        EditorGUILayout.LabelField("4. [MenuItem(HowTo/이름)] <= 이름을 변경");
        EditorGUILayout.LabelField("5. GetWindow<클래스명>() <= 클래스명을 3의 클래스명으로 변경");

        EditorGUILayout.EndVertical();
    }
}
