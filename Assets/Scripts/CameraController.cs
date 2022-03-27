using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    void Start()
    {
        Camera.main.transform.position = new Vector3(0f, 7.47f, -8.32f);
        offset = transform.position - target.position;

        Camera.main.transform.position = new Vector3(5.01f, 3.66f, -8.32f);
        Camera.main.transform.rotation = Quaternion.Euler(1f, -22.94f, 0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z);

        transform.position = Vector3.Lerp(transform.position, newPosition, 10 * Time.deltaTime);

        //Kendime not:
        ////////////// Kamerada bir problem olursa
        ////////////// newPosition kullan

    }
}
