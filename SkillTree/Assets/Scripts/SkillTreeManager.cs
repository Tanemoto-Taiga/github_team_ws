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

    //各buttonオブジェクトに紐づけられているSkillTreeNodeClassのインスタンスを格納
    private static List<SkillTreeNodeClass> nodeList = new List<SkillTreeNodeClass>();

    //線を引く組み合わせを2次元リストで格納
    private static List<List<SkillTreeNodeClass>> lineCombinationList = new List<List<SkillTreeNodeClass>>();

    //lineオブジェクトを格納
    private static List<GameObject> lineObjectList = new List<GameObject>();

    //線追加用のリスト
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
        //線を引く組み合わせをリストに追加
        SkillTreeManager.lineCombinationList.Add(combination);

        //線を描画するlineオブジェクトを作成
        GameObject lineObject = Instantiate(LinePrefab, new Vector3(402.0f, 120.0f, 0.0f), Quaternion.identity) as GameObject;
        lineObject.transform.SetParent(canvas.transform);
        //lineオブジェクトの座標を指定するUIOneLineクラスのインスタンス
        UIOneLine oneLine = lineObject.GetComponent<UIOneLine>();
        oneLine.setLineObject(lineObject);
        oneLine.parentButton = combination[0].getButton();
        oneLine.childButton = combination[1].getButton();

        //combinationには2つのSkillTreeNodeClassインスタンスが入っており、このインスタンスが紐づけられているbuttonオブジェクト間に線を引く
        //まずは0番目のSkillTreeNodeClassインスタンスから紐づけられているbuttonオブジェクトを取得
        GameObject button0 = combination[0].getButton();
        //buttonオブジェクトから座標を取得
        Vector3 position0 = button0.transform.position;
        //setPosition1メソッドは線の始点座標を指定する
        oneLine.setPosition1(position0);

        //1番目のSkillTreeNodeClassインスタンスから紐づけられているbuttonオブジェクトを取得
        GameObject button1 = combination[1].getButton();
        //buttonオブジェクトから座標を取得
        Vector3 position1 = button1.transform.position;
        //setPosition2メソッドは線の終点座標を指定する
        oneLine.setPosition2(position1);

        //lineオブジェクトをリストに追加
        SkillTreeManager.lineObjectList.Add(lineObject);
    }

    public void RemoveLine(GameObject rmButton)
    {
        SkillTreeNodeClass rmButtonNode = rmButton.GetComponent<SkillTreeNodeClass>();
        //lineObjectListから削除対象のlineオブジェクトを探して削除
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
        //線を引く処理を毎フレーム行う（buttonオブジェクトの座標移動についていくため）

        //何個目の線を引くかカウント
        int combinationCount = 0;
        //lineObjectListから現在存在するlineオブジェクトを一つずつ取得
        foreach (GameObject line in lineObjectList)
        {
            //lineオブジェクトが持つUIOneLineクラスのインスタンスを取得
            UIOneLine oneLine = line.GetComponent<UIOneLine>();
            //そのlineオブジェクトに対応するSkillTreeNodeClassインスタンスの組を取得
            List<SkillTreeNodeClass> combination = lineCombinationList[combinationCount];

            //さっきの処理をコピー
            //まずは0番目のSkillTreeNodeClassインスタンスから紐づけられているbuttonオブジェクトを取得
            GameObject button0 = combination[0].getButton();
            //buttonオブジェクトから座標を取得
            Vector3 position0 = button0.transform.position;
            //setPosition1メソッドは線の始点座標を指定する
            oneLine.setPosition1(position0);

            //1番目のSkillTreeNodeClassインスタンスから紐づけられているbuttonオブジェクトを取得
            GameObject button1 = combination[1].getButton();
            //buttonオブジェクトから座標を取得
            Vector3 position1 = button1.transform.position;
            //setPosition2メソッドは線の終点座標を指定する
            oneLine.setPosition2(position1);

            //カウントを一つ進める
            combinationCount++;
        }
    }
}
