using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeNodeClass : MonoBehaviour
{
    //�R�Â����Ă���button�I�u�W�F�N�g
    private GameObject button;

    //ID�B0��root�ŁA0,1,2,3,4�c�ƃ{�^���I�u�W�F�N�g������x�Ɋ���U����
    private int id;

    //�e�v�f
    private SkillTreeNodeClass parentNode;

    //�q�v�f
    private List<SkillTreeNodeClass> childList = new List<SkillTreeNodeClass>();

    public bool addLineModeFlag = false;

    //���̗v�f�̃{�^���I�u�W�F�N�g�Ɛe�v�f���C���X�^���X�쐬���Ɏw��.���̗v�f��root�ł���ꍇ��parentNode��null����
    public void initialize(GameObject btn, int id, SkillTreeNodeClass parentNode)
    {
        this.button = btn;
        this.id = id;
        this.parentNode = parentNode;

        //parentNode��null�łȂ���΁i�����̗v�f���e�����ꍇ�j�A�e�v�f��childList�Ɏ��g��ǉ�
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

    //���̗v�f�̎q�v�f��ǉ�
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
