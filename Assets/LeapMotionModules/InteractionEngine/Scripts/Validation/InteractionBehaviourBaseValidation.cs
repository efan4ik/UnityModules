﻿using UnityEngine.Assertions;

namespace Leap.Unity.Interaction {

  public partial class InteractionBehaviourBase {
    
    public override void Validate() {
      Assert.AreEqual(isActiveAndEnabled, _isRegisteredWithManager,
                     "Must only active and enabled if registered with manager.");

      if (_hasShapeDescriptionBeenCreated) {
        Assert.IsTrue(_isRegisteredWithManager,
                      "If shape description is enabled, must be registered with manager.");
      }

      if (_hasShapeInstanceHandle) {
        Assert.IsTrue(_isRegisteredWithManager,
                      "If has a shape instance, must be registered with manager.");
      }

      foreach (var untrackedId in _untrackedIds) {
        Assert.IsTrue(_graspingIds.Contains(untrackedId),
                      "All untracked ids must be considered grasping.");
      }
    }

  }
}