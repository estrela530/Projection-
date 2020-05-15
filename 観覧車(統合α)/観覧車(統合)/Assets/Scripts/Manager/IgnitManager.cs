using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnitManager : MonoBehaviour
{
    string ignitTag = "Pedestal";

    [SerializeField,Header("カーソルがあった時のマテリアル")]
    Material cursolMat;

    [SerializeField, Header("ConcentrationManager")]
    Concentration concent;

    [SerializeField, Header("このステージでの炎の最大サイズ")]
    int MaxFireSize = 3;

    private void Start()
    {
        if (MaxFireSize > 3)
        {
            MaxFireSize = 3;
        }
        else if (MaxFireSize < 1)
        {
            MaxFireSize = 1;
        }
    }

    // Update is called once per frame  
    void Update()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            GameObject obj = hit.collider.gameObject;

            
            if (obj.CompareTag(ignitTag))
            {
                IgnitStatus status = obj.GetComponent<IgnitStatus>();
                status.SetCursol(true);

                if (Input.GetMouseButtonDown(0) && status.GetFireSize() < MaxFireSize)
                {
                    status.PlusFireSize();
                    concent.MinusConcentration();
                }
                else if (Input.GetMouseButtonDown(1) && status.GetFireSize() != 0)
                {
                    status.MinusFireSize();
                    concent.PlusConcentration();
                }
                else if (Input.GetMouseButtonDown(2))
                {
                    for (int i = 0; i < status.GetFireSize(); i++)
                    {
                        concent.PlusConcentration();
                    }
                    status.SetFireSize(0);
                }
            }

            
        }
    }

    public int GetMaxSize()
    {
        return MaxFireSize;
    }
}