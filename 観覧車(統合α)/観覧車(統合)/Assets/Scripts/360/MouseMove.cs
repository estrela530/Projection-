using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
    string objectTag = "Soul";

    [SerializeField]
    float MoveSpeed = 10;

    bool canMove = false;

    float PosX;

    //近い方が減る x
    [SerializeField]
    GameObject nearBlock;

    //遠い方が増える x
    [SerializeField]
    GameObject farBlock;

    [SerializeField]
    Light soulLight;

    float noise;

    [SerializeField, Header("遠いところでのLightのRangeの値")]
    float maxRange = 160;
    [SerializeField, Header("遠いところでのLightのAngleの値")]
    float maxAngle = 136;
    [SerializeField, Header("近いところでのLightのRangeの値")]
    float minRange = 135;
    [SerializeField, Header("近いところでのLightのAngleの値")]
    float minAngle = 35;

    //最近と最遠のX座標の距離の差
    float farNearDistance;

    //LightのRangeの値
    float rangeDistance;
    float rangePercent;

    //LightのAngleの値
    float angleDistance;
    float anglePercent;

    private void Start()
    {
        canMove = false;
        PosX = transform.position.x;

        farNearDistance = farBlock.transform.position.x - nearBlock.transform.position.x;

        rangeDistance = maxRange - minRange;
        rangePercent = rangeDistance / 100;

        angleDistance = maxAngle - minAngle;
        anglePercent = angleDistance / 100;

        SetLightRangeAngle();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RayCheck();
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }

        if (canMove)
        {
            Move();
        }

        SetLightRangeAngle();

    }


    private void Move()
    {
        float mouseAxis = Input.GetAxis("Mouse X");
        float mouse_move_x = mouseAxis * MoveSpeed;

        PosX += mouse_move_x;
        transform.position = new Vector3(PosX, transform.position.y, transform.position.z);

        if (transform.position.x < nearBlock.transform.position.x)
        {
            transform.position = new Vector3(nearBlock.transform.position.x, transform.position.y, transform.position.z);
            PosX = transform.position.x;
            return;
        }
        else if (transform.position.x > farBlock.transform.position.x)
        {
            transform.position = new Vector3(farBlock.transform.position.x, transform.position.y, transform.position.z);
            PosX = transform.position.x;
            return;
        }
    }

    void RayCheck()
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
        {
            GameObject obj = hit.collider.gameObject;
            if (obj.transform.tag == objectTag)
            {
                canMove = true;
            }
        }
    }


    void SetLightRangeAngle()
    {
        float percent = GetPercent();
        noise = (Mathf.PerlinNoise(Time.time * 1.2f, 0) - 0.5f) * 20;

        soulLight.range = rangePercent * percent + minRange;
        soulLight.spotAngle = anglePercent * percent + minAngle + noise;
    }


    float GetPercent()
    {
        float percent;

        //どれぐらいの位置にいるか
        float progress = transform.position.x - nearBlock.transform.position.x;

        //何パーセントか
        percent = progress / farNearDistance * 100;

        return percent;
    }
}