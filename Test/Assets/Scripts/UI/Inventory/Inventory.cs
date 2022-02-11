using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField, Range(8, 64)]
    private int m_InitalCapacity = 32;

    [SerializeField, Range(8, 64)]
    private int m_MaxCapacity = 64;

    [SerializeField]
    private InventoryUI m_InventoryUI;

    [SerializeField]
    private Item[] m_Items;
    
    public int Capacity { get; private set; }

    private void Awake()
    {
        m_Items = new Item[m_MaxCapacity];
        Capacity = m_InitalCapacity;
        m_InventoryUI.SetInventoryReference(this);
    }

    private void Start()
    {
        UpdateAccessibleStatesAll();
    }

    private bool IsValidIndex(int index)
    {
        return index >= 0 && index < Capacity;
    }

    private int FindEmptySlotIndex(int startindex = 0)
    {
        for (int i = startindex; i < Capacity; i++)
        {
            if (m_Items[i] == null)
            {
                return i; 
            }
        }
        return -1;
    }

    public void UpdateAccessibleStatesAll()
    {
        m_InventoryUI.SetAccessibleSlotRange(Capacity);
    }
}
