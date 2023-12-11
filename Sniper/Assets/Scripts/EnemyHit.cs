using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : ShotObjects
{
    public override void OnHit(RaycastHit hitInfo)
    {
        hitInfo.collider.gameObject.SetActive(false);
    }
}
