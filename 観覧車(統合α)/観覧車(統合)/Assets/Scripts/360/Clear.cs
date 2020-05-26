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

    [SerializeField, Header("SpotLightを入れてね")]
    GameObject lig;

    public bool isClear;
    public Vector3 clearPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        clearPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {

        if (PossessionJudge() && SoulAngleJudge() && SoulMoveJudge())
        {
            isClear = true;
            lig.transform.parent = null;
        }
        else
        {
            isClear = false;
        }



        if (!isClear)
        {
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
        if (Mathf.Abs(soul.transform.rotation.x - answerSoulAngleX) < errorRangeSoulAngleX)
        {
            return true;
        }
        return false;
    }


    bool SoulMoveJudge()
    {

        if (Mathf.Abs(soul.transform.position.x - answerSoulMoveX) < errorRangeSoulMoveX)
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
