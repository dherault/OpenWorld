using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortcutsController : MonoBehaviour {

  public Transform cameraOrbitTransform;
  private AvatarController avatarController;

  public float cameraRoationSpeed = 12f;

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
      avatarController.UpdatePosition(new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal")));
    }

    if (Input.GetMouseButton(1)) {
      float h = cameraRoationSpeed * Input.GetAxis("Mouse X");
      float v = cameraRoationSpeed * Input.GetAxis("Mouse Y");

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
      print(scrollFactor);
      cameraOrbitTransform.localScale = new Vector3(
        Math.Max(0.5f, Math.Min(2, cameraOrbitTransform.localScale.x * (1f - scrollFactor))),
        Math.Max(0.5f, Math.Min(2, cameraOrbitTransform.localScale.y * (1f - scrollFactor))),
        Math.Max(0.5f, Math.Min(2, cameraOrbitTransform.localScale.z * (1f - scrollFactor)))
      );
    }
  }

}
