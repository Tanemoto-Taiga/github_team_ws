using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeNodeClass : MonoBehaviour
{
    //紐づけられているbuttonオブジェクト
    private GameObject button;

    //ID。0がrootで、0,1,2,3,4…とボタンオブジェクトをつくる度に割り振られる
    private int id;

    //親要素
    private SkillTreeNodeClass parentNode;

    //子要素
    private List<SkillTreeNodeClass> childList = new List<SkillTreeNodeClass>();

    public bool addLineModeFlag = false;

    //この要素のボタンオブジェクトと親要素をインスタンス作成時に指定.この要素がrootである場合はparentNodeにnullを代入
    public void initialize(GameObject btn, int id, SkillTreeNodeClass parentNode)
    {
        this.button = btn;
        this.id = id;
        this.parentNode = parentNode;

        //parentNodeがnullでなければ（＝この要素が親を持つ場合）、親要素のchildListに自身を追加
        if(parentNode != null)
        {
            parentNode.addChild(this);
        }
    }

    public GameObject getButton()
    {
        return this.button;
    }

    public int getId()
    {
        return this.id;
    }

    public void setParentNode(SkillTreeNodeClass parent)
    {
        this.parentNode = parent;
    }

    public SkillTreeNodeClass getParentNode()
    {
        return this.parentNode;
    }

    //この要素の子要素を追加
    public void addChild(SkillTreeNodeClass child)
    {
        this.childList.Add(child);
    }

    public List<SkillTreeNodeClass> getChildList()
    {
        return this.childList;
    }

    public void AddThisToLineCombination()
    {
        SkillTreeManager stm = GameObject.Find("SkillTreeManagerObject").GetComponent<SkillTreeManager>();
        if (this.addLineModeFlag)
        {
            stm.addLineCombination(this);
        }
    }
}
