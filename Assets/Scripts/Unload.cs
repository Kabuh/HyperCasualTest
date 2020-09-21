using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unload : MonoBehaviour
{
    [SerializeField]
    private List<ParticleSystem> particleList;

    private void Awake()
    {
        StopUnload();
    }

    public void StartUnload() {
        foreach (ParticleSystem unit in particleList) {
            unit.Play();
        }
    }

    public void StopUnload()
    {
        foreach (ParticleSystem unit in particleList)
        {
            unit.Stop();
        }
    }
}
