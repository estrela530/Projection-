using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHintUI : MonoBehaviour
{
    [SerializeField, Header("CanvasのOnOffをするキー")]
    KeyCode setKey;

    [SerializeField]
    Animator animator;

    [SerializeField]
    string animatorParameters;



    // Update is called once per frame
    void Update()
    {
        if (animator == null)
        {
            Debug.Log("HintUIに足りていないものがあります");
            return;
        }

        if (Input.GetKeyDown(setKey))
        {
            animator.SetBool(animatorParameters, !animator.GetBool(animatorParameters));
        }
    }
}
