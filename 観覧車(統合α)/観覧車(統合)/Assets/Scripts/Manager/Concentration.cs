using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Concentration : MonoBehaviour
{
    [SerializeField, Header("酸素濃度の限界値")]
    int maxConcentration;

    //現在の酸素濃度
    [SerializeField]
    float nowConcentration;

    //一度に変化する量
    [SerializeField]
    float concent;

    [SerializeField, Header("酸素濃度ゲージのImageオブジェクト")]
    Image concentrationImage;

    private void Start()
    {
        nowConcentration = 1;
        concent = 1 / (float)maxConcentration;
    }

    // Update is called once per frame
    void Update()
    {
        concentrationImage.fillAmount = nowConcentration;

        if (nowConcentration > 1)
        {
            nowConcentration = 1;
        }
        else if (nowConcentration <= 0.0001)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


    public void MinusConcentration()
    {
        nowConcentration -= concent;
    }

    public void PlusConcentration()
    {
        nowConcentration += concent;
    }

    float GetNowConcentration()
    {
        return nowConcentration;
    }
}
