using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputText : MonoBehaviour {

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

    public void ChangeButtonTextName()
    {
        eventSystem = EventSystem.current;

        button_ob = eventSystem.currentSelectedGameObject;

        NameText_ob = button_ob.transform.Find("Text").gameObject;

        name_text = NameText_ob.GetComponent<Text>();

        name_text.text = inputField.text;
    }
}