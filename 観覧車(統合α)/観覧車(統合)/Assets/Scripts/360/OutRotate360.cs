using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutRotate360 : MonoBehaviour
{
    [SerializeField]
    ModeManager modeManager;

    int mode;

    int before_mode;
    [SerializeField]
    float target_rotate;

    [SerializeField]
    float speed = 50;

    // Start is called before the first frame update
    void Start()
    {
        target_rotate = 0;
        mode = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (modeManager == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.D))
        {
            TargetRotate(modeManager.GetRight1Left2());
        }
        else if (Input.GetKey(KeyCode.A))
        {
            TargetRotate(modeManager.GetRight1Left2());
        }
        ChangeRotate();
    }

    void TargetRotate(int RigLef)
    {
        if (RigLef == 1)
        {
            target_rotate += Time.deltaTime * speed;
        }
        else if (RigLef == 2)
        {
            target_rotate -= Time.deltaTime * speed;
        }
    }



    void ChangeRotate()
    {

        var target = Quaternion.Euler(new Vector3(target_rotate, 0, 90));

        var now_rot = transform.rotation;
        if (Quaternion.Angle(now_rot, target) <= 1)
        {
            transform.rotation = target;
        }
        else if (modeManager.GetRight1Left2() == 1)
        {
            transform.Rotate(new Vector3(0, -Time.deltaTime * speed, 0));
        }
        else if (modeManager.GetRight1Left2() == 2)
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * speed, 0));
        }
    }
}
