using System;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour {
    GameManager _gameManager;
    InputManager inputManager;
    [SerializeField] Transform mainCamera;
    [SerializeField] Transform target;
    [SerializeField] bool isFollowing;
    [SerializeField] float minAngle, maxAngle;
    Vector3 moveOffset, rotationOffset;
    float zoomOffset;
    Vector3 tempRot;
    Vector3 offsetRef;
    public TMP_Text txt;
    void Start() {
        _gameManager = GameManager.Instance;
        inputManager = InputManager.Instance;
    }

    void Update() {
        MoveCamera(inputManager.MoveVector);
        RotateCamera(inputManager.RotateVector);
        Zoom(inputManager.ZoomFloat);

        if (isFollowing) {
            moveOffset = target.position;
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref offsetRef, 0.1f);
        }
    }

    void MoveCamera(Vector2 moveDir) {
        if (moveDir.magnitude > 0) {
            SetFollowing(false);
            moveOffset = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * new Vector3(moveDir.x, 0, moveDir.y);
            transform.position += new Vector3(-moveOffset.x, target.position.y, -moveOffset.z) * (Time.deltaTime * _gameManager.configs.MoveSensitivity);
        }
    }

    void RotateCamera(Vector2 newDir) {
        float yRot = -newDir.y + rotationOffset.y;
        float xRot = newDir.x + rotationOffset.x;
        tempRot += new Vector3(yRot, xRot, 0f) * (_gameManager.configs.RotateSensitivity * Time.deltaTime);
        float clampedAngle = Mathf.Clamp(tempRot.x, minAngle, maxAngle);
        // IF WANT TO ROTATE X, USE "clamped angle.x" INSTEAD OF 0 BELLOW
        transform.eulerAngles = new Vector3(0, tempRot.y, 0);
    }

    void Zoom(float zoom) {
        if (zoom == 0) return;
        float tempZoom = (zoomOffset - zoom * _gameManager.configs.ZoomStep);
        txt.text = tempZoom.ToString();
        zoomOffset = Mathf.Clamp(tempZoom, _gameManager.configs.MinDistance, _gameManager.configs.MaxDistance);
        mainCamera.localPosition = new Vector3(0, zoomOffset, -zoomOffset);
    }

    public void SetTarget(Transform target) => this.target = target;
    public void SetFollowing(bool isFollowing) => this.isFollowing = isFollowing;
}
