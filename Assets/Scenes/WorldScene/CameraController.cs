using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
  public Transform cameraOrbitTransform;
  public Transform targetTransform;
  private float targetPositionOffset = 1.75f;

  void Start() {
    cameraOrbitTransform.position = this.GetOffsetedTargetPosition();
  }

  void Update() {
    transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0);

    transform.LookAt(this.GetOffsetedTargetPosition());
  }

  Vector3 GetOffsetedTargetPosition() {
    return new Vector3(
      targetTransform.position.x,
      targetTransform.position.y + targetPositionOffset,
      targetTransform.position.z
    );
  }

}
