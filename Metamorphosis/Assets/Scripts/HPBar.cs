using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField] GameObject health;
    void Start()
    {
        health.transform.localScale = new Vector3(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
