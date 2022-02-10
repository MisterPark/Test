using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extension
{
    public static List<string> boneNames = new List<string>()
    {
        "",
    "Hips",
    "Spine",
    "Chest",
    "UpperChest",
    "LeftShoulder",
    "LeftUpperArm",
    "LeftLowerArm",
    "LeftHand",
    "RightShoulder",
    "RightUpperArm",
    "RightLowerArm",
    "RightHand",
    "LeftUpperLeg",
    "LeftLowerLeg",
    "LeftFoot",
    "LeftToes",
    "RightUpperLeg",
    "RightLowerLeg",
    "RightFoot",
    "RightToes",
    "Neck",
    "Head",
    "LeftEye",
    "RightEye",
    "Jaw",
    "LeftThumb1",
    "LeftThumb2",
    "LeftThumb3",
    "LeftIndex1",
    "LeftIndex2",
    "LeftIndex3",
    "LeftMiddle1",
    "LeftMiddle2",
    "LeftMiddle3",
    "LeftRing1",
    "LeftRing2",
    "LeftRing3",
    "LeftLittle1",
    "LeftLittle2",
    "LeftLittle3",
    "RightThumb1",
    "RightThumb2",
    "RightThumb3",
    "RightIndex1",
    "RightIndex2",
    "RightIndex3",
    "RightMiddle1",
    "RightMiddle2",
    "RightMiddle3",
    "RightRing1",
    "RightRing2",
    "RightRing3",
    "RightLittle1",
    "RightLittle2",
    "RightLittle3",
    "LeftBust1",
    "LeftBust2",
    "RightBust1",
    "RightBust2",
    };
    static List<string> simpleBoneNames = new List<string>()
    {
        "Hips",
    "Spine",
    "Chest",
    "UpperChest",
    "Shoulder",
    "UpperArm",
    "LowerArm",
    "Hand",
    "UpperLeg",
    "LowerLeg",
    "Foot",
    "Toes",
    "Neck",
    "Head",
    "Eye",
    "Eye",
    "Jaw",
    "Thumb",
    "Index",
    "Middle",
    "Ring",
    "Little",
    "Bust",
    };
    public static string ToBoneName(this string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        string prefix = string.Empty; // 立滴荤
        string suffix = string.Empty; // 立固荤

        foreach (var bone in simpleBoneNames)
        {
            if (name.Contains(bone))
            {
                // 立滴荤 贸府
                if (name.Contains("L") || name.Contains("Left"))
                {
                    prefix = "Left";
                }
                else if (name.Contains("R") || name.Contains("Right"))
                {
                    prefix = "Right";
                }

                // 立固荤 贸府
                if (name.Contains("1") || name.Contains("Proximal"))
                {
                    suffix = "1";
                }
                else if (name.Contains("2") || name.Contains("Intermediate"))
                {
                    suffix = "2";
                }
                else if (name.Contains("3") || name.Contains("Distal"))
                {
                    suffix = "3";
                }

                return prefix + bone + suffix;
            }
        }

        return string.Empty;
    }

    public static string ToSimpleBoneName(this string name)
    {
        foreach (var bone in simpleBoneNames)
        {
            if (name.Contains(bone))
            {
                return bone;
            }
        }
        return string.Empty;
    }

    public static BoneType ToBoneType(this string name)
    {
        string bone = name.ToBoneName();
        int index = boneNames.IndexOf(bone);
        if (index == -1)
        {
            return BoneType.None;
        }

        return (BoneType)index;
    }

    public static string ToString(this BoneType boneType)
    {
        return boneNames[(int)boneType];
    }

    public static bool ContainsBoneName(this string name)
    {
        foreach (var bone in boneNames)
        {
            if (name.Contains(bone))
            {
                return true;
            }
        }
        return false;
    }

    public static bool ContainsSimpleBoneName(this string name)
    {
        foreach (var bone in simpleBoneNames)
        {
            if (name.Contains(bone))
            {
                return true;
            }
        }
        return false;
    }
}
