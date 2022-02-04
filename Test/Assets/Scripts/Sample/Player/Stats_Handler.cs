using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats_Handler : MonoBehaviour
{
    private string m_HandlerName = string.Empty;

    public string HandlerName
    {
        get { return this.m_HandlerName; }
    }
    public List<Object_Stat> m_Stat_List = new List<Object_Stat>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < m_Stat_List.Count; ++i)
        {
            m_Stat_List[i].Initialize(this);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
