using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeManager : MonoBehaviour
{
    //true = out false = in
    [SerializeField]
    bool tOutFIn;

    [SerializeField]
    int outMode;

    [SerializeField]
    int inMode;

    //Right = 1  Left = 2
    int setRigLef;

    //クールタイム用時間
    [SerializeField]
    float seconds;

    // Start is called before the first frame update
    void Start()
    {
        tOutFIn = true;
        outMode = 1;
        inMode = 1;
        seconds = 500;
    }

    // Update is called once per frame
    void Update()
    {
        if (tOutFIn && seconds >= 2)
        {
            OutModeChange();
        }
        else if (!tOutFIn && seconds >= 2)
        {
            InModeChange();
        }
        seconds += Time.deltaTime * 100000;
    }

    void OutModeChange()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S))
        {
            switch (outMode)
            {
                case 1:
                    outMode = 2;
                    seconds = 0;
                    break;
                case 2:
                    outMode = 3;
                    seconds = 0;
                    break;
                case 3:
                    outMode = 4;
                    seconds = 0;
                    break;
                case 4:
                    outMode = 1;
                    seconds = 0;
                    break;
                default:
                    break;
            }
            setRigLef = 1;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W))
        {
            switch (outMode)
            {
                case 1:
                    outMode = 4;
                    seconds = 0;
                    break;
                case 2:
                    outMode = 1;
                    seconds = 0;
                    break;
                case 3:
                    outMode = 2;
                    seconds = 0;
                    break;
                case 4:
                    outMode = 3;
                    seconds = 0;
                    break;
                default:
                    break;
            }

            setRigLef = 2;
        }
    }

    void InModeChange()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.W))
        {
            switch (inMode)
            {
                case 1:
                    inMode = 2;
                    seconds = 0;
                    break;
                case 2:
                    inMode = 3;
                    seconds = 0;
                    break;
                case 3:
                    inMode = 4;
                    seconds = 0;
                    break;
                case 4:
                    inMode = 1;
                    seconds = 0;
                    break;
                default:
                    break;
            }
            setRigLef = 1;
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
        {
            switch (inMode)
            {
                case 1:
                    inMode = 4;
                    seconds = 0;
                    break;
                case 2:
                    inMode = 1;
                    seconds = 0;
                    break;
                case 3:
                    inMode = 2;
                    seconds = 0;
                    break;
                case 4:
                    inMode = 3;
                    seconds = 0;
                    break;
                default:
                    break;
            }

            setRigLef = 2;
        }
    }

    public int NowOutMode()
    {
        return outMode;
    }

    public int NowInMode()
    {
        return inMode;
    }

    public int GetRight1Left2()
    {
        return setRigLef;
    }

    public void ChangeInOut()
    {
        tOutFIn = !tOutFIn;
    }

    public bool GetFalseInTrueOut()
    {
        return tOutFIn;
    }
}
