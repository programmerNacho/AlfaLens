using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderMovement : MonoBehaviour
{
    [SerializeField]
    private float distanceFromCamera = 1f;
    [SerializeField]
    private float smoothTime = 5f;

    private Camera mainCamera;
    private bool canMove;

    private Vector3 positionBeforeMoving;

    public bool CanMove
    {
        get
        {
            return canMove;
        }

        set
        {
            canMove = value;
            if(canMove)
            {
                positionBeforeMoving = transform.position;
            }
            else
            {
                transform.position = positionBeforeMoving;
            }
        }
    }

    private void Start()
    {
        mainCamera = Camera.main;
        canMove = false;
    }

    private void Update()
    {
        if(canMove)
        {
            Ray cameraRay = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, mainCamera.transform.position.z));
            Vector3 position = cameraRay.GetPoint(distanceFromCamera);
            transform.position = Vector3.Lerp(transform.position, position, smoothTime * Time.deltaTime);
        }
    }
}
