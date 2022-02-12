using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [Tooltip("슬롯 내에서 아이콘과 슬롯 사이의 여백")]
    [SerializeField] private float m_Padding = 1f;

    [Tooltip("아이템 아이콘 이미지")]
    [SerializeField] private Image m_IconImage;

    [Tooltip("아이템 개수 텍스트")]
    [SerializeField] private Text m_AmountText;

    [Tooltip("슬롯 포커스 하이라이트 이미지")]
    [SerializeField] private Image m_HighlightImage;

    [Space]
    [Tooltip("하이라이트 이미지 알파 값")]
    [SerializeField] private float m_HighlightAlpha = 0.5f;

    [Tooltip("하이라이트 소요 시간")]
    [SerializeField] private float m_HighlightFadeDuration = 0.2f;

    private bool m_IsAccessibleSlot = true;
    private bool m_IsAccessibleItem = true;
    private RectTransform m_SlotRect;
    private RectTransform m_IconRect;
    private RectTransform m_HighlightRect;
    private float m_CurrentHLAlpha = 0f;

    private InventoryUI m_InventoryUI;

    private Image m_SlotImage;

    private GameObject m_IconGo;
    private GameObject m_TextGo;
    private GameObject m_HighlightGo;
    public int Index { get; private set; }

    public bool HasItem => m_IconImage.sprite != null;

    public bool IsAccessible => m_IsAccessibleSlot && m_IsAccessibleItem;

    public RectTransform slotrect => m_SlotRect;
    public RectTransform iconrect => m_IconRect;

    private static readonly Color InaccessibleSlotColor = new Color(0.2f, 0.2f, 0.2f, 0.5f);
    private static readonly Color InaccessibleIconColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        InitComponents();
        InitValues();
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void InitComponents()
    {
        m_InventoryUI = GetComponentInParent<InventoryUI>();

        m_SlotRect = GetComponent<RectTransform>();
        m_IconRect = m_IconImage.rectTransform;
        m_HighlightRect = m_HighlightImage.rectTransform;

        m_IconGo = m_IconRect.gameObject;
        m_TextGo = m_AmountText.gameObject;
        m_HighlightGo = m_HighlightRect.gameObject;

        m_SlotImage = GetComponent<Image>();
    }

    private void InitValues()
    {
        m_IconRect.pivot = new Vector2(0.5f, 0.5f);
        m_IconRect.anchorMin = Vector2.zero;
        m_IconRect.anchorMax = Vector2.one;

        m_IconRect.offsetMin = Vector2.one * (m_Padding);
        m_IconRect.offsetMax = Vector2.one * (-m_Padding);

        m_HighlightRect.pivot = m_IconRect.pivot;
        m_HighlightRect.anchorMin = m_IconRect.anchorMin;
        m_HighlightRect.anchorMax = m_IconRect.anchorMax;
        m_HighlightRect.offsetMin = m_IconRect.offsetMin;
        m_HighlightRect.offsetMax = m_IconRect.offsetMax;

        m_IconImage.raycastTarget = false;
        m_HighlightImage.raycastTarget = false;

        HideIcon();
        m_HighlightGo.SetActive(false);
    }
    private void ShowIcon() => m_IconGo.SetActive(true);
    private void HideIcon() => m_IconGo.SetActive(false);

    private void ShowText() => m_TextGo.SetActive(true);
    private void HideText() => m_TextGo.SetActive(false);

    public void SetSlotIndex(int index) => Index = index;

    public void SetSlotAccessibleState(bool value)
    {
        if (m_IsAccessibleSlot == value)
        {
            return;
        }

        if (value)
        {
            m_SlotImage.color = Color.black;
        }
        else 
        {
            m_SlotImage.color = InaccessibleSlotColor;
            HideIcon();
            HideText();
        }

        m_IsAccessibleSlot = value;
    }

    public void SetItemAccessibleState(bool value)
    {
        if (m_IsAccessibleItem == value)
        {
            return;
        }
        if (value)
        {
            m_IconImage.color = Color.white;
            m_AmountText.color = Color.white;
        }
        else
        {
            m_IconImage.color = InaccessibleIconColor;
            m_AmountText.color = InaccessibleIconColor;
        }
        m_IsAccessibleItem = value;
    }
    public void SetItem(Sprite itemsprite)
    {
        if (itemsprite != null)
        {
            m_IconImage.sprite = itemsprite;
            ShowIcon();
        }
        else 
        {
            RemoveItem();
        }
    }

    public void RemoveItem()
    {
        m_IconImage.sprite = null;
        HideIcon();
        HideText();
    }

    public void SetItemAmount(int amount)
    {
        if (HasItem && amount > 1)
        {
            ShowText();
        }
        else 
        {
            HideText();
        }

        m_AmountText.text = amount.ToString();
    }
}
