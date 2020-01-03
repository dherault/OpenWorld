using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Math3D {

  public static bool IsInSphere(Vector3 rootPosition, Vector3 targetPosition, float radius) {
    return Vector3.Magnitude(targetPosition - rootPosition) <= radius;
  }

}
