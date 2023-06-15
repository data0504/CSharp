using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousecData
{
    private Rigidbody mainBigBox;
    private Transform mainTransform;
    private readonly float forwardSpeed = 1000.0f;
    private readonly float rotationSpeed = 5.0f;

    public void Init(Rigidbody main
                    , Transform objectTransform
                        , GameObject gameObject)
    {
        gameObject.SetActive(true);
        mainTransform = objectTransform;
        mainBigBox = main;
        KinematicOff();
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
        mainTransform.rotation *= Quaternion.Euler(0, mouseXY[0] * -1, 0);
        mainTransform.rotation *= Quaternion.Euler(mouseXY[1], 0, 0);
    }
    public void ObjectAddForce()
    {
        mainBigBox.AddForce(mainTransform.forward * forwardSpeed);

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

        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Up");
            RigiObj();
        }
    }
}

public class Mousec : MonoBehaviour
{
    public MousecData mousecData = new();
    public Rigidbody mainBigBox;

    void Start()
    {
        mousecData.Init(mainBigBox
                    , GetComponent<Transform>()
                        , gameObject);
    }

    void Update()
    {
        mousecData.FollowMouse();
    }
}
