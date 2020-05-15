using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeManager : MonoBehaviour
{
    [SerializeField, Header("外周部の親オブジェクト")]
    OutRotate360 outRotate;
    [SerializeField, Header("中心部の親オブジェクト")]
    Rotate360 inRotate;

    [SerializeField]
    ModeManager modeManager;

    // Start is called before the first frame update
    void Start()
    {
        outRotate.enabled = true;
        inRotate.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //内外どっちを回すかの変更
        if (Input.GetKeyDown(KeyCode.Q))
        {
            modeManager.ChangeInOut();
            outRotate.enabled = !outRotate.enabled;
            inRotate.enabled = !inRotate.enabled;
        }
    }
}
