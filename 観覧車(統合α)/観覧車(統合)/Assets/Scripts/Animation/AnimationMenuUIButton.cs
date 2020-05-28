using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenuUIButton : MonoBehaviour
{
    [SerializeField, Header("ResetCanvas")]
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


        if (!resetAnimator.GetBool(resetAnimatorParameters) && !titleAnimator.GetBool(titleAnimatorParameters) && !hintAnimator.GetBool(hintAnimatorParameters) && anim != null)
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
        Debug.Log("Hintボタン押されたよ");

        switch (hintAnimator.GetBool(hintAnimatorParameters))
        {
            case true:
                hintAnimator.SetBool(hintAnimatorParameters, false);
                break;
            case false:
                hintAnimator.SetBool(hintAnimatorParameters, true);
                break;
        }

        //if (hintAnimator.GetBool(hintAnimatorParameters) == true)
        //{
        //    hint = 0;
        //}
        //else if (hintAnimator.GetBool(hintAnimatorParameters) == false)
        //{
        //    hint = 1;
        //}

        //switch (hint)
        //{
        //    case 0:
        //        hintAnimator.SetBool(hintAnimatorParameters, false);
        //        break;
        //    case 1:
        //        hintAnimator.SetBool(hintAnimatorParameters, true);
        //        break;
        //}

        //if (hintAnimator.GetBool(hintAnimatorParameters) == true)
        //{
        //    hintAnimator.SetBool(hintAnimatorParameters, false);
        //}

        //if (hintAnimator.GetBool(hintAnimatorParameters) == false)
        //{
        //    hintAnimator.SetBool(hintAnimatorParameters, true);
        //}

        //IsAnim = false;

        if (anim != null)
        {
            anim.enabled = false;
        }
    }
}




