using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    public GameObject fire1;
    public GameObject gai;//外側
    public GameObject tyu;//中心部
    [SerializeField] ModeManager modeManager;
    [SerializeField] int Osha1;//火のつく出現条件
    [SerializeField] int Osha2;//台座が直線上にある時の角度の数字を入れる
    [SerializeField] int Isha1;//火のつく出現条件
    [SerializeField] int Isha2;//台座が直線上にない時の角度の数字を入れる
    [SerializeField] int spd;//台座が直線上にない時の角度の数字を入れる
    [SerializeField] IgnitStatus ignitStatus;
    [SerializeField]
    Material flameMat;
    [SerializeField]
    Material normalMat;
    [SerializeField]
    OutCameraRotate outCameraRotate;//今後つかうかも
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Renderer>().material = normalMat;
    }

    // Update is called once per frame
    void Update()
    {
        if (modeManager == null)
        {
            return;
        }
        //火が付く条件
        if (modeManager.NowOutMode() == Osha1 && ignitStatus.GetIgnit() || modeManager.NowOutMode() == Osha2 && ignitStatus.GetIgnit())
        {
            //着火してる時に
            //外周部が0度の時   1
            //外周部が90度の時  2
            //外周部が180度の時 3
            //外周部が-90度の時 4
            if (modeManager.NowInMode() == Isha1 && ignitStatus.GetIgnit() || modeManager.NowInMode() == Isha2 && ignitStatus.GetIgnit())
            {

                GetComponent<Renderer>().material = flameMat;
                ignitStatus.SetIgnit(true);

            }


        }


    }
}
