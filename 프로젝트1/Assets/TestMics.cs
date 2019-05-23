using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError (Microphone.devices.Length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
