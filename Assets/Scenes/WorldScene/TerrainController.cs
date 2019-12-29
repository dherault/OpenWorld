using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour {

  public int xInVexels = 6;
  public int zInVexels = 6;
  public GameObject[,] cubes = new GameObject[6, 6];

  void Start() {
    Vector3 size = gameObject.GetComponent<Renderer>().bounds.size;
    float cubeX = size.x / xInVexels;
    float cubeZ = size.z / zInVexels;

    for (int x = 0; x < xInVexels; x++) {
      for (int z = 0; z < zInVexels; z++) {
        cubes[x, z] = CreateCube(
          gameObject.transform.position.x - size.x / 2 + (x + 0.5f) * cubeX,
          gameObject.transform.position.y + 0.1f,
          gameObject.transform.position.z - size.z / 2 + (z + 0.5f) * cubeZ,
          cubeX,
          0.05f,
          cubeZ
        );
      }
    }
  }

  GameObject CreateCube(float x, float y, float z, float sizeX, float sizeY, float sizeZ) {
    GameObject cubeGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

    cubeGameObject.GetComponent<MeshRenderer>().enabled = false;
    cubeGameObject.AddComponent<CubeController>();

    CubeController cubeController = cubeGameObject.GetComponent<CubeController>();

    cubeGameObject.transform.position = new Vector3(x, y, z);
    cubeGameObject.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);

    var cubeRenderer = cubeGameObject.GetComponent<Renderer>();

    cubeRenderer.material.color = Color.red;

    return cubeGameObject;
  }

}
