using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTreeNode {
  public Dictionary<string, string> prefabs;
  public TechTreeNode[] children;

  public void Spawn(GameObject player, Player playerComponent) {
    foreach (var item in prefabs) {
      var target = player.transform.Find(item.Key);
      var prefab = CachedResource.Load<GameObject>(item.Value);
      var gameObject = Object.Instantiate(prefab, target);

      var skeletonAnimation = gameObject.GetComponent<SkeletonAnimation>();
      if (skeletonAnimation != null) {
        playerComponent.speedControlledAnimations.Add(skeletonAnimation);
      }

      var animator = gameObject.GetComponent<Animator>();
      if (animator != null) {
        playerComponent.speedControlledAnimators.Add(animator);
      }
    }
  }

  public static readonly TechTreeNode firstBody = new TechTreeNode {
    prefabs = new Dictionary<string, string> { { "Body", "Starter Body" } },
  };

  public static readonly TechTreeNode firstHead = new TechTreeNode {
    prefabs = new Dictionary<string, string> { { "Head", "Starter Head" } },
    children = new[] {
      new TechTreeNode {
        prefabs = new Dictionary<string, string> { { "Head", "Chompy Head" } },
      }
    }
  };

  public static readonly TechTreeNode firstGills = new TechTreeNode {
    prefabs = new Dictionary<string, string> { { "Gills", "Starter Gills" } },
    children = new[] {
      new TechTreeNode {
        prefabs = new Dictionary<string, string> { { "Gills", "Efficient Gills" } },
        children = new[] {
          new TechTreeNode {
            prefabs = new Dictionary<string, string> { { "Gills", "High Flow Gills" } },
          }
        }
      },
      new TechTreeNode {
        prefabs = new Dictionary<string, string> { { "Gills", "Basic Lungs" } },
        children = new[] {
          new TechTreeNode {
            prefabs = new Dictionary<string, string> { { "Gills", "Advanced Lungs" } },
            children = new[] {
              new TechTreeNode {
                prefabs = new Dictionary<string, string> { { "Gills", "Hyper Advanced Lungs" } },
              }
            }
          }
        }
      }
    }
  };

  public static readonly TechTreeNode firstTail = new TechTreeNode {
    prefabs = new Dictionary<string, string> {
      { "Tail", "Starter Tail" },
      { "Dorsal Fin", "Starter Dorsal Fin" },
      { "Arm Front Fin", "Starter Arm Front Fin" },
      { "Arm Back Fin", "Starter Arm Back Fin" },
    },
  };
}
