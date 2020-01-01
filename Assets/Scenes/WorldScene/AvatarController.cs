using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarController : MonoBehaviour {

  public Transform cameraOrbitTransform;
  public float movementPeriod = 0.2f;
  private double[,] rotationMatrix = new double[3, 3];
  private Animator animator;
  private RuntimeAnimatorController runRuntimeAnimatorController;
  private RuntimeAnimatorController idleRuntimeAnimatorController;

  void Start() {
    animator = gameObject.GetComponent<Animator>();
    runRuntimeAnimatorController = Resources.Load("AnimationControllers/BasicMotions@Run") as RuntimeAnimatorController;
    idleRuntimeAnimatorController = Resources.Load("AnimationControllers/BasicMotions@Idle") as RuntimeAnimatorController;
  }
  
  public void UpdatePosition(Vector3 velocity) {
    float velocityNorm = (float)Math.Sqrt(velocity.x * velocity.x + velocity.y * velocity.y + velocity.z * velocity.z);
    
    Vector3 normalizedVelocity = new Vector3(velocity.x / velocityNorm, velocity.y / velocityNorm, velocity.z / velocityNorm
                                                                                                   );
    InitializeRotationMatrix();

    double yRotation = cameraOrbitTransform.eulerAngles.y * Math.PI / 180;
    
    rotationMatrix[1, 1] = 1;
    rotationMatrix[0, 0] = Math.Cos(yRotation);
    rotationMatrix[0, 2] = Math.Sin(yRotation);
    rotationMatrix[2, 0] = -Math.Sin(yRotation);
    rotationMatrix[2, 2] = Math.Cos(yRotation);

    Vector3 positionDelta = movementPeriod * MultiplyMatrixAndVector(rotationMatrix, normalizedVelocity);

    yRotation = (float)Math.Atan2(positionDelta.x, positionDelta.z) * 180 / Math.PI;
    
    transform.position += positionDelta;
    transform.eulerAngles = new Vector3(0, (float)yRotation, 0);
    cameraOrbitTransform.position += positionDelta;
    animator.runtimeAnimatorController = runRuntimeAnimatorController;
  }

  public void SetIdle() {
    animator.runtimeAnimatorController = idleRuntimeAnimatorController;
  }

  void InitializeRotationMatrix() {
    for (int i = 0; i < 3; i++) {
      for (int j = 0; j < 3; j++) {
        rotationMatrix[i, j] = 0;
      }
    }
  }

  Vector3 MultiplyMatrixAndVector(double[,] m, Vector3 v) {
    return new Vector3(
      v.x * (float)m[0, 0] + v.y * (float)m[0, 1] + v.z * (float)m[0, 2],
      v.x * (float)m[1, 0] + v.y * (float)m[1, 1] + v.z * (float)m[1, 2],
      v.x * (float)m[2, 0] + v.y * (float)m[2, 1] + v.z * (float)m[2, 2]
    );
  }
}
