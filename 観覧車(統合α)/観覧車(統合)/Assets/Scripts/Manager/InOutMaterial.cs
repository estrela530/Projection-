using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InOutMaterial : MonoBehaviour
{
    [SerializeField]
    Transform outParent;

    [SerializeField]
    Transform inParent;

    [SerializeField]
    ModeManager modeManager;

    [SerializeField]
    Material operateMat;

    [SerializeField]
    Material notOperateMat;


    // Update is called once per frame
    void Update()
    {
        //動かす側のマテリアルを赤く
        //動かさない側のマテリアルを青く

        //現在の回すのが外側
        if (modeManager.GetFalseInTrueOut())
        {
            outParent.gameObject.GetComponent<Renderer>().material = operateMat;

            foreach (Transform child in inParent)
            {
                child.gameObject.GetComponent<Renderer>().material = notOperateMat;
            }
        }//現在の回すのが内側
        else if (!modeManager.GetFalseInTrueOut())
        {
            foreach (Transform child in inParent)
            {
                child.gameObject.GetComponent<Renderer>().material = operateMat;
            }

            outParent.gameObject.GetComponent<Renderer>().material = notOperateMat;
        }
    }
}
