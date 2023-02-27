using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerCollider : MonoBehaviour
{
    public Collider character;
    public Collider characterBlocker;

    void Start()
    {
        Physics.IgnoreCollision(character, characterBlocker, true);
    }

}
