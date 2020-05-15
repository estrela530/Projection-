using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnitStatus : MonoBehaviour
{
    //着火鎮火
    bool ignit;
    
    //炎のサイズ 0:無 1:小 2:中 3:大
    int fireSize;

    //カーソルがあってるか
    bool cursol;
    
    // Start is called before the first frame update
    void Start()
    {
        ignit = false;
        fireSize = 0;
    }

    void Update()
    {
        if (fireSize > 0)
        {
            ignit = true;
        }
        else
        {
            ignit = false;
        }
    }
    

    public bool GetIgnit()
    {
        return ignit;
    }
    

    public void SetIgnit(bool ign)
    {
        ignit = ign;
    }

    /// <summary>
    /// 炎の大きさの獲得
    /// </summary>
    public int GetFireSize()
    {
        return fireSize;
    }

    /// <summary>
    /// 炎の大きさの設定
    /// </summary>
    /// <param name="setFire">0:消 1:小 2:中 3:大</param>
    public void SetFireSize(int setFire)
    {
        fireSize = setFire;
        if (fireSize < 0)
        {
            fireSize = 0;
        }
        else if (fireSize > 3)
        {
            fireSize = 3;
        }
    }

    /// <summary>
    /// 炎の大きさを大きくする
    /// </summary>
    public void PlusFireSize()
    {
        if (fireSize < 3)
        {
            fireSize++;
        }
    }

    /// <summary>
    /// 炎の大きさを小さくする
    /// </summary>
    public void MinusFireSize()
    {
        if (fireSize > 0)
        {
            fireSize--;
        }
    }

    /// <summary>
    /// カーソルがあってるかどうか
    /// </summary>
    /// <returns></returns>
    public bool GetCursol()
    {
        return cursol;
    }

    public void SetCursol(bool setCur)
    {
        cursol = setCur;
    }
}
