using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow360 : MonoBehaviour
{
    [SerializeField]
    Transform intrans;

    [SerializeField]
    GameObject sha;
    [SerializeField]
    List<GameObject> shadow;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sha.transform.rotation = 
            Quaternion.Slerp(transform.rotation, intrans.rotation, 0.1f);
        //foreach (var item in shadow)
        //{
        //    item.transform.position =
        //        new Vector3(
        //            item.transform.position.x,
        //            (intrans.localRotation.x * intrans.localRotation.x) * 30,
        //            item.transform.position.z);
        //}
    }
}
