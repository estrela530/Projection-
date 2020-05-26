using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationClearhitodama : MonoBehaviour
{
    [SerializeField]
    GameObject hitodamaObject;
    //GameObject hitodama;
    [SerializeField]
    Vector3 animationStartPosition;
    private bool isStart;
    [SerializeField]
    private Animator animator;
    const string animName = "AnimationClearhitodama";
    public Clear cl;

    [SerializeField]
    //Clear cl = GetComponent<Clear>();


    // Start is called before the first frame update
    void Start()
    {
        //hitodama = GameObject.Find("外周部");
        //animator = hitodamaObject.AddComponent<Animator>();
        animationStartPosition = new Vector3(0, 0, 0);
        isStart = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Clear cl = GetComponent<Clear>();

        if (cl.isClear == true)
        {
            animationStartPosition = cl.clearPosition;
            isStart = true;
        }

        if (isStart)
        {
            animator.SetBool(animName, true);

            //animator.transform.localPosition = animationStartPosition;
            //animator.Play(animName);

        }
    }
}
