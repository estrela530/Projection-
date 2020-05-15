using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationClearUI : MonoBehaviour
{
    [SerializeField]
    Animator animator;

    [SerializeField]
    string animatorParameters;

    [SerializeField,Header("次のシーンのシーン番号")]
    int nextScene;

    [SerializeField, Header("タイトルシーンのシーン番号")]
    int titleScene = 0;

    [SerializeField, Header("ステージ選択のシーン番号")]
    int stageScene = 1;


    [SerializeField]
    Clear clear;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clear.GetClearFlag())
        {
            animator.SetBool(animatorParameters, true);
        }
    }


    public void NextClick()
    {
        SceneManager.LoadScene(nextScene);
    }


    public void ResetClick()
    {
        string nowScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(nowScene);
    }

    public void TitleClick()
    {
        SceneManager.LoadScene(titleScene);
    }

    public void StageClick()
    {
        SceneManager.LoadScene(stageScene);
    }
}
