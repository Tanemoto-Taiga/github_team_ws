using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLine : MonoBehaviour
{
    void Start()
    {
        Text text = this.gameObject.GetComponentInChildren<Text>();
        text.color = Color.black;
    }


    public void AddLineObject()
    {
        SkillTreeManager stm = GameObject.Find("SkillTreeManagerObject").GetComponent<SkillTreeManager>();
        List<SkillTreeNodeClass> nodeList = stm.getNodeList();
        Text text = this.gameObject.GetComponentInChildren<Text>();
        if (text.color == Color.black)
        {
            text.color = Color.yellow;
            foreach (SkillTreeNodeClass node in nodeList)
            {
                node.addLineModeFlag = true;
            }
        }
        else
        {
            text.color = Color.black;
            foreach (SkillTreeNodeClass node in nodeList)
            {
                node.addLineModeFlag = false;
            }
            stm.ClearAddCombinationList();
        }
    }
}
