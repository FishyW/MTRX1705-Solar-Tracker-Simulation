using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class Controller : MonoBehaviour
{
    public float trackerRotateAmount;
    public float sunRotateAmount;

    public Transform sunObject;
    public Transform sunIndicatorObject;
    public Transform trackerObject;

    public TMP_InputField inputFieldSunX;
    public TMP_InputField inputFieldSunY;
    public TMP_InputField inputFieldTrackerX;
    public TMP_InputField inputFieldTrackerY;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {   
            sunObject.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            sunIndicatorObject.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            trackerObject.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        float xRotation = 0;
        float zRotation = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            xRotation += trackerRotateAmount;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            zRotation -= trackerRotateAmount;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            xRotation -= trackerRotateAmount;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            zRotation += trackerRotateAmount;
        }

        trackerObject.Rotate(new Vector3(xRotation, 0, zRotation) * Time.deltaTime);


        xRotation = 0;
        zRotation = 0;

        if (Input.GetKey(KeyCode.D))
        {
            xRotation += trackerRotateAmount;
        }
        if (Input.GetKey(KeyCode.W))
        {
            zRotation += trackerRotateAmount;
        }
        if (Input.GetKey(KeyCode.A))
        {
            xRotation -= trackerRotateAmount;
        }
        if (Input.GetKey(KeyCode.S))
        {
            zRotation -= trackerRotateAmount;
        }

        sunObject.Rotate(new Vector3(xRotation, 0, zRotation) * Time.deltaTime);
        sunIndicatorObject.Rotate(new Vector3(xRotation, 0, zRotation) * Time.deltaTime);

        if (!inputFieldSunX.isFocused)
        {
            inputFieldSunX.text = Mathf.DeltaAngle(0f, sunObject.rotation.eulerAngles.x).ToString("0.00");
        }
        if (!inputFieldSunY.isFocused)
        {
            inputFieldSunY.text = Mathf.DeltaAngle(0f, sunObject.rotation.eulerAngles.z).ToString("0.00");
        }

        if (!inputFieldTrackerX.isFocused)
        {
            inputFieldTrackerX.text = Mathf.DeltaAngle(0f, trackerObject.rotation.eulerAngles.x).ToString("0.00");
        }

        if (!inputFieldTrackerY.isFocused)
        {
            inputFieldTrackerY.text = Mathf.DeltaAngle(0f, trackerObject.rotation.eulerAngles.z).ToString("0.00");
        }
    }
    
    public void onInputDeselect()
    {
        float sunRotationX = float.Parse(inputFieldSunX.text);
        float sunRotationZ = float.Parse(inputFieldSunY.text);

        float trackerRotationX = float.Parse(inputFieldTrackerX.text);
        float trackerRotationZ = float.Parse(inputFieldTrackerY.text);

        sunObject.rotation = Quaternion.Euler(new Vector3(sunRotationX, 0, sunRotationZ));
        sunIndicatorObject.rotation = Quaternion.Euler(new Vector3(sunRotationX, 0, sunRotationZ));

        trackerObject.rotation = Quaternion.Euler(new Vector3(trackerRotationX, 0, trackerRotationZ));

    }
}


