using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AnimateHands : MonoBehaviour
{
    public InputActionProperty PinchAnim;
    public InputActionProperty GripAnim;
    public Animator HandAnims;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float Pinchtrigger = PinchAnim.action.ReadValue<float>();
        HandAnims.SetFloat("Trigger", Pinchtrigger);
        float Griptrigger = GripAnim.action.ReadValue<float>();
        HandAnims.SetFloat("Grip", Griptrigger);
    }
}
