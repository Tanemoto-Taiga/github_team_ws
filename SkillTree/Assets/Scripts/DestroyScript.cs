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
        else if (Input.GetMouseButtonDown(0))
        {
            this.DestroyFlag = false;
        }
    }


    /// <summary>
    /// ドラッグ開始時に呼び出される
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.DestroyFlag == true)
        {
            SkillTreeManager stm = GameObject.Find("SkillTreeManagerObject").GetComponent<SkillTreeManager>();
            stm.ClearAddCombinationList();
            stm.RemoveLine(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}