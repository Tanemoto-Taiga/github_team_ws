using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleClickButton : MonoBehaviour
{

    bool isClick;
    private EventSystem eventSystem;
    private GameObject button_ob;
    private GameObject NameText_ob;
    private Text name_text;
    public InputField inputField;
    public Text text;

    void Start () {
        inputField = inputField.GetComponent<InputField> ();
        text = text.GetComponent<Text> ();
    }

    public void OnClick()
    {
        if (!isClick)
        {
            isClick = true;
            StartCoroutine(MeasureTime());
        }
        else
        {
            DoubleClick();
            isClick = false;
        }

    }

    IEnumerator MeasureTime()
    {
        var times = 0f;
        while (isClick)
        {
            times += Time.deltaTime;
            if (times < 0.5f)
            {
                yield return null;
            }
            else
            {
                isClick = false;
                SingleClick();
                yield break;
            }
        }
    }

    void SingleClick()
    {
        
    }

    void DoubleClick()
    {
        eventSystem = EventSystem.current;

        button_ob = eventSystem.currentSelectedGameObject;

        NameText_ob = button_ob.transform.Find("Text").gameObject;

        name_text = NameText_ob.GetComponent<Text>();

        name_text.text = inputField.text;
    }

}