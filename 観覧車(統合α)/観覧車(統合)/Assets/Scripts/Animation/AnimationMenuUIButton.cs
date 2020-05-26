using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenuUIButton : MonoBehaviour
{
    [SerializeField,Header("ResetCanvas")]
    Animator resetAnimator;

    [SerializeField, Header("TitleCanvas")]
    Animator titleAnimator;

    [SerializeField, Header("HintCanvas")]
    Animator hintAnimator;

    [SerializeField]
    string resetAnimatorParameters;

    [SerializeField]
    string titleAnimatorParameters;

    [SerializeField]
    string hintAnimatorParameters;

    [SerializeField]
    Clear clear;

    [SerializeField]
    AnimationMenuUI anim;

    // Update is called once per frame
    void Update()
    {
        if (resetAnimator == null || titleAnimator == null || hintAnimator == null)
        {
            Debug.Log("MenuUIButtonに足りていないものがあります");
            return;
        }


        if (!resetAnimator.GetBool(resetAnimatorParameters) && !titleAnimator.GetBool(titleAnimatorParameters) && !hintAnimator.GetBool(hintAnimatorParameters)&& anim != null)
        {
            anim.enabled = true;
        }

        if (clear.GetClearFlag())
        {
            anim.enabled = false;
        }
    }



    public void ResetButtonDown()
    {
        resetAnimator.SetBool(resetAnimatorParameters, true);


        if (anim != null)
        {
            anim.enabled = false;
        }
    }


    public void TitleButtonDown()
    {
        titleAnimator.SetBool(titleAnimatorParameters, true);


        if (anim != null)
        {
            anim.enabled = false;
        }
    }

    public void HintButtonDown()
    {
        hintAnimator.SetBool(hintAnimatorParameters, true);


        if (anim != null)
        {
            anim.enabled = false;
        }
    }
}




