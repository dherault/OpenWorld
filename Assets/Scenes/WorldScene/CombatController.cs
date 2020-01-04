using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController {

  private static Vector3 _avatarPositionOffset = 16 * Vector3.back;
  private static Vector3 _cameraPositionOffset = 16 * Vector3.left;

  public static void BeginCombat(Transform enemyGroupTransform) {
    CameraController cameraController = GameObject.Find("Camera").GetComponent<CameraController>();

    Vector3 position = Vector3.zero;

    foreach (Transform childTransform in enemyGroupTransform) {
      position += childTransform.position;
    }

    position /= enemyGroupTransform.childCount;
    position += _avatarPositionOffset / 2;

    cameraController.isConstrainedToAvatar = false;
    State._.cameraPosition._ = position;

    position += _avatarPositionOffset / 2;

    State._.avatarPosition._ = position;
    State._.avatarRotationY._ = 0;
  }
}
