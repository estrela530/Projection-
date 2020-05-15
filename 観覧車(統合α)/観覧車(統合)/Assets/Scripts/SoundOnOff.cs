using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnOff : MonoBehaviour
{
    [SerializeField, Header("ここをTRUEにするとfire1にのみ入ってたらいいよ")]
    bool flag;

    [SerializeField, Header("小の音声")]
    AudioClip fire1;
    [SerializeField, Header("中の音声")]
    AudioClip fire2;
    [SerializeField, Header("大の音声")]
    AudioClip fire3;

    [SerializeField, Header("消火の音声")]
    AudioClip stopFire;

    AudioSource audioSource;
    IgnitStatus ignitStatus;

    int changeStateFire;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = fire1;
        ignitStatus = gameObject.GetComponent<IgnitStatus>();
        changeStateFire = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            return;
        }


        if (changeStateFire != ignitStatus.GetFireSize())
        {
            switch (ignitStatus.GetFireSize())
            {
                case 0:
                    audioSource.Stop();
                    audioSource.clip = stopFire;
                    audioSource.PlayOneShot(stopFire, 1);
                    break;
                case 1:
                    if (audioSource.clip != fire1)
                    {
                        audioSource.Stop();
                    }
                    audioSource.clip = fire1;
                    break;
                case 2:
                    if (audioSource.clip != fire2)
                    {
                        audioSource.Stop();
                    }
                    audioSource.clip = fire2;
                    break;
                case 3:
                    if (audioSource.clip != fire3)
                    {
                        audioSource.Stop();
                    }
                    audioSource.clip = fire3;
                    break;
                default:
                    break;
            }

            changeStateFire = ignitStatus.GetFireSize();
        }
        if (ignitStatus.GetIgnit() && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

    }
}
