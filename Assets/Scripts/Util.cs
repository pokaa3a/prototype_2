using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util {
  public const float unit = 0.4f;

  public static Vector2 ToGameUnit(Vector2 vec2_w) {
    return vec2_w / unit;
  }
  public static Vector2 ToGameUnit(Vector3 vec3_w) {
    return vec3_w / unit;
  }
  public static float ToGameUnit(float val_w) {
    return val_w / unit;
  }
  public static Vector2 ToWorldUnit(Vector2 vec2_g) {
    return vec2_g * unit;
  }
  public static float ToWorldUnit(float val_g) {
    return val_g * unit;
  }
}