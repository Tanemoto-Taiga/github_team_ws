using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddLine : MonoBehaviour
{
    public void AddLineObject()
    {
        SkillTreeManager stm = GameObject.Find("SkillTreeManagerObject").GetComponent<SkillTreeManager>();
        List<SkillTreeNodeClass> nodeList = stm.getNodeList();
        Image image = this.gameObject.GetComponentInChildren<Image>();
        if (image.color == Color.white)
        {
            image.color = Color.gray;
            foreach (SkillTreeNodeClass node in nodeList)
            {
                node.addLineModeFlag = true;
            }
        }
        else
        {
            image.color = Color.white;
            foreach (SkillTreeNodeClass node in nodeList)
            {
                node.addLineModeFlag = false;
            }
            stm.ClearAddCombinationList();
        }
    }
}
