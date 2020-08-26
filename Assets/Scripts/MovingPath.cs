using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath {
  
  List<Vector2> pathPoints;
  private const float MIN_DIST_BTW_PTS = 0.5f;

  public MovingPath() {
    pathPoints = new List<Vector2>();
  }

  public void AddPoint(Vector2 p) {
    if (pathPoints.Count == 0 ||
        Vector2.Distance(p, pathPoints[pathPoints.Count - 1]) > MIN_DIST_BTW_PTS) {
      pathPoints.Add(p);
    }
  }

  public void MoveAlongPath(Vector2 curPos, float distanceToMove, Action<Vector2> moveTo) {
    float distanceMoved = 0.0f;
    while (pathPoints.Count > 0 && distanceMoved < distanceToMove) {
      // |------|     (d = distance between curPos and pathPoints[0])
      // |--------->  Case: A (d < distanceToMove - distanceMoved)
      // |--->        Case: B (d > distanceToMove - distanceMoved)
      if (Vector2.Distance(curPos, pathPoints[0]) < distanceToMove - distanceMoved) {
        // Case A
        distanceMoved += Vector2.Distance(curPos, pathPoints[0]);
        curPos = pathPoints[0];
        pathPoints.RemoveAt(0);
      } else {
        // Case B
        float t = (distanceToMove - distanceMoved)
                    / Vector2.Distance(curPos, pathPoints[0]);
        curPos = Vector2.Lerp(curPos, pathPoints[0], t);
        distanceMoved = distanceToMove;
      }
    }
    moveTo(curPos);
  }
}
