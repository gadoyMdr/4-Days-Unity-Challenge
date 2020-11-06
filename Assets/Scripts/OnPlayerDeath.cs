using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDeath : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem ejectedParticles;

    private CanvasManager canvasManager;
    private Die playerDie;

    private void Awake()
    {
        playerDie = FindObjectOfType<PlayerManager>().GetComponent<Die>();
        canvasManager = FindObjectOfType<CanvasManager>();
    }

    private void OnEnable()
    {
        playerDie.dieEvent += ShowDeathCanvas;
    }

    private void OnDisable()
    {
        playerDie.dieEvent -= ShowDeathCanvas;
    }

    void ShowDeathCanvas()
    {
        PlayParticles();
        if (!canvasManager.GetCanvas(CanvasType.MainMenu).gameObject.activeInHierarchy)
        {
            canvasManager.ToggleCanvases(new List<CanvasType> { CanvasType.Death }, true);
        }
    }

    Quaternion CalculateSprayDirection()
    {
        return Quaternion.LookRotation(
                       Vector3.zero - transform.position
                     );
    }

    void PlayParticles()
    {
        ParticleSystem newParticles = Instantiate(ejectedParticles, transform.position, CalculateSprayDirection(), null);

        newParticles.Play();
        
        KillParticle(newParticles.main.duration, newParticles.gameObject);
    }

    IEnumerator KillParticle(float time, GameObject particles)
    {
        yield return new WaitForSeconds(time);
        Destroy(particles.gameObject);
    }
}
