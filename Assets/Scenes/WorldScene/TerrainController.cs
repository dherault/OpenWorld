using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour {

  // void Start() {
    // Vector3 size = gameObject.GetComponent<Renderer>().bounds.size;
    // float cubeX = size.x / State._.nTilesX;
    // float cubeZ = size.z / State._.nTilesZ;

    // for (int x = 0; x < State._.nTilesX; x++) {
    //   for (int z = 0; z < State._.nTilesZ; z++) {
    //     Vector3 position = new Vector3(
    //       -size.x / 2 + (x + 0.5f) * cubeX,
    //       0.1f,
    //       -size.z / 2 + (z + 0.5f) * cubeZ
    //     );

    //     State._.tiles[x, z] = position;

    //     CreateCube(position, new Vector3(cubeX, 0.05f, cubeZ));
    //   }
    // }
  // }

  // void CreateCube(Vector3 position, Vector3 scale) {
  //   GameObject cubeGameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

  //   // cubeGameObject.GetComponent<MeshRenderer>().enabled = false;
  //   cubeGameObject.AddComponent<CubeController>();

  //   Renderer cubeRenderer = cubeGameObject.GetComponent<Renderer>();
  //   CubeController cubeController = cubeGameObject.GetComponent<CubeController>();

  //   cubeGameObject.transform.SetParent(gameObject.transform);
  //   cubeGameObject.transform.localPosition = position;
  //   cubeGameObject.transform.localScale = scale;
  //   cubeRenderer.material.color = Color.red;
  // }

}
