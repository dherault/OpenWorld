using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour {

  private int widthInVexels = 100;
  private int heightInVexels = 100;
  private int numberOfElevations = 8;

  void Start() {
    gameObject.SetActive(false);

    GameObject[,] cubes = new GameObject[widthInVexels, heightInVexels];

    for (int x = 0; x < widthInVexels; x++) {
      for (int z = 0; z < heightInVexels; z++) {
        cubes[x, z] = CreateCube(x, 0, z);
      }
    }

    for (int i = 0; i < numberOfElevations; i++) {
      int xCubeToElevate = (int)Math.Floor((decimal)UnityEngine.Random.Range(0, widthInVexels));
      int zCubeToElevate = (int)Math.Floor((decimal)UnityEngine.Random.Range(0, heightInVexels));
      int elevation = (int)Math.Floor((decimal)UnityEngine.Random.Range(1, 6));

      GameObject cubeToElevate = cubes[xCubeToElevate, zCubeToElevate];

      cubeToElevate.transform.position = new Vector3(cubeToElevate.transform.position.x, elevation, cubeToElevate.transform.position.z);

      ElevateNeighbouringCubes(cubes, xCubeToElevate, zCubeToElevate, elevation - 1);
    }
  }

  void Update() {

  }

  GameObject CreateCube(int x, int y, int z) {
    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
    cube.transform.position = new Vector3(x, y, z);

    var cubeRenderer = cube.GetComponent<Renderer>();

    cubeRenderer.material.color = Color.red;

    return cube;
  }

  void ElevateNeighbouringCubes(GameObject[,] cubes, int x, int z, int elevation) {
    if (elevation == 0 || x < 0 || z < 0 || x >= 100 || z >= 100) {
      return;
    }

    GameObject cube;

    if (x > 0) {
      cube = cubes[x - 1, z];

      if (cube.transform.position.y < elevation) {
        cube.transform.position = new Vector3(cube.transform.position.x, elevation, cube.transform.position.z);
        ElevateNeighbouringCubes(cubes, x - 1, z, elevation - 1);
      }
    }

    if (x < 100 - 1) {
      cube = cubes[x + 1, z];

      if (cube.transform.position.y < elevation) {
        cube.transform.position = new Vector3(cube.transform.position.x, elevation, cube.transform.position.z);
        ElevateNeighbouringCubes(cubes, x + 1, z, elevation - 1);
      }
    }

    if (z > 0) {
      cube = cubes[x, z - 1];

      if (cube.transform.position.y < elevation) {
        cube.transform.position = new Vector3(cube.transform.position.x, elevation, cube.transform.position.z);
        ElevateNeighbouringCubes(cubes, x, z - 1, elevation - 1);
      }
    }

    if (z < 100 - 1) {
      cube = cubes[x, z + 1];

      if (cube.transform.position.y < elevation) {
        cube.transform.position = new Vector3(cube.transform.position.x, elevation, cube.transform.position.z);
        ElevateNeighbouringCubes(cubes, x, z + 1, elevation - 1);
      }
    }
  }

}
