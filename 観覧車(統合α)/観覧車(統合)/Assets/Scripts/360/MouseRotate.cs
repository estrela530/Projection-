using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    string objectTag = "Block";

    [SerializeField]
    float RotationSpeed = 10;

    bool canMove = false;

    private void Start()
    {
        canMove = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RayCheck();
        }

        if (Input.GetMouseButtonUp(0))
        {
            canMove = false;
        }

        if (canMove)
        {
            OnRotate(new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")));
        }
    }


    //deltaはドラッグの方向を取得
    void OnRotate(Vector2 delta)
    {
        // 回転量はドラッグ方向ベクトルの長さに比例する
        float deltaAngle = delta.magnitude * RotationSpeed;

        // 回転量がほぼ0なら、回転軸を求められないので何もしない
        if (Mathf.Approximately(deltaAngle, 0.0f))
        {
            return;
        }

        // ドラッグ方向をワールド座標系に直す
        // 横ドラッグならカメラのright方向、縦ドラッグならup方向ということなので
        // deltaのx、yをright、upに掛けて、2つを合成すればいいはず...
        Transform cameraTransform = Camera.main.transform;
        Vector3 deltaWorld = cameraTransform.right * delta.x + cameraTransform.up * delta.y;

        // 回転軸はドラッグ方向とカメラforwardの外積の向き
        Vector3 axisWorld = Vector3.Cross(deltaWorld, cameraTransform.forward).normalized;

        // Rotateで回転する
        // 回転軸はワールド座標系に基づくので、回転もワールド座標系を使う
        transform.Rotate(axisWorld, deltaAngle, Space.World);
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
}