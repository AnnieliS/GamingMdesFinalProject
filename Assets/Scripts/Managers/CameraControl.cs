using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Camera Location")]
    [SerializeField] GameObject toFollow;
    [SerializeField] float posXoffset;
    [SerializeField] float posYoffset;
    [SerializeField] float posZoffset;
    [Header("Rotating Camera")]
    [SerializeField] float cameraSpeed;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] bool clampX = true;
    [SerializeField] bool clampY = false;

    [Header("Zoom Camera")]
    [SerializeField] float minFOV;
    [SerializeField] float maxFOV;
    [SerializeField] float zoomSensitivity;


    private bool controlCamera = true;
    private static CameraControl instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Camera Manager in the scene");
        }
        instance = this;
    }

    public static CameraControl GetInstance()
    {
        return instance;
    }

    private void Start()
    {

        CameraLocation();
    }


    private void LateUpdate()
    {
        if (controlCamera)
        {
            RotateInFrame();
            ZoomCamera();
        }
    }


    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }


    void RotateInFrame()
    {
        if (!Input.GetMouseButton(2)) return; // RMB down


        float mx = Input.GetAxis("Mouse X") * Time.deltaTime * cameraSpeed;
        float my = Input.GetAxis("Mouse Y") * Time.deltaTime * cameraSpeed;

        // Vector3 rot = transform.rotation.eulerAngles + new Vector3(-my, mx, 0f); //use local if your char is not always oriented Vector3.up
        // if (clampX) rot.x = ClampAngle(rot.x, minX, maxX);
        // if (clampY) rot.y = Mathf.Clamp(rot.y, minY, maxY);

        Vector3 rot = transform.rotation.eulerAngles + new Vector3(0f, mx, -my); //use local if your char is not always oriented Vector3.up
        if (clampX) rot.z = ClampAngle(rot.z, minX, maxX);
        if (clampY) rot.y = Mathf.Clamp(rot.y, minY, maxY);


        // Debug.Log(rot);

        transform.eulerAngles = rot;
    }

    void ZoomCamera()
    {
        float fov = Camera.main.fieldOfView;
        fov -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        fov = Mathf.Clamp(fov, minFOV, maxFOV);
        Camera.main.fieldOfView = fov;
    }

    void CameraLocation()
    {
        Camera.main.transform.position = new Vector3(toFollow.transform.position.x + posXoffset, toFollow.transform.position.y + posYoffset, toFollow.transform.position.z + posZoffset);
        Camera.main.transform.SetParent(toFollow.transform);
    }

    public void TurnOffCameraControl()
    {
        controlCamera = false;
    }

    public void TurnOnCameraControl()
    {
        controlCamera = true;
    }
}

