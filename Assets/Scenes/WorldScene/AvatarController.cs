using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour, Observer {

  public void Update() {
    transform.position = State._.avatarPosition._;
  }

}
