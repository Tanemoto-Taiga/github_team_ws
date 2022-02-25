using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 
public class Create : MonoBehaviour
{
    [SerializeField]
    private GameObject button1;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject addLineButton;

    public void createButton()
    {
        GameObject button = Instantiate(button1, new Vector3(960.0f, 270.0f, 0.0f), Quaternion.identity);
        button.transform.SetParent(canvas.transform);
        button.AddComponent<DragDropScript>();
        button.AddComponent<DestroyScript>();

        //button�I�u�W�F�N�g��SkillTreeNodeClass��ǉ��BSkillTreeNodeClass��button�I�u�W�F�N�g�̏�ԁi�ڕW���B���ł������Ȃǁj��\���N���X�ŁA�ebutton�I�u�W�F�N�g��1��1�ŕR�Â����Ă���
        //button.AddComponent<SkillTreeNodeClass>();
        //�ǉ�����SkillTreeNodeClass���C���X�^���X���B
        SkillTreeNodeClass node = button.GetComponent<SkillTreeNodeClass>();
        //SkillTreeManager�Ƃ����N���X���C���X�^���X���B���̃N���X�͑Sbutton�I�u�W�F�N�g�ɕR�Â����Ă���SkillTreeNodeClass�̃C���X�^���X���Ǘ��E���p���A�ǂ�button�I�u�W�F�N�g�Ԃɐ������������߂�
        SkillTreeManager stm = GameObject.Find("SkillTreeManagerObject").GetComponent<SkillTreeManager>();
        //SkillTreeManager���猻�ݑ��݂��Ă���SkillTreeNodeClass�̃C���X�^���X�����X�g�^�Ŏ擾
        List<SkillTreeNodeClass> nodeList = stm.getNodeList();
        //��Ŏ擾�������X�g�̗v�f��
        int nodeListCount = nodeList.Count;
        //���X�g�̗v�f����0�Ȃ�
        if (nodeListCount == 0)
        {
            //���ꂩ�����button�I�u�W�F�N�g��root�i�c���[�̈�ԏ�j�v�f�Ƃ���B
            //SkillTreeNodeClass��initialize���\�b�h�́Ainitialize(�R�Â�����button�I�u�W�F�N�g, ����button�I�u�W�F�N�g��ID, �e�v�f��SkillTreeNodeClass�C���X�^���X)
            node.initialize(button, nodeListCount, null);
        }
        //���X�g�̗v�f����0�ȊO�Ȃ�
        else
        {
            //���X�g�̍Ō���i����O�ɍ쐬����button�I�u�W�F�N�g��SkillTreeNodeClass�C���X�^���X�j�����ꂩ�����button�I�u�W�F�N�g�̐e�v�f�Ƃ��Ď擾
            SkillTreeNodeClass parentNode = nodeList.Last();
            //initialize(�R�Â�����button�I�u�W�F�N�g, ����button�I�u�W�F�N�g��ID, �e�v�f��SkillTreeNodeClass�C���X�^���X)
            node.initialize(button, nodeListCount, parentNode);
        }

        Image image = addLineButton.GetComponentInChildren<Image>();
        if(image.color == Color.gray)
        {
            node.addLineModeFlag = true;
        }

        //SkillTreeManager�̃��X�g�ɂ��ꂩ�����button�I�u�W�F�N�g�ɕR�Â����Ă���SkillTreeNodeClass�̃C���X�^���X��ǉ�
        stm.addNodeList(node);
    }
}