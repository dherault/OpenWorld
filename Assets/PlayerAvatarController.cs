using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarController : MonoBehaviour {

  private float elevationOffset = 0.25f;
  private float cubeHeight = 1;

  void Start() {
    TerrainController TerrainScript = GameObject.Find("Terrain").GetComponent<TerrainController>();
    GameObject originCube = TerrainScript.cubes[TerrainScript.widthInVexels / 2, TerrainScript.heightInVexels / 2];

    transform.position = new Vector3(originCube.transform.position.x, originCube.transform.position.y + originCube.transform.localScale.y + elevationOffset, originCube.transform.position.z);
  }

  public void UpdatePosition(float x, float y, float z) {
    transform.position = new Vector3(x, y + elevationOffset + cubeHeight, z);
  }

}
