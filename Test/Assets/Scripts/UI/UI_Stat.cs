using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stat : MonoBehaviour
{
    public int Max_HP = 100;
    
    public int Current_HP;

    public Image m_HPBar;
    // Start is called before the first frame update
    void Start()
    {
        Current_HP = Max_HP;
    }

    // Update is called once per frame
    void Update()
    {
        Repaint();
    }

    private void Repaint()
    {
        float normalized = Current_HP / Max_HP;

        m_HPBar.fillAmount = Mathf.MoveTowards(m_HPBar.fillAmount, normalized, Time.deltaTime * 0.5f);
    }
}
