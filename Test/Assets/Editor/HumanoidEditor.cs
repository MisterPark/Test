using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HumanoidEx))]
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
        HumanoidEx humanoid = (HumanoidEx)target;

        humanoid.Bones.Clear();
        GameObject root = FindRoot(humanoid.gameObject);
        for (int i = 0; i < Extension.boneNames.Count; i++) 
        {
            humanoid.Bones.Add(null);
        }
        SetBone(root);
    }

    private void SetBone(GameObject bone)
    {
        HumanoidEx humanoid = (HumanoidEx)target;
        
        int count = bone.transform.childCount;
        for(int i = 0; i < count; i++)
        {
            GameObject child = bone.transform.GetChild(i).gameObject;
            if(child != null)
            {
                string boneName = child.name.ToBoneName();
                if (string.IsNullOrEmpty(boneName)) continue;
                int index = (int)boneName.ToBoneType();
                
                //child.name = boneName;
                humanoid.Bones[index] = child;
                SetBone(child);
            }
            
        }
    }

    private GameObject FindRoot(GameObject bone)
    {
        Transform root = bone.transform.Find("Root");
        if(root != null)
        {
            return root.gameObject;
        }

        int count = bone.transform.childCount;
        for (int i = 0; i < count; i++)
        {
            GameObject child = bone.transform.GetChild(i).gameObject;
            if (child == null) continue;
            GameObject childRoot = FindRoot(child);
            if(childRoot != null)
            {
                return childRoot;
            }
        }

        return null;
    }
}
