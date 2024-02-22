using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header ("Aim")]
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float minXLook;
    [SerializeField] private float minYLook;
    [SerializeField] private float maxXLook;
    [SerializeField] private float maxYLook;
    [SerializeField] private float lookSensitivity;
    private float camCurXRot;
    private float camCurYRot;
    private Vector2 mouseDelta;

    [Header("Zoom")]
    [SerializeField] private float zoomSensitivity;
    private float scrollY;
    private float zoomAmount;

    private void Awake()
    {
        zoomAmount = 60f;
        camCurXRot = 45f;
        camCurYRot = 180f;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

    }

    private void LateUpdate()
    {
        CameraLook();
        CameraZoom();
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        mainCamera.transform.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        camCurYRot += mouseDelta.x * lookSensitivity;
        camCurYRot = Mathf.Clamp(camCurYRot, minYLook, maxYLook);
        transform.eulerAngles = new Vector3(0, camCurYRot, 0);

    }

    private void CameraZoom()
    {
        if (scrollY > 0 && mainCamera.fieldOfView <= 30)
        {
            mainCamera.fieldOfView = 30;
        }
        else if (scrollY < 0 && mainCamera.fieldOfView >= 60)
        {
            mainCamera.fieldOfView = 60;
        }
        else
        {
            zoomAmount += -scrollY * zoomSensitivity;
            mainCamera.fieldOfView = Mathf.Clamp(zoomAmount, 30, 60);
        }
    }

    public void OnAimInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnClickInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {

        }
        else if (context.phase == InputActionPhase.Canceled)
        {

        }
    }

    public void OnZoomInput(InputAction.CallbackContext context)
    {
        scrollY = context.ReadValue<float>();
    }
}
