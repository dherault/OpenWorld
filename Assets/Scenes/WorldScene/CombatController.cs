using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController {

  public static Vector3 AvatarPositionOffset = new Vector3(0, 0, -16);
  
  public static void BeginCombat(GameObject ennemyGameObject) {
    GameObject avatarGameObject = GameObject.Find("Avatar");
    
    avatarGameObject.GetComponent<AvatarController>().GoToPosition(ennemyGameObject.transform.position + AvatarPositionOffset, 0);
  }
}
