using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Camera mainCamera;

    [Range(0f, 1f)]
    public float leanToMousePercentage = 0.1f;

    [Range (5f, 15f)]
    public float maxCameraDistance = 7f;


    private void Start()
    {
        transform.position = new Vector3(
            target.position.x,
            target.position.y,
            transform.position.z);
    }

    private void Update()
    {
        Vector3 mouse = mainCamera.ScreenToWorldPoint(
            new Vector3(
                Input.mousePosition.x, 
                Input.mousePosition.y, 
                target.position.z));

        Vector3 newPos = new Vector3(
            Mathf.Lerp(target.transform.position.x, mouse.x, leanToMousePercentage),
            Mathf.Lerp(target.transform.position.y, mouse.y, leanToMousePercentage),
            mouse.z);

        if ((target.transform.position - newPos).magnitude > maxCameraDistance)
        {
            return;
        }

        transform.position = newPos;
    }

}
