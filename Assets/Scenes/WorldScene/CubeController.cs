using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

  public float x = 0;
  public float y = 0;
  public float z = 0;
  Color mousOverColor = Color.green;
  Color orginalColor;
  MeshRenderer rendered;

  void Start() {
    rendered = GetComponent<MeshRenderer>();
    orginalColor = rendered.material.color;
  }

  void OnMouseDown() {
    GameObject.Find("PlayerAvatar").GetComponent<PlayerAvatarController>().UpdatePosition(x, y, z);
  }

  void OnMouseOver() {
    rendered.material.color = mousOverColor;
  }

  void OnMouseExit()  {
    rendered.material.color = orginalColor;
  }

  public void updatePosition(float nextX, float nextY, float nextZ) {
    x = nextX;
    y = nextY;
    z = nextZ;

    transform.position = new Vector3(x, y, z);
  }

}
