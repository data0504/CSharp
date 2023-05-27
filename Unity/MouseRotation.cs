using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    public Rigibody mainBigBox;
    private readonly float forwardSpeed = 1000.0f;
    private readonly float rotationSpeed = 5.0f;

    void Start()
    {
        mainBigBox.isKinematic = true;
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Down");
        }

        if (Input.GetMouseButton(0))
        {
            Debug.Log("Hold on");
            RotaObj();
        }

        if (Input.GetMouseButtonUp(0) )
        {
            Debug.Log("Up");
            RigiObj();
        }
    }

    private void RigiObj()
    {
        mainBigBox.isKinematic = false;
        mainBigBox.AddForce(transform.forward * forwardSpeed);
    }

    private void RotaObj()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation *= Quaternion.Euler(0, mouseX * -1, 0);

        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        transform.rotation *= Quaternion.Euler(mouseY, 0, 0);
    }
}
