using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

  MeshRenderer rendered;

  void Start() {
    rendered = GetComponent<MeshRenderer>();
  }

  void OnMouseDown() {
    State._.avatarPosition._ = gameObject.transform.position;
    rendered.enabled = false;
  }

  void OnMouseOver() {
    if (State._.avatarPosition._.x == gameObject.transform.position.x && State._.avatarPosition._.z == gameObject.transform.position.z) {
      return;
    }

    rendered.enabled = true;
  }

  void OnMouseExit() {
    rendered.enabled = false;
  }

}
