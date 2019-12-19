using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

  private float mainSpeed = 25.0f;
  private float orbitSensibility = 0.25f;
  private float panSensibility = 0.1f;
  private Vector3 mousePosition = new Vector3(0, 0, 0);
  private Vector3 mousePositionDifference;
  private Vector3 v;

  void Start() {
    transform.position = new Vector3(0, 10, 0);
  }

  void Update () {
    mousePositionDifference = Input.mousePosition - mousePosition;

    if (Input.GetMouseButton(1)) {
      v = new Vector3(-mousePositionDifference.y * orbitSensibility, mousePositionDifference.x * orbitSensibility, 0);

      transform.eulerAngles = new Vector3(transform.eulerAngles.x + v.x , transform.eulerAngles.y + v.y, 0);
    }

    v = GetBaseInput();

    if (Input.GetMouseButton(2)) {
      v -= mousePositionDifference * panSensibility;
    }

    v *= mainSpeed * Time.deltaTime;
    mousePosition = Input.mousePosition;

    transform.Translate(v);
    transform.position = new Vector3(
      Math.Max(-50, Math.Min(50, transform.position.x)),
      Math.Max(3, Math.Min(20, transform.position.y)),
      Math.Max(-50, Math.Min(50, transform.position.z))
    );
  }

  private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
    Vector3 speed = new Vector3();

    if (Input.GetKey (KeyCode.W)) {
      speed += new Vector3(0, 0 , 1);
    }

    if (Input.GetKey (KeyCode.S)) {
      speed += new Vector3(0, 0, -1);
    }

    if (Input.GetKey (KeyCode.A)) {
      speed += new Vector3(-1, 0, 0);
    }

    if (Input.GetKey (KeyCode.D)) {
      speed += new Vector3(1, 0, 0);
    }

    return speed;
  }

}
