using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6f;

    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private GameObject _projectile;

    [SerializeField]
    private GameObject _enemy;


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

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_projectile, transform.position, transform.rotation);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(_enemy, 
                new Vector3(
                    mousePos.x,
                    mousePos.y,
                    transform.position.z), 
                Quaternion.identity);
        }

        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - (Vector2)transform.position).normalized;
        transform.up = direction;
    }
}
