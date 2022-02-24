using UnityEngine;
using UnityEngine.UI;
public class UIOneLine : Graphic
{
    //���g�̐��I�u�W�F�N�g
    [SerializeField]
    private GameObject lineObject;

    [SerializeField]
    private Vector2 _position1 = new Vector2(0, 0);
    [SerializeField]
    private Vector2 _position2;
    [SerializeField]
    private float _weight = 2;

    public void setLineObject(GameObject lineObject)
    {
        this.lineObject = lineObject;
    }

    //���̎n�_���W���w��
    public void setPosition1(Vector3 p1)
    {
        this.lineObject.transform.position = p1;
        SetVerticesDirty();
    }

    //���̏I�_���W���w��
    public void setPosition2(Vector3 button2vec)
    {
        Vector3 p2 = button2vec - lineObject.transform.position;
        this._position2 = (Vector2)p2;
        SetVerticesDirty();
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        // �i�P�j�ߋ��̒��_���폜
        vh.Clear();

        // �i�Q�j�����x�N�g���̌v�Z
        var pos1_to_2 = _position2 - _position1;
        var verticalVector = CalcurateVerticalVector(pos1_to_2);

        // �i�R�j�����A����̃x�N�g�����v�Z
        var pos1Top = _position1 + verticalVector * -_weight / 2;
        var pos1Bottom = _position1 + verticalVector * _weight / 2;
        var pos2Top = _position2 + verticalVector * -_weight / 2;
        var pos2Bottom = _position2 + verticalVector * _weight / 2;

        // �i�S�j���_�𒸓_���X�g�ɒǉ�
        AddVert(vh, pos1Top);
        AddVert(vh, pos1Bottom);
        AddVert(vh, pos2Top);
        AddVert(vh, pos2Bottom);


        // �i�T�j���_���X�g�����Ƀ��b�V����\��
        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(1, 2, 3);
    }
    private void AddVert(VertexHelper vh, Vector2 pos)
    {
        var vert = UIVertex.simpleVert;
        vert.position = pos;
        vert.color = color;
        vh.AddVert(vert);
    }

    private Vector2 CalcurateVerticalVector(Vector2 vec)
    {
        // 0���Z�̖h�~
        if (vec.y == 0)
        {
            return Vector2.up;
        }
        else
        {
            var verticalVector = new Vector2(1.0f, -vec.x / vec.y);
            return verticalVector.normalized;
        }
    }
}