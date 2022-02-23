using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DestroyScript : MonoBehaviour, IPointerClickHandler
{
    private Vector2 prevPosition;

    bool DestroyFlag = false;

    public void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            this.DestroyFlag = true;
        }
    }


    /// <summary>
    /// �h���b�O�J�n���ɌĂяo�����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.DestroyFlag == true)
        {
            Destroy(this.gameObject);
        }
    }
}