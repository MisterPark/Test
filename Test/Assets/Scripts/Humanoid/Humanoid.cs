using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoneType
{
    None,
    Hips,
    Spine,
    Chest,
    UpperChest,
    LeftShoulder,
    LeftUpperArm,
    LeftLowerArm,
    LeftHand,
    RightShoulder,
    RightUpperArm,
    RightLowerArm,
    RightHand,
    LeftUpperLeg,
    LeftLowerLeg,
    LeftFoot,
    LeftToes,
    RightUpperLeg,
    RightLowerLeg,
    RightFoot,
    RightToes,
    Neck,
    Head,
    LeftEye,
    RightEye,
    Jaw,
    LeftThumb1,
    LeftThumb2,
    LeftThumb3,
    LeftIndex1,
    LeftIndex2,
    LeftIndex3,
    LeftMiddle1,
    LeftMiddle2,
    LeftMiddle3,
    LeftRing1,
    LeftRing2,
    LeftRing3,
    LeftLittle1,
    LeftLittle2,
    LeftLittle3,
    RightThumb1,
    RightThumb2,
    RightThumb3,
    RightIndex1,
    RightIndex2,
    RightIndex3,
    RightMiddle1,
    RightMiddle2,
    RightMiddle3,
    RightRing1,
    RightRing2,
    RightRing3,
    RightLittle1,
    RightLittle2,
    RightLittle3,
    LeftBust1,
    LeftBust2,
    RightBust1,
    RightBust2,
}
public class Humanoid : MonoBehaviour
{
    [SerializeField] List<GameObject> bones = new List<GameObject>();
    public List<GameObject> Bones {get {return bones;}}


}
