using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{

  private float moveSpeed = 1.5f;
  private float scrollSpeed = 10;
  private float orbitSensibility = 0.23f;
  private Vector3 previousMousePosition = new Vector3(0, 0, 0);
  private double[,] rotationMatrix = new double[3, 3];
  private float goalHeight = 10;
  private float heightIncrement = 0.5f;

  void Start() {
    transform.position = new Vector3(0, goalHeight, 0);
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
      InitializeRotationMatrix();

      rotationMatrix[1, 1] = 1;
      rotationMatrix[0, 0] = Math.Cos(transform.eulerAngles.y * Math.PI / 180);
      rotationMatrix[0, 2] = Math.Sin(transform.eulerAngles.y * Math.PI / 180);
      rotationMatrix[2, 0] = -Math.Sin(transform.eulerAngles.y * Math.PI / 180);
      rotationMatrix[2, 2] = Math.Cos(transform.eulerAngles.y * Math.PI / 180);

      Vector3 velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

      transform.position += moveSpeed * MultiplyMatrixAndVector(rotationMatrix, velocity);
    }

    if (Input.GetAxis("Mouse ScrollWheel") != 0) {
      goalHeight += scrollSpeed * -Input.GetAxis("Mouse ScrollWheel");
    }

    if (transform.position.y != goalHeight) {
      float diff = goalHeight - transform.position.y;
      float diffSign = Math.Sign(diff);

      diff = Math.Min(heightIncrement, Math.Abs(diff));

      transform.position += new Vector3(0, diffSign * diff, 0);
    }

    transform.position =new Vector3(
      Math.Min(100, Math.Max(0, transform.position.x)),
      Math.Min(20, Math.Max(1, transform.position.y)),
      Math.Min(100, Math.Max(0, transform.position.z))
    );
  }

  void InitializeRotationMatrix() {
    for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
        rotationMatrix[i, j] = 0;
      }
    }
  }

  Vector3 MultiplyMatrixAndVector(double[,] m, Vector3 v) {
    return new Vector3(
      v.x * (float)m[0, 0] + v.y * (float)m[0, 1] + v.z * (float)m[0, 2],
      v.x * (float)m[1, 0] + v.y * (float)m[1, 1] + v.z * (float)m[1, 2],
      v.x * (float)m[2, 0] + v.y * (float)m[2, 1] + v.z * (float)m[2, 2]
    );
  }
}
