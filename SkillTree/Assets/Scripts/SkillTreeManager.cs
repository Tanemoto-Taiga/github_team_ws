using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject LinePrefab;

    //�ebutton�I�u�W�F�N�g�̃R���|�[�l���g�ł���SkillTreeNodeClass�̃C���X�^���X���i�[
    private static List<SkillTreeNodeClass> nodeList = new List<SkillTreeNodeClass>();

    //���������g�ݍ��킹��2�������X�g�ŕ\��
    private static List<List<SkillTreeNodeClass>> lineCombinationList = new List<List<SkillTreeNodeClass>>();

    //line�I�u�W�F�N�g���i�[
    private static List<GameObject> lineObjectList = new List<GameObject>();

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
        SkillTreeManager.lineCombinationList.Add(combination);

        GameObject lineObject = GameObject.Find("LineManagerObject");
        //GameObject lineObject = Instantiate(LinePrefab, new Vector3(402.0f, 120.0f, 0.0f), Quaternion.identity) as GameObject;
        //lineObject.transform.SetParent(canvas.transform);
        UIOneLine oneLine = lineObject.GetComponent<UIOneLine>();
        oneLine.setLineObject(lineObject);

        GameObject button = combination[0].getButton();
        Vector2 position = (Vector2) button.transform.position;
        oneLine.setPosition1(position);

        oneLine.setPosition2(combination[1].getButton());

        SkillTreeManager.lineObjectList.Add(lineObject);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject line in lineObjectList)
        {
            UIOneLine oneLine = line.GetComponent<UIOneLine>();
            foreach (List<SkillTreeNodeClass> combination in lineCombinationList)
            {
                GameObject button = combination[0].getButton();
                Vector2 position = (Vector2)button.transform.position;
                oneLine.setPosition1(position);

                oneLine.setPosition2(combination[1].getButton());
            }
        }
    }
}
