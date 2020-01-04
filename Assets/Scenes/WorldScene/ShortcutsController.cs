using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsController : MonoBehaviour {

  public Transform avatarTransform;
  public Transform cameraOrbitTransform;
  public float cameraRotationSpeed = 12f;

  private AvatarController _avatarController;
  private CameraController _cameraController;
  private readonly float[,] _rotationMatrix = new float[3, 3];

  private void Start() {
    _avatarController = GameObject.Find("Avatar").GetComponent<AvatarController>();
    _cameraController = GameObject.Find("Camera").GetComponent<CameraController>();

    InitializeRotationMatrix();
    _rotationMatrix[1, 1] = 1;
  }

  private void Update() {
    foreach (KeyValuePair<string, string> item in State._.shortcuts) {
      KeyCode keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), State._.shortcuts[item.Key]);

      if (Input.GetKeyDown(keyCode)) {
        ((ObservableBoolean)typeof(State).GetField(item.Key).GetValue(State._))._ = !((ObservableBoolean)typeof(State).GetField(item.Key).GetValue(State._))._;
      }
    }

    if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
      Vector3 velocity = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal"));
      velocity = velocity /  Vector3.Magnitude(velocity);

      float yRotation = (float)(cameraOrbitTransform.eulerAngles.y * Math.PI) / 180;
      float trigo = Mathf.Cos(yRotation);

      _rotationMatrix[0, 0] = trigo;
      _rotationMatrix[2, 2] = trigo;

      trigo = Mathf.Sin(yRotation);

      _rotationMatrix[0, 2] = trigo;
      _rotationMatrix[2, 0] = -trigo;

      if (_cameraController.isConstrainedToAvatar) {
        State._.avatarPosition._ = avatarTransform.position + _avatarController.movementPeriod * MultiplyMatrixAndVector(_rotationMatrix, velocity);
        State._.avatarRotationY._ = (cameraOrbitTransform.eulerAngles.y + 90 + Mathf.Atan2(-velocity.z, velocity.x) * 180 / (float) Math.PI) % 360;
      }
      else {
        State._.cameraPosition._ = cameraOrbitTransform.position + _cameraController.movementPeriod * MultiplyMatrixAndVector(_rotationMatrix, velocity);
      }
    }

    if (Input.GetMouseButton(1)) {
      float h = cameraRotationSpeed * Input.GetAxis("Mouse X");
      float v = cameraRotationSpeed * Input.GetAxis("Mouse Y");

      if (cameraOrbitTransform.eulerAngles.z + v <= 1 || cameraOrbitTransform.eulerAngles.z + v >= 89) {
        v = 0;
      }

      State._.cameraRotation._ += new Vector3(0, h, v);
    }

    float scrollFactor = Input.GetAxis("Mouse ScrollWheel");

    if (scrollFactor != 0) {
      // Todo use Math.Clamp
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
        _rotationMatrix[i, j] = 0;
      }
    }
  }

  Vector3 MultiplyMatrixAndVector(float[,] m, Vector3 v) {
    return new Vector3(
      v.x * m[0, 0] + v.y * m[0, 1] + v.z * m[0, 2],
      v.x * m[1, 0] + v.y * m[1, 1] + v.z * m[1, 2],
      v.x * m[2, 0] + v.y * m[2, 1] + v.z * m[2, 2]
    );
  }

}
