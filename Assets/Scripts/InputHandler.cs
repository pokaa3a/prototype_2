using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

  private Character character;
  private bool touchedCharacter = false;
  private float characterRadius = 1.0f;

  void Start() {
    character = GameObject.FindWithTag("Character").GetComponent<Character>();
  }

  void Update() {
    Vector2 fingerPos = Util.ToGameUnit(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    
    if (Input.GetMouseButtonDown(0)) {
      touchedCharacter = TouchedCharacter(fingerPos);
    }

    if (Input.GetMouseButton(0)) {
      if (touchedCharacter) {
        character.AddPathPoint(fingerPos);
      } else {

      }
    }
  }

  bool TouchedCharacter(Vector2 fingerPos) {
    return Vector2.Distance(fingerPos, character.Position()) <= characterRadius;
  }
}
