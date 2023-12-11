using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMode : MonoBehaviour
{
    public static TriggerMode ModeInstance;
    public GameObject TriggerObject;
    public GameObject Canvas;
    public GameObject GunVfx;
    public bool canShoot = false;
    private void Awake()
    {
        if(ModeInstance != null && ModeInstance != this)
        {
            return; 
        }
        else
        {
            ModeInstance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "TriggerDetect")
        {
            GunVfx.SetActive(false);
            Canvas.SetActive(true);
            canShoot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "TriggerDetect")
        {
            GunVfx.SetActive(true);
            Canvas.SetActive(false);
            NewMethod();
        }
    }

    private void NewMethod()
    {
        canShoot = false;
    }
}
