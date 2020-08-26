using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
  
  private Vector2 _position;
  private float speed = 2.0f;

  public Vector2 position {
    get {
      _position = Util.ToGameUnit(gameObject.transform.position);
      return _position;
    }
    set {
      _position = value;
      gameObject.transform.position = Util.ToWorldUnit(_position);
    }
  }
  private MovingPath movingPath;

  void Start() {
    movingPath = new MovingPath();
  }

  void Update() {
    float distanceToMove = speed * Time.deltaTime;
    movingPath.MoveAlongPath(position, distanceToMove, (Vector2 p) => MoveTo(p));
  }

  public Vector2 Position() {
    return new Vector2(Util.ToGameUnit(gameObject.transform.position.x), 
                       Util.ToGameUnit(gameObject.transform.position.y));
  }

  public void MoveTo(Vector2 p) {
    position = p;
  }

  public void AddPathPoint(Vector2 p) {
    movingPath.AddPoint(p);
  }
}
