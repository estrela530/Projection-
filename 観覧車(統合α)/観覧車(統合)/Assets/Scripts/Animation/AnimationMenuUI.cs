using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationMenuUI : MonoBehaviour
{
    [SerializeField, Header("CanvasのOnOffをするキー")]
    KeyCode setKey;

    [SerializeField]
    Animator animator;

    [SerializeField]
    string animatorParameters;

    bool animBool;

    private void Start()
    {
        animBool = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            Debug.Log("MenuUIに足りていないものがあります");
            return;
        }

        if (Input.GetKeyDown(setKey))
        {
            animator.SetBool(animatorParameters, !animator.GetBool(animatorParameters));
            animBool = animator.GetBool(animatorParameters);
        }
    }

    public bool GetAnimBool()
    {
        return animBool;
    }
}
