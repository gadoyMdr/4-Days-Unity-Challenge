using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Yeet))]
public class OnHit : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem hitParticles;

    private Yeet _yeet;

    private void Awake() => _yeet = GetComponent<Yeet>();
    

    private void OnEnable() => _yeet.hitEvent += PlayOnHitVisuals;
    

    private void OnDisable() => _yeet.hitEvent -= PlayOnHitVisuals;
    

    void PlayOnHitVisuals()
    {
        PlayParticles();
    }

    void PlayParticles()
    {
        ParticleSystem newParticles = Instantiate(hitParticles, transform.position, Quaternion.identity, transform);
        newParticles.Play();
        killParticle(newParticles.main.duration, newParticles.gameObject);
    }

    IEnumerator killParticle(float time, GameObject particles)
    {
        yield return new WaitForSeconds(time);
        Destroy(particles.gameObject);
    }
}
