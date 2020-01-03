using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsController : MonoBehaviour {

  public Transform cameraOrbitTransform;
  private AvatarController avatarController;

  public float cameraRotationSpeed = 12f;
  private double[,] rotationMatrix = new double[3, 3];
  
  void Start() {
    avatarController = GameObject.Find("Avatar").GetComponent<AvatarController>();
  }

  void Update() {
    foreach (KeyValuePair<string, string> item in State._.shortcuts) {
      KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), State._.shortcuts[item.Key]);

      if (Input.GetKeyDown(keyCode)) {
        ((ObservableBoolean)typeof(State).GetField(item.Key).GetValue(State._))._ = !((ObservableBoolean)typeof(State).GetField(item.Key).GetValue(State._))._;
      }
    }

    if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
      Vector3 velocity = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
      velocity = velocity /  Vector3.Magnitude(velocity);
      
      double yRotation = cameraOrbitTransform.eulerAngles.y * Math.PI / 180;

      InitializeRotationMatrix();
      rotationMatrix[1, 1] = 1;
      rotationMatrix[0, 0] = Math.Cos(yRotation);
      rotationMatrix[0, 2] = Math.Sin(yRotation);
      rotationMatrix[2, 0] = -Math.Sin(yRotation);
      rotationMatrix[2, 2] = Math.Cos(yRotation);
      
      avatarController.GoToPosition(
        State._.avatarPosition._ + avatarController.movementPeriod * MultiplyMatrixAndVector(rotationMatrix,  velocity),
        (cameraOrbitTransform.eulerAngles.y + 90 + Mathf.Atan2(-velocity.z, velocity.x) * 180 / (float)Math.PI) % 360
      );
    }

    if (Input.GetMouseButton(1)) {
      float h = cameraRotationSpeed * Input.GetAxis("Mouse X");
      float v = cameraRotationSpeed * Input.GetAxis("Mouse Y");

      if (cameraOrbitTransform.eulerAngles.z + v <= 0.1f || cameraOrbitTransform.eulerAngles.z + v >= 179.9f) {
        v = 0;
      }

      cameraOrbitTransform.eulerAngles = new Vector3(
        cameraOrbitTransform.eulerAngles.x,
        cameraOrbitTransform.eulerAngles.y + h,
        cameraOrbitTransform.eulerAngles.z + v
      );
    }

    float scrollFactor = Input.GetAxis("Mouse ScrollWheel");

    if (scrollFactor != 0) {
      cameraOrbitTransform.localScale = new Vector3(
        Math.Max(2, Math.Min(12, cameraOrbitTransform.localScale.x * (1f - scrollFactor))),
        Math.Max(2, Math.Min(12, cameraOrbitTransform.localScale.y * (1f - scrollFactor))),
        Math.Max(2, Math.Min(12, cameraOrbitTransform.localScale.z * (1f - scrollFactor)))
      );
    }
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
