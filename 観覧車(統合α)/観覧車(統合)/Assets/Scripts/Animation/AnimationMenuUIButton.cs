using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenuUIButton : MonoBehaviour
{
    [SerializeField, Header("ResetCanvas")]
    Animator resetAnimator;

    [SerializeField, Header("BackStageCanvas")]
    Animator backStageAnimator;

    [SerializeField, Header("TitleCanvas")]
    Animator titleAnimator;

    [SerializeField, Header("HintCanvas")]
    Animator hintAnimator;

    [SerializeField]
    string resetAnimatorParameters;

    [SerializeField]
    string backStageAnimatorParameters;

    [SerializeField]
    string titleAnimatorParameters;

    [SerializeField]
    string hintOpenAnimatorParameters;

    [SerializeField]
    string hintAnimatorParameters;


    [SerializeField]
    Clear clear;

    [SerializeField]
    AnimationMenuUI anim;

    bool IsAnim = false;
    int hint = 0;

    // Update is called once per frame
    void Update()
    {
        if (resetAnimator == null || titleAnimator == null || hintAnimator == null)
        {
            Debug.Log("MenuUIButtonに足りていないものがあります");
            return;
        }
        

        if (!anim.GetAnimBool())
        {
            resetAnimator.SetBool(resetAnimatorParameters, false);
            backStageAnimator.SetBool(resetAnimatorParameters, false);
            titleAnimator.SetBool(titleAnimatorParameters, false);
            hintAnimator.SetBool(hintAnimatorParameters, false);
        }

        if (clear.GetClearFlag())
        {
            anim.enabled = false;
        }
    }


    public void BackStageButtonDown()
    {
        backStageAnimator.SetBool(backStageAnimatorParameters, true);
    }


    public void ResetButtonDown()
    {
        resetAnimator.SetBool(resetAnimatorParameters, true);
    }


    public void TitleButtonDown()
    {
        titleAnimator.SetBool(titleAnimatorParameters, true);
    }

    public void HintButtonDown()
    {
        switch (hintAnimator.GetBool(hintAnimatorParameters))
        {
            case true:
                hintAnimator.SetBool(hintAnimatorParameters, false);
                break;
            case false:
                hintAnimator.SetBool(hintAnimatorParameters, true);
                break;
        }
    }
}




