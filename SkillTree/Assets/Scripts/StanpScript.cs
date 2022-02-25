using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class StanpScript : MonoBehaviour
{
    [SerializeField]
    private GameObject image1;
    [SerializeField]
    private GameObject canvas;
 
    public void createButton()
    {
        GameObject button = Instantiate(image1, new Vector3(960.0f, 270.0f, 0.0f), Quaternion.identity);
        button.transform.SetParent(canvas.transform);
        button.AddComponent<DragDropScript>();
    }
}