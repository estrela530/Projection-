using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationGoTitleUI : MonoBehaviour
{

    [SerializeField]
    Animator animator;

    [SerializeField]
    string animatorParameters;


    string sceneName;

    private void Start()
    {
        sceneName = "タイトルAnim";
    }

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            return;
        }
    }


    //タイトルに戻らない
    public void TitleCansel()
    {
        animator.SetBool(animatorParameters, false);
    }

    //タイトルに戻る
    public void TitleExecution()
    {
        SceneManager.LoadScene(sceneName);
    }
}
