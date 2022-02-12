using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CountableItemData : ItemData
{
    [SerializeField] private int m_MaxAmount = 99;
    public int MaxAmount => m_MaxAmount;
}
