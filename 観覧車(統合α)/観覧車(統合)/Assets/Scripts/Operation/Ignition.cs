using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ignition : MonoBehaviour
{
    IgnitStatus status;
    [SerializeField, Header("中サイズの炎のマテリアル")]
    Material fireMat;
    [SerializeField]
    Material normalMat;

    [SerializeField, Header("小サイズの炎のマテリアル")]
    Material smallFireMat;
    [SerializeField, Header("大サイズの炎のマテリアル")]
    Material bigFireMat;

    [SerializeField, Header("炎のパーティクル")]
    GameObject fireParticle;
    [SerializeField, Header("小炎のパーティクル")]
    GameObject smallFireParticle;
    [SerializeField, Header("大炎のパーティクル")]
    GameObject bigFireParticle;


    [SerializeField, Header("カーソル選択時のマテリアル")]
    Material cursolMat;

    private void Start()
    {
        status = gameObject.GetComponent<IgnitStatus>();
    }

    // Update is called once per frame  
    void Update()
    {

        //着火状態小炎
        if (status.GetIgnit() && status.GetFireSize() == 1)
        {
            GetComponent<Renderer>().material = smallFireMat;
            if (!smallFireParticle.GetComponentInChildren<ParticleSystem>().isEmitting)
            {
                smallFireParticle.GetComponentInChildren<ParticleSystem>().Play();
                fireParticle.GetComponentInChildren<ParticleSystem>().Stop();
                bigFireParticle.GetComponentInChildren<ParticleSystem>().Stop();
            }

        }//中炎
        else if (status.GetIgnit() && status.GetFireSize() == 2)
        {
            GetComponent<Renderer>().material = fireMat;
            if (!fireParticle.GetComponentInChildren<ParticleSystem>().isEmitting)
            {
                fireParticle.GetComponentInChildren<ParticleSystem>().Play();
                smallFireParticle.GetComponentInChildren<ParticleSystem>().Stop();
                bigFireParticle.GetComponentInChildren<ParticleSystem>().Stop();
            }

        }//大炎
        else if (status.GetIgnit() && status.GetFireSize() == 3)
        {
            GetComponent<Renderer>().material = bigFireMat;
            if (!bigFireParticle.GetComponentInChildren<ParticleSystem>().isEmitting)
            {
                bigFireParticle.GetComponentInChildren<ParticleSystem>().Play();
                fireParticle.GetComponentInChildren<ParticleSystem>().Stop();
                smallFireParticle.GetComponentInChildren<ParticleSystem>().Stop();
            }

        }
        //鎮火状態
        else
        {
            GetComponent<Renderer>().material = normalMat;
            fireParticle.GetComponentInChildren<ParticleSystem>().Stop();
            smallFireParticle.GetComponentInChildren<ParticleSystem>().Stop();
            bigFireParticle.GetComponentInChildren<ParticleSystem>().Stop();
        }

        //カーソルあってるとき
        if (status.GetCursol())
        {
            GetComponent<Renderer>().material.color += cursolMat.color;
            status.SetCursol(false);
        }
    }
}
