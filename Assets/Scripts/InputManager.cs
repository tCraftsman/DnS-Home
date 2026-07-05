using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour {
    public static InputManager Instance;
    InputSystem_Actions actions;
    [SerializeField] Camera cam;

    public Vector2 RotateVector;
    public Vector2 MoveVector;
    public float ZoomFloat;
    public Vector2 MousePos;
    public Vector3 MouseWorldPosition;
    public bool Click;

    void Awake() {
        Instance = this;
        actions = new InputSystem_Actions();

        actions.Camera.Rotate.performed += Rotate;
        actions.Camera.Move.performed += Move;
        actions.Camera.Zoom.performed += Zoom;
        actions.Camera.MousePos.performed += Mouse;
        actions.Camera.Click.started += OnClick;
        actions.Camera.Click.canceled += OnClick;
    }

    void OnEnable() {
        actions.Enable();
    }

    void OnDisable() {
        actions.Disable();
    }

    private void Rotate(InputAction.CallbackContext ctx) {
        RotateVector = ctx.ReadValue<Vector2>();
    }

    void Move(InputAction.CallbackContext ctx) {
        MoveVector = ctx.ReadValue<Vector2>();
    }

    void Zoom(InputAction.CallbackContext ctx) {
        ZoomFloat = ctx.ReadValue<float>();
    }

    void Mouse(InputAction.CallbackContext ctx) {
        MousePos=ctx.ReadValue<Vector2>();
        Ray ray = cam.ScreenPointToRay(MousePos);
        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity);
        MouseWorldPosition = hit.point;
    }

    void OnClick(InputAction.CallbackContext ctx) {
        Click=ctx.ReadValueAsButton();
    }
}
