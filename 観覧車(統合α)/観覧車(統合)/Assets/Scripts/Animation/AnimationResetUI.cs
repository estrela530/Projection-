using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationResetUI : MonoBehaviour
{
    [SerializeField, Header("CanvasのOnOffをするキー")]
    KeyCode setKey;

    [SerializeField]
    Animator animator;

    [SerializeField]
    string animatorParameters;

    
    string sceneName;
    

    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            return;
        }

        if (Input.GetKeyDown(setKey))
        {
            animator.SetBool(animatorParameters, !animator.GetBool(animatorParameters));
        }
    }


    //リセットのキャンセル
    public void ResetCansel()
    {
        animator.SetBool(animatorParameters, false);
    }

    //シーンのリセット
    public void ResetExecution()
    {
        sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
