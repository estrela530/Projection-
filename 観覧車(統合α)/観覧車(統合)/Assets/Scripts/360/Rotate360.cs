using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate360 : MonoBehaviour
{
    [SerializeField]
    ModeManager modeManager;
    
    [SerializeField]
    float target_rotateY;
    [SerializeField]
    float target_rotateX;

    [SerializeField]
    float speed = 120;

    // Start is called before the first frame update
    void Start()
    {
        target_rotateY = 0;
        target_rotateX = 0;
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
            TargetRotateY(modeManager.GetRight1Left2());
        }
        else if (Input.GetKey(KeyCode.A))
        {
            TargetRotateY(modeManager.GetRight1Left2());
        }

        if (Input.GetKey(KeyCode.W))
        {
            TargetRotateX(modeManager.GetRight1Left2());
        }
        else if (Input.GetKey(KeyCode.S))
        {
            TargetRotateX(modeManager.GetRight1Left2());
        }
        ChangeRotation();
    }

    void TargetRotateY(int RigLef)
    {
        if (RigLef == 1)
        {
            target_rotateY += Time.deltaTime * speed;
        }
        else if (RigLef == 2)
        {
            target_rotateY -= Time.deltaTime * speed;
        }
    }

    void TargetRotateX(int RigLef)
    {
        if (RigLef == 1)
        {
            target_rotateX += Time.deltaTime * speed;
        }
        else if (RigLef == 2)
        {
            target_rotateX -= Time.deltaTime * speed;
        }
    }
    
    void ChangeRotation()
    {
        var target = Quaternion.Euler(new Vector3(target_rotateX, target_rotateY, 90));


        var now_rot = transform.rotation;
        if (Quaternion.Angle(now_rot, target) <= 1)
        {
            transform.rotation = target;
        }
        else
        {
            transform.rotation =
                Quaternion.Slerp
                (transform.rotation, target, 0.1f);
        }
    }
}
