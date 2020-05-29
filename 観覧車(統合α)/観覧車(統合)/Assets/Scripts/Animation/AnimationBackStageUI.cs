using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationBackStageUI : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    string animatorParameters;

    [SerializeField,Header("ステージセレクトシーンの名前")]
    string sceneName;

    private void Start()
    {
        sceneName = "StageSelect";
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            return;
        }
    }


    //ステージセレクトに戻らない
    public void BackCansel()
    {
        animator.SetBool(animatorParameters, false);
    }

    //ステージセレクトに戻る
    public void BackExecution()
    {
        SceneManager.LoadScene(sceneName);
    }
}
