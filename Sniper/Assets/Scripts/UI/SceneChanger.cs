using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject Menu;
    public GameObject About;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PLayScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void AboutSection()
    {
        Menu.SetActive(false);
        About.SetActive(true);
    }
    public void OnValidate()
    {
        Menu.SetActive(true);
        About.SetActive(false);
    }
}
