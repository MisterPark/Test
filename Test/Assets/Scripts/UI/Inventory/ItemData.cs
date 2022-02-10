using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    [SerializeField] private int m_ID;
    [SerializeField] private string m_Name;
    [Multiline]
    [SerializeField] private string m_Tooltip;
    [SerializeField] private Sprite m_IconSprite;
    [SerializeField] private GameObject m_DropItemPrefab;

    public int ID => m_ID;
    public string Name => m_Name;
    public string Tooltip => m_Tooltip;
    public Sprite IconSprite => m_IconSprite;

    public abstract Item CreateItem();
}
