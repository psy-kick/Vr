using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public float speed = 12f;
    public GameObject BulletPrefab;
    public Transform SpawnPoint;
    public float ShootSpeed;
    public float Gravity;
    public float BulletLife;
    public InputActionProperty Fire;
    // Update is called once per frame
    void Update()
    {
        float Trigger = Fire.action.ReadValue<float>();
        if(Trigger > 0)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
        ParabolaMotion BulletScript = Bullet.GetComponent<ParabolaMotion>();
        if (BulletScript)
        {
            BulletScript.Initialized(SpawnPoint, Gravity, ShootSpeed);
            //BulletScript.StartCoroutine(BulletScript.ShotBullet(groundDirection.normalized, InitialVelocity, angle));
            //BulletScript.StartCoroutine(BulletScript.RayParabola(ShootSpeed));
        }
        Destroy(Bullet, BulletLife);
        //Vector3 ScreenCenter = new Vector3(0.5f, 0.5f, 0f);
        //RaycastHit hit;
        //Ray ray = cam.ViewportPointToRay(ScreenCenter);
        //Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 1.0f);
        //if (Physics.Raycast(ray, out hit))
        //{
        //    Debug.Log(hit.collider.gameObject.name);
        //    if (hit.collider.gameObject.tag == "Wall")
        //    {
        //        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green, 1.0f);
        //    }
        //}
    }
    // Start is called before the first frame update
    void Start()
    {

    }
}

