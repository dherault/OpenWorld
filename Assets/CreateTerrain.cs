using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour {

  private int widthInVexels = 100;
  private int heightInVexels = 100;

  void Start() {
    gameObject.SetActive(false);

    Debug.Log("Start");

    for (int x = -widthInVexels / 2; x < widthInVexels / 2; x++) {
      for (int z = -heightInVexels / 2; z < heightInVexels / 2; z++) {
        CreateCube(x, 0, z);
      }
    }

  }

  void Update() {

  }

  void CreateCube(int x, int y, int z) {
    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    cube.transform.position = new Vector3(x, y, z);

    var cubeRenderer = cube.GetComponent<Renderer>();

    cubeRenderer.material.color = Color.red;
  }

}
