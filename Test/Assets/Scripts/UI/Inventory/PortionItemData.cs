using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item_Portion_", menuName = "Inventory System/Item Data/Portion", order = 3)]
public class PortionItemData : CountableItemData
{
    [SerializeField] private float m_Value;
    public float Value => m_Value;

    public override Item CreateItem()
    {
        return new PortionItem(this);
    }
}
