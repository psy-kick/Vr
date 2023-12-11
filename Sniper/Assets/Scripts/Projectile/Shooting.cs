using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class Shooting : MonoBehaviour
{
    public float speed = 12f;
    public GameObject BulletPrefab;
    public Transform SpawnPoint;
    public float ShootSpeed;
    public float Gravity;
    public float BulletLife;
    [HideInInspector]
    public InputAction RightTrigger;
    [SerializeField]
    private ActionBasedController RightHandController;
    public AudioSource Shootaudio;
    // Start is called before the first frame update
    void Start()
    {
        RightTrigger = RightHandController.activateAction.reference;
    }
    // Update is called once per frame
    void Update()
    {
        if(RightTrigger.IsPressed() && TriggerMode.ModeInstance.canShoot)
        {
            Shoot();
            Shootaudio.Play();
        }
    }
    private void Shoot()
    {
        GameObject Bullet = Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
        ParabolaMotion BulletScript = Bullet.GetComponent<ParabolaMotion>();
        if (BulletScript)
        {
            BulletScript.Initialized(SpawnPoint, Gravity, ShootSpeed);
        }
        Destroy(Bullet, BulletLife);
    }
}

