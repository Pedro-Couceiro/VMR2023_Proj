using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEmitter : MonoBehaviour
{
    private ParticleSystem _particleSystem;

    private void Start()
    {
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        if(_particleSystem == null) throw new Exception("No Particle System found in children of " + gameObject.name);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            _particleSystem.Play();
        }
        else
        {
            _particleSystem.Stop();
        }
    }
}
