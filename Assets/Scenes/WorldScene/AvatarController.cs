using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour {

  public Transform cameraOrbitTransform;
  private CameraController _cameraController;

  public float movementPeriod = 0.4f;
  public float iterationRunningMovementFactor = 0.3f;
  public float rotationIteration = 12f;
  private Vector3 _goalPosition;
  private float _goalRotationY;

  private Animator _animator;
  private RuntimeAnimatorController _runRuntimeAnimatorController;
  private RuntimeAnimatorController _idleRuntimeAnimatorController;

  void Start() {
    _goalPosition = State._.avatarPosition._;
    _goalRotationY = State._.avatarRotationY._;
    _animator = gameObject.GetComponent<Animator>();
    _cameraController = GameObject.Find("Camera").GetComponent<CameraController>();
    _runRuntimeAnimatorController = Resources.Load("AnimationControllers/BasicMotions@Run") as RuntimeAnimatorController;
    _idleRuntimeAnimatorController = Resources.Load("AnimationControllers/BasicMotions@Idle") as RuntimeAnimatorController;
  }

  void Update() {
    float rotationYDiff = State._.avatarRotationY._ - transform.eulerAngles.y;

    if (rotationYDiff > 180) {
      rotationYDiff -= 360;
    }
    else if (rotationYDiff < -180) {
      rotationYDiff += 360;
    }

    if (Mathf.Abs(rotationYDiff) > rotationIteration / 2) {
      transform.eulerAngles += Mathf.Sign(rotationYDiff) * rotationIteration * Vector3.up;
    }

    Vector3 positionDiff = State._.avatarPosition._ - transform.position;
    float positionDiffNorm = Vector3.Magnitude(positionDiff);

    Debug.Log(positionDiffNorm);
    if (positionDiffNorm > iterationRunningMovementFactor / 2) {
      SetRunning();

      positionDiff = iterationRunningMovementFactor * positionDiff / positionDiffNorm;

      transform.position += positionDiff;

      if (_cameraController.isConstrainedToAvatar) {
        State._.cameraPosition._ += positionDiff;
      }
    }
    else {
      SetIdle();
    }
  }

  public void GoToPosition(Vector3 position, float rotationY) {
    _goalPosition = position;
    _goalRotationY = rotationY;
  }

  private void SetRunning() {
    _animator.runtimeAnimatorController = _runRuntimeAnimatorController;
  }

  private void SetIdle() {
    _animator.runtimeAnimatorController = _idleRuntimeAnimatorController;
  }

}
