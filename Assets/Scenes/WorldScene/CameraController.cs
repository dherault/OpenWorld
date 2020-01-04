using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

  public float movementPeriod = 0.2f;
  public bool isConstrainedToAvatar = true;
  public float positionIterationMovementFactor = 0.3f;

  private void Start() {
    transform.parent.transform.position = State._.cameraPosition._;
    transform.parent.transform.eulerAngles = State._.cameraRotation._;
    transform.eulerAngles = State._.cameraRotation._;
  }

  private void Update() {
    transform.parent.transform.eulerAngles = State._.cameraRotation._ ;
    transform.eulerAngles = State._.cameraRotation._ ;

    Vector3 diff = State._.cameraPosition._ - transform.parent.transform.position;
    float diffNorm = Vector3.Magnitude(diff);

    if (diffNorm > positionIterationMovementFactor / 2) {
      transform.parent.transform.position += positionIterationMovementFactor * diff / diffNorm;
    }

    transform.LookAt(transform.parent.transform.position);
  }

}
