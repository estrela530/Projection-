using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowScale : MonoBehaviour
{
    Shadow sha;
    [SerializeField, Header("台座を入れる")] IgnitStatus IgnS;
    [SerializeField,Header("影1を入れる")] GameObject Shadow1;
    [SerializeField,Header("影2を入れる")] GameObject Shadow2;
    [SerializeField,Header("影3を入れる")] GameObject Shadow3;
    [SerializeField,Header("影4を入れる")] GameObject Shadow4;
    [SerializeField,Header("中間のサイズX")] float ShadowSizeX;//影のサイズX
    [SerializeField,Header("中間のサイズY")] float ShadowSizeY;//影のサイズY
    [SerializeField,Header("中間のサイズZ")] float ShadowSizeZ;//影のサイズZ
    [SerializeField,Header("倍する数")] float SizeMul;//倍する値
    [SerializeField,Header("割る数")] float SizeDiv;//割る値
  
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        ShaScale();
    }

    void ShaScale()
    {
        //Shadow1が出現中
        if (Shadow1)
        {
            switch(IgnS.GetFireSize())
            {
                //小さく
                case 1:
                    Shadow1.transform.localScale = new Vector3(ShadowSizeX / SizeDiv, ShadowSizeY / SizeDiv, ShadowSizeZ / SizeDiv);
                    break;
                //標準
                case 2:
                    Shadow1.transform.localScale = new Vector3(ShadowSizeX, ShadowSizeY, ShadowSizeZ);
                    break;
                //倍
                case 3:
                    Shadow1.transform.localScale = new Vector3(ShadowSizeX * SizeMul, ShadowSizeY * SizeMul, ShadowSizeZ * SizeMul);
                    break;
            }
           
        }
        //Shadow2が出現中
        if (Shadow2)
        {
            switch (IgnS.GetFireSize())
            {
                //小さく
                case 1:
                    Shadow2.transform.localScale = new Vector3(ShadowSizeX / SizeDiv, ShadowSizeY / SizeDiv, ShadowSizeZ / SizeDiv);
                    break;
                //標準
                case 2:
                    Shadow2.transform.localScale = new Vector3(ShadowSizeX, ShadowSizeY, ShadowSizeZ);
                    break;
                //倍
                case 3:
                    Shadow2.transform.localScale = new Vector3(ShadowSizeX * SizeMul, ShadowSizeY * SizeMul, ShadowSizeZ * SizeMul);
                    break;
            }
        }
        //Shadow3が出現中
        if (Shadow3)
        {
            switch (IgnS.GetFireSize())
            {
                //小さく
                case 1:
                    Shadow3.transform.localScale = new Vector3(ShadowSizeX / SizeDiv, ShadowSizeY / SizeDiv, ShadowSizeZ / SizeDiv);
                    break;
                //標準
                case 2:
                    Shadow3.transform.localScale = new Vector3(ShadowSizeX, ShadowSizeY, ShadowSizeZ);
                    break;
                //倍
                case 3:
                    Shadow3.transform.localScale = new Vector3(ShadowSizeX * SizeMul, ShadowSizeY * SizeMul, ShadowSizeZ * SizeMul);
                    break;
            }
        }
        //Shadow4が出現中
        if (Shadow4)
        {
            switch (IgnS.GetFireSize())
            {
                //小さく
                case 1:
                    Shadow4.transform.localScale = new Vector3(ShadowSizeX / SizeDiv, ShadowSizeY / SizeDiv, ShadowSizeZ / SizeDiv);
                    break;
                //標準
                case 2:
                    Shadow4.transform.localScale = new Vector3(ShadowSizeX, ShadowSizeY, ShadowSizeZ);
                    break;
                //倍
                case 3:
                    Shadow4.transform.localScale = new Vector3(ShadowSizeX * SizeMul, ShadowSizeY * SizeMul, ShadowSizeZ * SizeMul);
                    break;
            }
        }
    }
}
