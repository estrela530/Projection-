using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    [SerializeField,Header("着火状態でクリアの台座のリスト")]
    List<IgnitStatus> FirePedestals;
    [SerializeField, Header("使いづらいけど同じ順番で炎の大きさの設定")]
    List<int> FireSizeList;

    [SerializeField, Header("鎮火状態でクリアの台座のリスト")]
    List<IgnitStatus> ClearPedestals;

    //[SerializeField,Header("クリア関係のCanvas")]
    //GameObject ClearCanvas;

    [SerializeField, Header("モードマネージャー")]
    ModeManager modeManager;

    [SerializeField, Header("クリアが内が1の時の外との差分の数字(例:内1の外3がクリアの場合2を入れる)")]
    int clearNum;


    [SerializeField, Header("IgnitManager")]
    IgnitManager ignitManager;

    // Start is called before the first frame update
    void Start()
    {
        //ClearCanvas.SetActive(false);
        for (int i = 0; i < FireSizeList.Count; i++)
        {
            if (FireSizeList[i] > ignitManager.GetMaxSize())
            {
                FireSizeList[i] = ignitManager.GetMaxSize();
            }
            else if (FireSizeList[i] <= 0)
            {
                FireSizeList[i] = 1;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //着いてるべきところが着いているか
        for (int i = 0; i < FirePedestals.Count; i++)
        {
            if (!FirePedestals[i].GetIgnit() || FireSizeList[i] != FirePedestals[i].GetFireSize())
            {
                //ClearCanvas.SetActive(false);
                return;
            }
        }

        //消えてるべきところが消えてるか
        for (int i = 0; i < ClearPedestals.Count; i++)
        {
            if (ClearPedestals[i].GetIgnit())
            {
                //ClearCanvas.SetActive(false);
                return;
            }
        }

        //外のクリアの設定
        int clear = modeManager.NowInMode() + clearNum;
        if (clear > 4)
        {
            clear -= 4;
        }
        //内外のクリアの判定
        switch (modeManager.NowInMode())
        {
            case 1:
                if(modeManager.NowOutMode() != clear)
                {
                    //ClearCanvas.SetActive(false);
                    return;
                }
                break;
            case 2:
                if (modeManager.NowOutMode() != clear)
                {
                    //ClearCanvas.SetActive(false);
                    return;
                }
                break;
            case 3:
                if (modeManager.NowOutMode() != clear)
                {
                   //ClearCanvas.SetActive(false);
                    return;
                }
                break;
            case 4:
                if (modeManager.NowOutMode() != clear)
                {
                    //ClearCanvas.SetActive(false);
                    return;
                }
                break;
            default:
                break;
        }

        //ClearCanvas.SetActive(true);
        //SceneManager.LoadSceneAsync(nextSceneNum);
    }
}
