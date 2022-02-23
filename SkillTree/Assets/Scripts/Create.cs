using System.Linq;
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
        button.transform.SetParent(canvas.transform);
        button.AddComponent<DragDropScript>();

        button.AddComponent<SkillTreeNodeClass>();
        SkillTreeNodeClass node = button.GetComponent<SkillTreeNodeClass>();
        SkillTreeManager stm = GameObject.Find("SkillTreeManagerObject").GetComponent<SkillTreeManager>();
        List<SkillTreeNodeClass> nodeList = stm.getNodeList();
        int nodeListCount = nodeList.Count;
        if(nodeListCount == 0)
        {
            node.initialize(button, nodeListCount, null);
        }
        else
        {
            SkillTreeNodeClass parentNode = nodeList.Last();
            node.initialize(button, nodeListCount, parentNode);
        }

        stm.addNodeList(node);
    }
}