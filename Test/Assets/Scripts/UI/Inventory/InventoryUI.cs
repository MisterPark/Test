using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [Range(0 , 10)]
    [SerializeField] private int m_HorizontalSlotCount = 8;

    [Range(0, 10)]
    [SerializeField] private int m_VerticalSlotCount = 8;
    [SerializeField] private float m_SlotMargin = 64f;
    [SerializeField] private float m_ContentAreaPadding = 20f;

    [Range(32, 256)]
    [SerializeField] private float m_SlotSize = 128f;

    [SerializeField] private RectTransform m_SlotAreaRT;
    [SerializeField] private GameObject m_SlotUIPrefab;
    private List<ItemSlotUI> m_SlotUIList = new List<ItemSlotUI>();

    private Inventory m_Inventory;

    private enum FilterOption
    {
        All, Equipment, Portion
    }

    private FilterOption m_CurrentFilterOption = FilterOption.All;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        Init();
        InitSlots();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Init()
    {
    }
    private void InitSlots()
    {
        m_SlotUIPrefab.TryGetComponent(out RectTransform slotrect);
        slotrect.sizeDelta = new Vector2(m_SlotSize, m_SlotSize);

        m_SlotUIPrefab.TryGetComponent(out ItemSlotUI itemslot);
        if (itemslot == null)
        {
            m_SlotUIPrefab.AddComponent<ItemSlotUI>();
        }
        m_SlotUIPrefab.SetActive(false);

        Vector2 beginpos = new Vector2(m_ContentAreaPadding, -m_ContentAreaPadding);
        Vector2 curpos = beginpos;

        m_SlotUIList = new List<ItemSlotUI>(m_VerticalSlotCount * m_HorizontalSlotCount);

        for (int repeat = 0; repeat < m_VerticalSlotCount; ++repeat)
        {
            for (int repeat2 = 0; repeat2 < m_HorizontalSlotCount; ++repeat2)
            {
                int slotindex = (m_HorizontalSlotCount * repeat) + repeat2;

                var slotRT = CloneSlot();
                slotRT.pivot = new Vector2(0f, 1f);
                slotRT.anchoredPosition = curpos;
                slotRT.localScale = new Vector3(1f, 1f, 1f);
                slotRT.gameObject.SetActive(true);
                slotRT.gameObject.name = $"Item Slot[{slotindex}]";

                var slotUI = slotRT.GetComponent<ItemSlotUI>();
                slotUI.SetSlotIndex(slotindex);
                m_SlotUIList.Add(slotUI);

                curpos.x += (m_SlotMargin + m_SlotSize);

            }

            curpos.x = beginpos.x;
            curpos.y -= (m_SlotMargin + m_SlotSize);
        }

        RectTransform CloneSlot()
        {
            GameObject slotgo = Instantiate(m_SlotUIPrefab);
            RectTransform rt = slotgo.GetComponent<RectTransform>();
            rt.SetParent(m_SlotAreaRT);
            return rt;
        }
    }

    public void SetAccessibleSlotRange(int accessibleslotcount)
    {
        for (int i = 0; i < m_SlotUIList.Count; ++i)
        {
            m_SlotUIList[i].SetSlotAccessibleState(i < accessibleslotcount);
        }
    }

    public void SetInventoryReference(Inventory inventory)
    {
        m_Inventory = inventory;
    }

    public void SetItemIcon(int index, Sprite icon)
    {
        m_SlotUIList[index].SetItem(icon);
    }

    public void RemoveItem(int index)
    {
        m_SlotUIList[index].RemoveItem();
    }

    public void HideItemAmountText(int index)
    {
        m_SlotUIList[index].SetItemAmount(1);
    }
    public void UpdateSlotFilterState(int index, ItemData itemdata)
    {
        bool isfiltered = true;
        if (itemdata != null)
        {
            switch (m_CurrentFilterOption)
            {
                case FilterOption.Equipment:
                    break;
                case FilterOption.Portion:
                    isfiltered = (itemdata is PortionItemData);
                    break;
            }
            m_SlotUIList[index].SetItemAccessibleState(isfiltered);
        }
    }

    public void SetItemAmountText(int index, int amount)
    {
        m_SlotUIList[index].SetItemAmount(amount);
    }
}
