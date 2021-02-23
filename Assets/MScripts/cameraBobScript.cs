using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBobScript : MonoBehaviour
{

    [Header("Transform reference")]
    public Transform headTransform;
    public Transform cameraTransform;
    [Header("Head blobing")]
    public float bobFrequency = 5f;
    public float bobHorizontalAmplitude = 0.1f;
    public float bobVerticallAmplitude = 0.1f;
    [Range(0, 1)] public float headBlobSmoothing = 0.1f;

    public bool isWalking;
    private float wlakingTime=0;
    private Vector3 tragetCameraPosition;

    public Vector3 CalculateHeadBobOffset(float t)
    {
        float horizontalOffset = 0;
        float verticalOffset = 0;
        Vector3 offset = Vector3.zero;
        
        if (t > 0)
        {
            horizontalOffset = Mathf.Cos(t * bobFrequency) * bobHorizontalAmplitude;
            verticalOffset = Mathf.Sin(t * bobFrequency * 2) * bobVerticallAmplitude;

            offset = headTransform.right * horizontalOffset + headTransform.up * verticalOffset;
         
        }
        return offset;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!isWalking)
        {
            wlakingTime = 0;
        }
        else
        {
            wlakingTime += Time.deltaTime;
        }

        tragetCameraPosition = headTransform.position + CalculateHeadBobOffset(wlakingTime);

        cameraTransform.position = Vector3.Lerp(cameraTransform.position, tragetCameraPosition, headBlobSmoothing);
        if ((cameraTransform.position - tragetCameraPosition).magnitude <= 0.001)
        {
            cameraTransform.position = tragetCameraPosition;
        }

    }


}
