using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse
{
    public Rigibody mainBigBox;
    private Transform objectTransform;
    private readonly float forwardSpeed = 1000.0f;
    private readonly float rotationSpeed = 5.0f;

    public void Init()
    {
        KinematicOff();
        gameObject.SetActive(true);
    }
    public void KinematicOff()
    {
        mainBigBox.isKinematic = true;
    }
    public void KinematicOn()
    {
        mainBigBox.isKinematic = false;
    }
    public float[] GetMouseXY()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
        float[] mouseXY = { mouseX, mouseY };
        return mouseXY;
    }
    public void RotateObject(float[] mouseXY)
    {
        objectTransform.rotation *= Quaternion.Euler(0, mouseXY[0] * -1, 0);
        objectTransform.rotation *= Quaternion.Euler(mouseXY[1] , 0, 0);
    }
    public void ObjectAddForce()
    {
        mainBigBox.AddForce(objectTransform.forward * forwardSpeed);

    }
    public void RigiObj()
    {
        KinematicOn();
        ObjectAddForce();
    }
    public void RotaObj()
    {
        RotateObject(GetMouseXY());
    }
    public void FollowMouse()
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
}

public class Logic : MonoBehaviour
{
    public Mouse Mouse = new Mouse();

    private void Start()
    {
        Mouse.Init();
    }

    private void Update()
    {
        Mouse.FollowMouse();
    }

}
