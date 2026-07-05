using System;
using UnityEngine;
using UnityEngine.AI;
using Helpers;
using UnityEngine.UI;

public class Pawn : MonoBehaviour {
    NavMeshAgent _navMeshAgent;
    [SerializeField] LineDrawer _lineDrawer;
    NavMeshPath _targetPath, _limitedPath;

    bool _currentlyControlable;

    Vector3 _mouseTarget;
    Vector3 _currentLimitedTarget;

    public Slider moveSlider;

    public float movement = 30f;
    float _movementLeft;
    float _tempMovement;

    void Start() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _targetPath = new NavMeshPath();
        _limitedPath = new NavMeshPath();
        movement = Converters.MeterToFoot(movement);
        _movementLeft = movement;
    }

    void Update() {
        if (!_navMeshAgent.pathPending && !_navMeshAgent.hasPath) {
            _navMeshAgent.CalculatePath(InputManager.Instance.MouseWorldPosition, _targetPath); // CALCULATE PATH TO WHERE MOUSE IS
            CalculatePathDistance(_targetPath);
        }
        else {
            _navMeshAgent.CalculatePath(_currentLimitedTarget, _limitedPath); // CALCULATE PATH TO WHERE PAWN WALKS
            _navMeshAgent.CalculatePath(_mouseTarget, _targetPath); // CALCULATE PATH TO WHERE PAWN WALKS
        }

        if (InputManager.Instance.Click) {
            // WALK SCRIPT
            _mouseTarget = InputManager.Instance.MouseWorldPosition;
            CalculatePathDistance(_targetPath);
            Move(_currentLimitedTarget);
            _currentlyControlable = false;
        }

        // DRAW WHITE LINE
        _lineDrawer.SetCount(0, _limitedPath.corners.Length);
        for (int i = 0; i < _limitedPath.corners.Length; i++) {
            if (i == 0) {
                _lineDrawer.SetPosition(0, 0, transform.position);
            }
            else {
                _lineDrawer.SetPosition(0, i, _limitedPath.corners[i]);
            }
        }

        // DRAW RED LINE
        _lineDrawer.SetCount(1, _targetPath.corners.Length);
        for (int i = 0; i < _targetPath.corners.Length; i++) {
            if (i == 0) {
                _lineDrawer.SetPosition(1, 0, transform.position);
            }
            else {
                _lineDrawer.SetPosition(1, i, _targetPath.corners[i]);
            }
        }

        moveSlider.value = _movementLeft / movement;
    }

    float CalculatePathDistance(NavMeshPath path) {
        float d = 0f;
        float percentageLeft;
        var c = path.corners;
        _tempMovement = _movementLeft;
        for (int i = 0; i < c.Length - 1; i++) {
            percentageLeft = _tempMovement / Vector3.Distance(c[i], c[i + 1]);
            _tempMovement -= Vector3.Distance(c[i], c[i + 1]);
            if (_tempMovement <= 0) {
                Vector3.Lerp(c[i], c[i + 1], percentageLeft);
                _currentLimitedTarget = Vector3.Lerp(c[i], c[i + 1], percentageLeft);
                d += Mathf.Lerp(0, Vector3.Distance(c[i], c[i + 1]), percentageLeft);
                _navMeshAgent.CalculatePath(_currentLimitedTarget, _limitedPath);
                return d;
            }
            else {
                _currentLimitedTarget = c[i + 1];
                d += Vector3.Distance(c[i], c[i + 1]);
            }
        }
        _navMeshAgent.CalculatePath(_currentLimitedTarget, _limitedPath);
        return d;
    }

    public void Move(Vector3 targetPos) {
        _navMeshAgent.destination = targetPos;
    }
}
