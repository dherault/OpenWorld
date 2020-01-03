using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour {

  public Transform cameraOrbitTransform;
  
  [HideInInspector]
  public float movementPeriod = 0.2f;
  private float _iterationRunningFactor = 0.23f;
  private float _rotationIteration = 12f;
  private Vector3 _goalPosition;
  private float _goalPositionThreshold = 0.23f / 2;
  private float _goalRotationY;
  private float _goalRotationYThreshold = 12f / 2;
  
  private Animator _animator;
  private RuntimeAnimatorController _runRuntimeAnimatorController;
  private RuntimeAnimatorController _idleRuntimeAnimatorController;

  void Start() {
    _goalPosition = State._.avatarPosition._;
    _goalRotationY = State._.avatarRotationY._;
    _animator = gameObject.GetComponent<Animator>();
    _runRuntimeAnimatorController = Resources.Load("AnimationControllers/BasicMotions@Run") as RuntimeAnimatorController;
    _idleRuntimeAnimatorController = Resources.Load("AnimationControllers/BasicMotions@Idle") as RuntimeAnimatorController;
  }

  void Update() {
    Vector3 positionDiff = _goalPosition - State._.avatarPosition._;
    float positionDiffNorm = Vector3.Magnitude(positionDiff);
    float rotationYDiff = _goalRotationY - State._.avatarRotationY._;
    
    if (rotationYDiff > 180) {
      rotationYDiff -= 360;
    }
    if (rotationYDiff < -180) {
      rotationYDiff += 360;
    }
    
    if (Mathf.Abs(rotationYDiff) > _goalRotationYThreshold) {
      transform.eulerAngles += new Vector3(0, Mathf.Sign(rotationYDiff) * _rotationIteration, 0);

      State._.avatarRotationY._ = transform.eulerAngles.y;
    }
    
    if (positionDiffNorm > _goalPositionThreshold) {
      SetRunning();

      positionDiff = _iterationRunningFactor * positionDiff / positionDiffNorm;
      
      cameraOrbitTransform.position += positionDiff;
      transform.position += positionDiff;

      State._.avatarPosition._ = transform.position;
    }
    else {
      SetIdle();
    }
  }

  public void UpdatePosition() {
    
  }

  public void GoToPosition(Vector3 position, float rotationY) {
    _goalPosition = position;
    _goalRotationY = rotationY;
    // Debug.Log("goal"+rotationY);
    // Debug.Log("current"+State._.avatarRotationY._);
  }

  private void SetRunning() {
    _animator.runtimeAnimatorController = _runRuntimeAnimatorController;
  }

  private void SetIdle() {
    _animator.runtimeAnimatorController = _idleRuntimeAnimatorController;
  }
  
}
