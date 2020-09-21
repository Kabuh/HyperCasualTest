using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private void Awake()
    {
        InputControlls.Player = this.gameObject.GetComponent<ParticleSystemForceField>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * speed;
    }
}
