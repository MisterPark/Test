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

    private int FindCountableItemSlotIndex(CountableItemData target, int startindex = 0)
    {
        for (int repeat = startindex; repeat < Capacity; ++repeat)
        {
            var current = m_Items[repeat];
            if (current == null)
            {
                continue;
            }

            if (current.Data == target && current is CountableItem ci)
            {
                if (!ci.IsMax)
                {
                    return repeat;
                }
            }
        }

        return -1;
    }

    private void UpdateSlot(int index)
    {
        if (!IsValidIndex(index))
        {
            return;
        }

        Item item = m_Items[index];

        if (item != null)
        {
            m_InventoryUI.SetItemIcon(index, item.Data.IconSprite);

            if (item is CountableItem ci)
            {
                if (ci.IsEmpty)
                {
                    m_Items[index] = null;
                    RemoveIcon();
                    return;
                }

                else
                {
                    m_InventoryUI.SetItemAmountText(index, ci.Amount);
                }
            }
            else
            {
                m_InventoryUI.HideItemAmountText(index);
            }

            m_InventoryUI.UpdateSlotFilterState(index, item.Data);
        }

        else
        {
            RemoveIcon();
        }

        void RemoveIcon()
        {
            m_InventoryUI.RemoveItem(index);
            m_InventoryUI.HideItemAmountText(index);
        }
    }

    private void UpdateSlot(params int[] indices)
    {
        foreach (var i in indices)
        {
            UpdateSlot(i);
        }
    }

    public void UpdateAccessibleStatesAll()
    {
        m_InventoryUI.SetAccessibleSlotRange(Capacity);
    }

    public void ConnectUI(InventoryUI inventoryUI)
    {
        m_InventoryUI = inventoryUI;
        m_InventoryUI.SetInventoryReference(this);
    }

    public int Add(ItemData itemdata, int amount = 1)
    {
        int index;

        if (itemdata is CountableItemData cidata)
        {
            bool findnextcountable = true;
            index = -1;

            while (amount > 0)
            {

                if (findnextcountable)
                {
                    index = FindCountableItemSlotIndex(cidata, index + 1);

                    if (index == -1)
                    {
                        findnextcountable = false;
                    }
                    else
                    {
                        CountableItem ci = m_Items[index] as CountableItem;
                        amount = ci.AddAmountAndGetExcess(amount);

                        UpdateSlot(index);
                    }
                }

                else
                {
                    index = FindEmptySlotIndex(index + 1);

                    if (index == -1)
                    {
                        break;
                    }

                    else
                    {
                        CountableItem ci = cidata.CreateItem() as CountableItem;
                        ci.SetAmount(amount);

                        m_Items[index] = ci;

                        amount = (amount > cidata.MaxAmount) ? (amount - cidata.MaxAmount) : 0;

                        UpdateSlot(index);
                    }
                }
            }
        }

        else 
        {

        }
        return amount;
    }
}
