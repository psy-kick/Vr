using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallHit : ShotObjects
{
    public override void OnHit(RaycastHit hitInfo)
    {
        Debug.Log("this works");
        Debug.Log(hitInfo.collider.gameObject.name);
    }
}
