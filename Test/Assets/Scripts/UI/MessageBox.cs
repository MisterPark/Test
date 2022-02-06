using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBox : MonoBehaviour
{
    private string MainText;
    private int TextRepeat;

    public TMPro.TextMeshProUGUI TextContentTitle;
    public TMPro.TextMeshProUGUI TextContentMain;
    public CanvasGroup CanvasGroup;
    public float VisibleDuration;
    public float FadeInDuration = 0.5f;
    public float FadeOutDuration = 2f;
    public float TextInterval = 0.1f;
    private float CurTextInterval;
    // Start is called before the first frame update
    void Start()
    {
        CanvasGroup.alpha = 0f;
        TextRepeat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Initialized)
        {
            CurTextInterval += Time.deltaTime;
            if ((MainText.Length > TextRepeat) && (CurTextInterval > TextInterval))
            {
                ++TextRepeat;
                CurTextInterval = 0f;
            }
            TextContentMain.text = MainText.Substring(0, TextRepeat);
            float Compare_Endtime = Time.time - m_ShowTime;
            if (Compare_Endtime < FadeInDuration + VisibleDuration)
            {
                CanvasGroup.alpha = Compare_Endtime / FadeInDuration;
            }
            else if (Compare_Endtime < FadeInDuration + VisibleDuration)
            {
                CanvasGroup.alpha = 1f;
            }
            else if (Compare_Endtime < FadeInDuration + VisibleDuration + FadeOutDuration)
            {
                CanvasGroup.alpha = 1 - (Compare_Endtime - FadeInDuration - VisibleDuration) / FadeOutDuration;
            }
            else
            {
                CurTextInterval = 0f;
                TextRepeat = 0;
                CanvasGroup.alpha = 0f;
                Initialized = false;
                //Destroy(gameObject);
            }
            if (Input.GetButtonDown("MouseLeft"))
            {
                if (TextRepeat != MainText.Length)
                {
                    TextRepeat = MainText.Length;
                }
                else
                {
                    CurTextInterval = 0f;
                    TextRepeat = 0;
                    CanvasGroup.alpha = 0f;
                    Initialized = false;
                }
            }
        }
    }

    public bool Initialized { get; private set; }
    float m_ShowTime;

    public void Show(string titletext, string maintext, float visibletime = 3f, float textinterval = 0.1f)
    {
        if (!Initialized)
        {
            if (TextContentTitle != null)
            {
                TextContentTitle.text = titletext;
            }
            MainText = maintext;

            m_ShowTime = Time.time;
            VisibleDuration = visibletime;
            TextInterval = textinterval;

           Initialized = true;
        }
    }
}
