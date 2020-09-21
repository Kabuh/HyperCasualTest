using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOrb : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem particles;

    [SerializeField]
    private MeshRenderer renderer;

    [SerializeField]
    OrbType myOrbType;

    [SerializeField]
    int myScore;

    private void Start()
    {
        particles.externalForces.AddInfluence(InputControlls.Player);
    }

    private void OnTriggerEnter(Collider other)
    {
        particles.Play();
        renderer.enabled = false;
        ScoreKeeper.Instance.AddScore(myScore, myOrbType);
        Destroy(gameObject, 3.0f);
    }

}
