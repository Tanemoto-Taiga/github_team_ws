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

        //buttonオブジェクトにSkillTreeNodeClassを追加。SkillTreeNodeClassはbuttonオブジェクトの状態（目標が達成できたかなど）を表すクラスで、各buttonオブジェクトと1対1で紐づけられている
        //button.AddComponent<SkillTreeNodeClass>();
        //追加したSkillTreeNodeClassをインスタンス化。
        SkillTreeNodeClass node = button.GetComponent<SkillTreeNodeClass>();
        //SkillTreeManagerというクラスをインスタンス化。このクラスは全buttonオブジェクトに紐づけられているSkillTreeNodeClassのインスタンスを管理・利用し、どのbuttonオブジェクト間に線を引くか決める
        SkillTreeManager stm = GameObject.Find("SkillTreeManagerObject").GetComponent<SkillTreeManager>();
        //SkillTreeManagerから現在存在しているSkillTreeNodeClassのインスタンスをリスト型で取得
        List<SkillTreeNodeClass> nodeList = stm.getNodeList();
        //上で取得したリストの要素数
        int nodeListCount = nodeList.Count;
        //リストの要素数が0なら
        if (nodeListCount == 0)
        {
            //これからつくるbuttonオブジェクトはroot（ツリーの一番上）要素とする。
            //SkillTreeNodeClassのinitializeメソッドは、initialize(紐づけするbuttonオブジェクト, このbuttonオブジェクトのID, 親要素のSkillTreeNodeClassインスタンス)
            node.initialize(button, nodeListCount, null);
        }
        //リストの要素数が0以外なら
        else
        {
            //リストの最後尾（＝一つ前に作成したbuttonオブジェクトのSkillTreeNodeClassインスタンス）をこれからつくるbuttonオブジェクトの親要素として取得
            SkillTreeNodeClass parentNode = nodeList.Last();
            //initialize(紐づけするbuttonオブジェクト, このbuttonオブジェクトのID, 親要素のSkillTreeNodeClassインスタンス)
            node.initialize(button, nodeListCount, parentNode);
        }

        Image image = addLineButton.GetComponentInChildren<Image>();
        if(image.color == Color.gray)
        {
            node.addLineModeFlag = true;
        }

        //SkillTreeManagerのリストにこれからつくるbuttonオブジェクトに紐づけられているSkillTreeNodeClassのインスタンスを追加
        stm.addNodeList(node);
    }
}