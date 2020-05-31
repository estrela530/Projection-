using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    [Header("各角度どれくらいかの設定")]
    [Space(-10)]
    [SerializeField, Header("正解の憑依物の角度誤差±いくつまで許容するか")]
    Vector3 errorRangePossession;

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

    [SerializeField, Header("HitodamaAnimator")]
    Animator soulAnimator;

    [SerializeField]
    bool isClearX = false;
    [SerializeField]
    bool isClearY = false;
    [SerializeField]
    bool isClearZ = false;
    

    // Start is called before the first frame update
    void Start()
    {
        isClear = false;
        clearPosition = new Vector3(0, 0, 0);

        soulAnimator.enabled = false;

        isClearX = false;
        isClearY = false;
        isClearZ = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (PossessionJudge() && SoulAngleJudge() && SoulMoveJudge())
        {
            isClear = true;
            lig.transform.parent = null;
            soulAnimator.enabled = true;
        }



        if (!isClear)
        {
            clearPosition = transform.position;
        }
        else
        {
            isClear = true;
            lig.transform.parent = null;
            soulAnimator.enabled = true;
            PossetionRotation();

            soul.GetComponent<MouseMove>().enabled = false;
        }
    }

    bool PossessionJudge()
    {
        var target = possession.transform.localEulerAngles;
        if (target.x > 180) target.x -= 360;
        if (target.y > 180) target.y -= 360;
        if (target.z > 180) target.z -= 360;
        

        if (Mathf.Abs(target.x - answerPossessionAngle.x) < errorRangePossession.x ||
            Mathf.Abs(possession.transform.localEulerAngles.x - answerPossessionAngle.x) < errorRangePossession.x)
        {
            isClearX = true;
        }
        else
        {
            isClearX = false;
        }
        if (Mathf.Abs(target.y - answerPossessionAngle.y) < errorRangePossession.y ||
            Mathf.Abs(possession.transform.localEulerAngles.y - answerPossessionAngle.y) < errorRangePossession.y)
        {
            isClearY = true;
        }
        else
        {
            isClearY = false;
        }
        if (Mathf.Abs(target.z - answerPossessionAngle.z) < errorRangePossession.z ||
            Mathf.Abs(possession.transform.localEulerAngles.z - answerPossessionAngle.z) < errorRangePossession.z)
        {
            isClearZ = true;
        }
        else
        {
            isClearZ = false;
        }

        if (isClearX && isClearY && isClearZ)
        {
            return true;
        }

        return false;
    }


    bool SoulAngleJudge()
    {
        if (Mathf.Abs(soul.transform.localEulerAngles.x - answerSoulAngleX) < errorRangeSoulAngleX)
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

    void PossetionRotation()
    {

        var target = Quaternion.Euler(answerPossessionAngle);


        var now_rot = possession.transform.rotation;

        if (Quaternion.Angle(now_rot, target) <= 1)
        {
            transform.rotation = target;
            return;
        }

        possession.transform.Rotate(
            new Vector3(
                Time.deltaTime * (target.x - now_rot.x) * 1000,
                Time.deltaTime * (target.y - now_rot.y) * 1000,
                Time.deltaTime * (target.z - now_rot.z) * 1000
                ));

    }
}
