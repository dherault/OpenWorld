// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class TerrainControllerOld : MonoBehaviour {

//   public int widthInVexels = 100;
//   public int heightInVexels = 100;
//   public GameObject[,] cubes = new GameObject[100, 100];
//   private int numberOfElevations = 8;

//   void Awake() {
//     gameObject.GetComponent<Renderer>().enabled = false;

//     for (int x = 0; x < widthInVexels; x++) {
//       for (int z = 0; z < heightInVexels; z++) {
//         cubes[x, z] = CreateCube(x, 0, z);
//       }
//     }

//     for (int i = 0; i < numberOfElevations; i++) {
//       int xCubeToElevate = (int)Math.Floor((decimal)UnityEngine.Random.Range(0, widthInVexels));
//       int zCubeToElevate = (int)Math.Floor((decimal)UnityEngine.Random.Range(0, heightInVexels));
//       int elevation = (int)Math.Floor((decimal)UnityEngine.Random.Range(1, 6));

//       UpdateCubeElevation(cubes, xCubeToElevate, zCubeToElevate, elevation);
//     }
//   }

//   GameObject CreateCube(int x, int y, int z) {
//     GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

//     cube.AddComponent<CubeController>();

//     CubeController cubeController = cube.GetComponent<CubeController>();

//     cubeController.x = x;
//     cubeController.y = y;
//     cubeController.z = z;

//     cube.transform.position = new Vector3(x, y, z);

//     var cubeRenderer = cube.GetComponent<Renderer>();

//     cubeRenderer.material.color = Color.red;

//     return cube;
//   }

//   void ElevateNeighbouringCubes(GameObject[,] cubes, int x, int z, int elevation) {
//     if (elevation == 0 || x < 0 || z < 0 || x >= 100 || z >= 100) {
//       return;
//     }

//     if (x > 0) {
//       UpdateCubeElevation(cubes, x - 1, z, elevation);
//     }

//     if (x < widthInVexels - 1) {
//       UpdateCubeElevation(cubes, x + 1, z, elevation);
//     }

//     if (z > 0) {
//       UpdateCubeElevation(cubes, x, z - 1, elevation);
//     }

//     if (z < heightInVexels - 1) {
//       UpdateCubeElevation(cubes, x, z + 1, elevation);
//     }
//   }

//   void UpdateCubeElevation(GameObject[,] cubes, int x, int z, int elevation) {
//     GameObject cube = cubes[x, z];

//     if (cube.transform.position.y < elevation) {
//       CubeController cubeController = cube.GetComponent<CubeController>();

//       cubeController.updatePosition(cube.transform.position.x, elevation, cube.transform.position.z);

//       ElevateNeighbouringCubes(cubes, x, z, elevation - 1);
//     }
//   }

// }
