using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject LinePrefab;
    [SerializeField]
    private GameObject addLineButton;

    //�ebutton�I�u�W�F�N�g�ɕR�Â����Ă���SkillTreeNodeClass�̃C���X�^���X���i�[
    private static List<SkillTreeNodeClass> nodeList = new List<SkillTreeNodeClass>();

    //���������g�ݍ��킹��2�������X�g�Ŋi�[
    private static List<List<SkillTreeNodeClass>> lineCombinationList = new List<List<SkillTreeNodeClass>>();

    //line�I�u�W�F�N�g���i�[
    private static List<GameObject> lineObjectList = new List<GameObject>();

    //���ǉ��p�̃��X�g
    private static List<SkillTreeNodeClass> addCombinationList = new List<SkillTreeNodeClass>();

    public void addNodeList(SkillTreeNodeClass node)
    {
        SkillTreeManager.nodeList.Add(node);
    }

    public List<SkillTreeNodeClass> getNodeList()
    {
        return SkillTreeManager.nodeList;
    }

    public void addLineCombinationList(List<SkillTreeNodeClass> combination)
    {
        //���������g�ݍ��킹�����X�g�ɒǉ�
        SkillTreeManager.lineCombinationList.Add(combination);

        //����`�悷��line�I�u�W�F�N�g���쐬
        GameObject lineObject = Instantiate(LinePrefab, new Vector3(402.0f, 120.0f, 0.0f), Quaternion.identity) as GameObject;
        lineObject.transform.SetParent(canvas.transform);
        //line�I�u�W�F�N�g�̍��W���w�肷��UIOneLine�N���X�̃C���X�^���X
        UIOneLine oneLine = lineObject.GetComponent<UIOneLine>();
        oneLine.setLineObject(lineObject);
        oneLine.parentButton = combination[0].getButton();
        oneLine.childButton = combination[1].getButton();

        //combination�ɂ�2��SkillTreeNodeClass�C���X�^���X�������Ă���A���̃C���X�^���X���R�Â����Ă���button�I�u�W�F�N�g�Ԃɐ�������
        //�܂���0�Ԗڂ�SkillTreeNodeClass�C���X�^���X����R�Â����Ă���button�I�u�W�F�N�g���擾
        GameObject button0 = combination[0].getButton();
        //button�I�u�W�F�N�g������W���擾
        Vector3 position0 = button0.transform.position;
        //setPosition1���\�b�h�͐��̎n�_���W���w�肷��
        oneLine.setPosition1(position0);

        //1�Ԗڂ�SkillTreeNodeClass�C���X�^���X����R�Â����Ă���button�I�u�W�F�N�g���擾
        GameObject button1 = combination[1].getButton();
        //button�I�u�W�F�N�g������W���擾
        Vector3 position1 = button1.transform.position;
        //setPosition2���\�b�h�͐��̏I�_���W���w�肷��
        oneLine.setPosition2(position1);

        //line�I�u�W�F�N�g�����X�g�ɒǉ�
        SkillTreeManager.lineObjectList.Add(lineObject);
    }

    public void RemoveLine(GameObject rmButton)
    {
        SkillTreeNodeClass rmButtonNode = rmButton.GetComponent<SkillTreeNodeClass>();
        //lineObjectList����폜�Ώۂ�line�I�u�W�F�N�g��T���č폜
        for (int i = lineObjectList.Count - 1; i >= 0; i--)
        {
            if ((lineObjectList[i].GetComponent<UIOneLine>().parentButton == rmButton) ^ (lineObjectList[i].GetComponent<UIOneLine>().childButton == rmButton))
            {
                Destroy(lineObjectList[i]);
                lineObjectList.RemoveAt(i);
                lineCombinationList.RemoveAt(i);
            }
        }

        for (int i = nodeList.Count - 1; i >= 0; i--)
        {
            if(nodeList[i] == rmButtonNode)
            {
                nodeList.RemoveAt(i);
            }
        }
    }

    public void addLineCombination(SkillTreeNodeClass node)
    {
        if(addCombinationList.Count == 1)
        {
            if(addCombinationList[0] == node)
            {
                return;
            }
        }
        addCombinationList.Add(node);
        if(addCombinationList.Count == 2)
        {
            addLineCombinationList(new List<SkillTreeNodeClass>(addCombinationList));
            addCombinationList.Clear();
        }
    }

    public void ClearAddCombinationList()
    {
        addCombinationList.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        //�������������𖈃t���[���s���ibutton�I�u�W�F�N�g�̍��W�ړ��ɂ��Ă������߁j

        //���ڂ̐����������J�E���g
        int combinationCount = 0;
        //lineObjectList���猻�ݑ��݂���line�I�u�W�F�N�g������擾
        foreach (GameObject line in lineObjectList)
        {
            //line�I�u�W�F�N�g������UIOneLine�N���X�̃C���X�^���X���擾
            UIOneLine oneLine = line.GetComponent<UIOneLine>();
            //����line�I�u�W�F�N�g�ɑΉ�����SkillTreeNodeClass�C���X�^���X�̑g���擾
            List<SkillTreeNodeClass> combination = lineCombinationList[combinationCount];

            //�������̏������R�s�[
            //�܂���0�Ԗڂ�SkillTreeNodeClass�C���X�^���X����R�Â����Ă���button�I�u�W�F�N�g���擾
            GameObject button0 = combination[0].getButton();
            //button�I�u�W�F�N�g������W���擾
            Vector3 position0 = button0.transform.position;
            //setPosition1���\�b�h�͐��̎n�_���W���w�肷��
            oneLine.setPosition1(position0);

            //1�Ԗڂ�SkillTreeNodeClass�C���X�^���X����R�Â����Ă���button�I�u�W�F�N�g���擾
            GameObject button1 = combination[1].getButton();
            //button�I�u�W�F�N�g������W���擾
            Vector3 position1 = button1.transform.position;
            //setPosition2���\�b�h�͐��̏I�_���W���w�肷��
            oneLine.setPosition2(position1);

            //�J�E���g����i�߂�
            combinationCount++;
        }
    }
}
