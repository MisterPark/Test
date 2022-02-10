using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Humanoid))]
public class HumanoidEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Set Bones"))
        {
            SetBone();
        }
    }

    private void SetBone()
    {
        Humanoid humanoid = (Humanoid)target;

        humanoid.Bones.Clear();
        GameObject root = humanoid.gameObject.transform.Find("Root").gameObject;
        for (int i = 0; i < Extension.boneNames.Count; i++) 
        {
            humanoid.Bones.Add(null);
        }
        SetBone(root);
    }

    private void SetBone(GameObject bone)
    {
        Humanoid humanoid = (Humanoid)target;
        
        int count = bone.transform.childCount;
        for(int i = 0; i < count; i++)
        {
            GameObject child = bone.transform.GetChild(i).gameObject;
            if(child != null)
            {
                string boneName = child.name.ToBoneName();
                if (string.IsNullOrEmpty(boneName)) continue;
                int index = (int)boneName.ToBoneType();
                
                child.name = boneName;
                humanoid.Bones[index] = child;
                SetBone(child);
            }
            
        }
    }
}
