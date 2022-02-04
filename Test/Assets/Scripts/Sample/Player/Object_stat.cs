using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Object_Stat : ScriptableObject
{
    private string m_StateName = "New State";

    public string StateName
    {
        get => m_StateName;
        set => m_StateName = value;
    }

    private float m_BaseValue;

    private float m_Value;
    public float Value
    {
        get => m_Value;
    }

    private Stats_Handler m_StatsHandler;
    public void Add(float amount)
    {
        m_BaseValue += amount;
        m_BaseValue = Mathf.Clamp(m_BaseValue, 0, float.MaxValue);
        CalculateValue();
    }

    public void Initialize(Stats_Handler handler)
    {
        m_StatsHandler = handler;
    }

    public void CalculateValue()
    {
        m_Value = m_BaseValue;
    }
}
