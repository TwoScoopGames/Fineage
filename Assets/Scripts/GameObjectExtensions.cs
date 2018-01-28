using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectExtensions {

  public static GameObject FindParentByTag(GameObject self, string tag) {
    if (self == null) {
      return null;
    }
    if (self.tag == tag) {
      return self;
    }
    if (self.transform.parent == null) {
      return null;
    }
    return FindParentByTag(self.transform.parent.gameObject, tag);
  }
}
