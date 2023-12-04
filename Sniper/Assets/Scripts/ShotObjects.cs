using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShotObjects : MonoBehaviour
{
    public abstract void OnHit(RaycastHit hitInfo);
}
