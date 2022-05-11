using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6f;

    [SerializeField]
    private Camera mainCamera;


    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            transform.position = new Vector3(
                transform.position.x, 
                transform.position.y + moveSpeed * Time.deltaTime, 
                transform.position.z);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.position = new Vector3(
                transform.position.x, 
                transform.position.y - moveSpeed * Time.deltaTime, 
                transform.position.z);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = new Vector3(
                transform.position.x + moveSpeed * Time.deltaTime, 
                transform.position.y, 
                transform.position.z);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position = new Vector3(
                transform.position.x - moveSpeed * Time.deltaTime, 
                transform.position.y, 
                transform.position.z);
        }

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;
        transform.up = direction;
    }
}
