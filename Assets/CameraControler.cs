using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

  private float moveSpeed = 0.5f;
  private float scrollSpeed = 10f;
  private float orbitSensibility = 0.23f;
  private Vector3 previousMousePosition = new Vector3(0, 0, 0);
  private double[,] rotationMatrix = new double[3, 3];

  void Start() {
    transform.position = new Vector3(0, 10, 0);
  }

  void Update () {
    if (Input.GetMouseButton(1)) {
      previousMousePosition = Input.mousePosition - previousMousePosition ;
      previousMousePosition = new Vector3(-previousMousePosition.y * orbitSensibility, previousMousePosition.x * orbitSensibility, 0 );
      previousMousePosition = new Vector3(transform.eulerAngles.x + previousMousePosition.x , transform.eulerAngles.y + previousMousePosition.y, 0);
      transform.eulerAngles = previousMousePosition;
    }

    previousMousePosition = Input.mousePosition;



    if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
      // InitializeRotationMatrix();

      // rotationMatrix[1, 1] = 1;
      // rotationMatrix[0, 0] = Math.Cos(transform.eulerAngles.y);
      // rotationMatrix[0, 1] = Math.Sin(transform.eulerAngles.y);
      // rotationMatrix[2, 0] = -Math.Sin(transform.eulerAngles.y);
      // rotationMatrix[2, 1] = Math.Cos(transform.eulerAngles.y);

      Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

      transform.position += moveSpeed * MultiplyVectorAndMatrix(velocity, rotationMatrix);
      transform.position += moveSpeed * velocity;
    }

    if (Input.GetAxis("Mouse ScrollWheel") != 0) {
      transform.position += scrollSpeed * new Vector3(0, -Input.GetAxis("Mouse ScrollWheel"), 0);
    }

  }

  void InitializeRotationMatrix() {
    for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
        rotationMatrix[i, j] = 0;
      }
    }
  }

  Vector3 MultiplyVectorAndMatrix(Vector3 v, double[,] m) {
    return new Vector3(
      v.x * (float)m[0, 0] + v.y * (float)m[1, 0] + v.z * (float)m[2, 0],
      v.x * (float)m[0, 1] + v.y * (float)m[1, 1] + v.z * (float)m[2, 1],
      v.x * (float)m[0, 2] + v.y * (float)m[1, 2] + v.z * (float)m[2, 2]
    );
  }

}
