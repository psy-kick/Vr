using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaMotion : MonoBehaviour
{
    float Speed;
    float Gravity;
    Vector3 StartPos;
    Vector3 StartForward;
    bool isInitialized = false;
    float StartTime = -1;
    //private void Start()
    //{
    //    float angle = Angle * Mathf.Deg2Rad;
    //}
    //public IEnumerator ShotBullet(Vector3 direction, float v0, float angle)
    //{
    //    float t = 0;

    //    while (t < 100)
    //    {
    //        float x = v0 * t * Mathf.Cos(angle);
    //        float y = (float)(v0 * t * Mathf.Sin(angle) - (0.5) * Gravity * Mathf.Pow(t, 2));
    //        transform.position = (SpawnPoint.position + direction * x + Vector3.up * y);
    //        t += Time.deltaTime * Speed;
    //        yield return null;
    //    }
    //}
    public void Initialized(Transform spawnPoint, float gravity, float speed)
    {
        StartPos = spawnPoint.position;
        StartForward = spawnPoint.forward.normalized;
        this.Speed = speed;
        this.Gravity = gravity;
        isInitialized = true;
    }
    //public IEnumerator RayParabola(float speed)
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);
    //    RaycastHit hit;
    //}
    private void FixedUpdate()
    {
        if (!isInitialized)
        {
            return;
        }
        if (StartTime < 0)
        {
            StartTime = Time.time;
        }
        RaycastHit hit;
        float CurrentTime = Time.time - StartTime;
        float PrevTime = CurrentTime - Time.fixedDeltaTime;
        float NextTime = CurrentTime + Time.fixedDeltaTime;
        Vector3 CurrentPoint = FindPoint(CurrentTime);
        Vector3 NextPoint = FindPoint(NextTime);
        if (PrevTime > 0)
        {
            Vector3 PrevPoint = FindPoint(PrevTime);
            if (CastRay(PrevPoint, NextPoint, out hit))
            {
                //ShotObjects shotObjects = hit.transform.GetComponent<ShotObjects>();
                //shotObjects.OnHit(hit);
            }
        }
        if (CastRay(CurrentPoint, NextPoint, out hit))
        {
            //ShotObjects shotObjects = hit.transform.GetComponent<ShotObjects>();
            //if (shotObjects)
            //{
            //    shotObjects.OnHit(hit);
            //}
            Destroy(gameObject);
        }
    }
    private Vector3 FindPoint(float time)
    {
        Vector3 point = StartPos + (StartForward * Speed * time);
        Vector3 GravityAcr = Vector3.down * Gravity * time * time * 0.5f;
        return point + GravityAcr;
    }
    private bool CastRay(Vector3 StartPoint, Vector3 EndPoint, out RaycastHit hit)
    {
        return Physics.Raycast(StartPoint, EndPoint - StartPoint, out hit, (EndPoint - StartPoint).magnitude);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (!isInitialized || StartTime < 0)
        {
            return;
        }
        float CurrentTime = Time.time - StartTime;
        Vector3 CurrentPoint = FindPoint(CurrentTime);
        transform.position = CurrentPoint;
    }
}
