using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [Header("各角度どれくらいかの設定")]
    [Space(-10)]
    [SerializeField, Header("正解の憑依物の角度誤差±いくつまで許容するか")]
    float errorRangePossession;

    [SerializeField, Header("正解の憑依物の角度")]
    Vector3 answerPossessionAngle;

    [SerializeField, Header("正解の魂のX回転角度")]
    float answerSoulAngleX;

    [SerializeField, Header("正解の魂のX座標(近づき具合)")]
    float answerSoulMoveX;

    [SerializeField, Header("正解の魂の誤差X回転角度")]
    float errorRangeSoulAngleX;

    [SerializeField, Header("正解の魂の誤差X座標")]
    float errorRangeSoulMoveX;


    [SerializeField, Header("憑依物(親オブジェクト)")]
    GameObject possession;

    [SerializeField, Header("魂(外周部の親のオブジェクト)")]
    GameObject soul;


    public bool isClear;
    public Vector3 clearPosition;

    [SerializeField, Header("クリア関係のCanvas")]
    GameObject ClearCanvas;

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        ClearCanvas.SetActive(false);
        clearPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (PossessionJudge() && SoulAngleJudge() && SoulMoveJudge())
        {
            isClear = true;
        }
        else
        {
            isClear = false;
        }



        if (isClear)
        {
            ClearCanvas.SetActive(true);
        }
        else
        {
            ClearCanvas.SetActive(false);
            clearPosition = transform.position;
        }
    }

    bool PossessionJudge()
    {
        var answer_rot = Quaternion.Euler(answerPossessionAngle);
        if (Quaternion.Angle(possession.transform.rotation, answer_rot) <= errorRangePossession)
        {
            return true;
        }

        return false;
    }


    bool SoulAngleJudge()
    {
        var answerSoulRot =
            new Vector3(
                answerSoulAngleX,
                soul.transform.rotation.y,
                soul.transform.rotation.z);

        var answer_rot = Quaternion.Euler(answerSoulRot);
        if (Quaternion.Angle(soul.transform.rotation, answer_rot) <= errorRangeSoulAngleX)
        {
            return true;
        }

        return false;
    }


    bool SoulMoveJudge()
    {
        var answerSoulMove =
            new Vector3(
                answerSoulMoveX,
                soul.transform.position.y,
                soul.transform.position.z);

        if (Vector3.Distance(answerSoulMove, soul.transform.position) <= errorRangeSoulMoveX)
        {
            return true;
        }

        return false;
    }


    public bool GetClearFlag()
    {
        return isClear;
    }
}
