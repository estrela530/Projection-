using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    [SerializeField] GameObject Shadow1;
    [SerializeField] GameObject Shadow2;
    [SerializeField] GameObject Shadow3;
    [SerializeField] GameObject Shadow4;
    [SerializeField] GameObject gai;//外周部
    [SerializeField] GameObject tyu;//中心部
    [SerializeField] ModeManager modeManager;
    [SerializeField] IgnitStatus ignitStatus;
    [SerializeField] int Oshadw1;
    [SerializeField] int Ishadw1;
    
    //[SerializeField] float ShadowSizeX;//影のサイズX
    //[SerializeField] float ShadowSizeY;//影のサイズY
    //[SerializeField] float ShadowSizeZ;//影のサイズZ
    //[SerializeField] int SizeMul;//倍する値
    //[SerializeField] int SizeDiv;//割る値
    //int a;//代用

    // Start is called before the first frame update
    void Start()
    {
        Shadow1.gameObject.SetActive(false);
        Shadow2.gameObject.SetActive(false);
        Shadow3.gameObject.SetActive(false);
        Shadow4.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       //着火時
        if (ignitStatus.GetIgnit())
        {
            //外1の時
            if (modeManager.NowInMode() == 1)
            {
                //内が
                switch (modeManager.NowOutMode())
                {
                    case 1:
                        Shadow1.gameObject.SetActive(true);
                        Shadow2.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;

                    case 2:
                        Shadow2.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                    case 3:
                        Shadow3.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow2.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                    case 4:
                        Shadow4.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow2.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        break;
                }
            }
            //内2の時
            if (modeManager.NowInMode() == 2)
            {
                //外が
                switch (modeManager.NowOutMode())
                {
                    case 1:
                        Shadow4.gameObject.SetActive(true);
                        Shadow3.gameObject.SetActive(false);
                        Shadow2.gameObject.SetActive(false);
                        Shadow1.gameObject.SetActive(false);
                        break;

                    case 2:
                        Shadow1.gameObject.SetActive(true);
                        Shadow2.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                    case 3:
                        Shadow2.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        break;
                    case 4:
                        Shadow3.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow2.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                }
            }
            //外3の時
            if (modeManager.NowInMode() == 3)
            {
                //内が
                switch (modeManager.NowOutMode())
                {
                    case 1:
                        Shadow3.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow2.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;

                    case 2:
                        Shadow4.gameObject.SetActive(true);
                        Shadow3.gameObject.SetActive(false);
                        Shadow2.gameObject.SetActive(false);
                        Shadow1.gameObject.SetActive(false);
                        break;
                    case 3:
                        Shadow1.gameObject.SetActive(true);
                        Shadow2.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                    case 4:
                        Shadow2.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                }
            }
            //外4の時
            if (modeManager.NowInMode() == 4)
            {
                //内が
                switch (modeManager.NowOutMode())
                {
                    case 1:
                        Shadow2.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        break;

                    case 2:
                        Shadow3.gameObject.SetActive(true);
                        Shadow1.gameObject.SetActive(false);
                        Shadow2.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                    case 3:
                        Shadow4.gameObject.SetActive(true);
                        Shadow2.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        Shadow1.gameObject.SetActive(false);
                        break;
                    case 4:
                        Shadow1.gameObject.SetActive(true);
                        Shadow2.gameObject.SetActive(false);
                        Shadow3.gameObject.SetActive(false);
                        Shadow4.gameObject.SetActive(false);
                        break;
                }
            }
        }
        else if(!ignitStatus.GetIgnit())
        {
            Shadow1.gameObject.SetActive(false);
            Shadow2.gameObject.SetActive(false);
            Shadow3.gameObject.SetActive(false);
            Shadow4.gameObject.SetActive(false);
        }
    }
}
