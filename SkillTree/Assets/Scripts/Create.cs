using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Create : MonoBehaviour
{
    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject canvas;
 
    public void createButton()
    {
        GameObject button = Instantiate(button1, new Vector3(960.0f, 270.0f, 0.0f), Quaternion.identity);
        button.transform.parent = canvas.transform;
        button.AddComponent<DragDropScript>();
    }
}