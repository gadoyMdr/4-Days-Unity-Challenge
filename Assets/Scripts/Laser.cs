using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private Transform laserMuzzle;

    [SerializeField]
    private GameObject laserVisual;

    [SerializeField]
    private float timeOn;

    [SerializeField]
    private float timeOff;

    private bool isOn;

    private ITriggerable weaponToTrigger;

    private void Awake()
    {
        weaponToTrigger = GetComponent<ITriggerable>();
    }

    private void Start()
    {
        StartCoroutine(TurnOnLaser());
        RandomizeStats();
    }

    void RandomizeStats()
    {
        timeOn = timeOn.BeRandom(0.8f);
        timeOff = timeOff.BeRandom(0.8f);
    }

    void Update()
    {
        if (ThrowLaser() && !weaponToTrigger.isEmpty && isOn) weaponToTrigger.Trigger();
    }

    IEnumerator TurnOnLaser()
    {
        ToggleLaser(true);
        yield return new WaitForSeconds(timeOn);
        StartCoroutine(TurnOffLaser());
    }

    IEnumerator TurnOffLaser()
    {
        ToggleLaser(false);
        yield return new WaitForSeconds(timeOff);
        StartCoroutine(TurnOnLaser());
    }

    void ToggleLaser(bool value)
    {
        isOn = value;
        laserVisual.SetActive(value);
    }

    bool ThrowLaser()
    {
        RaycastHit2D[] hit = Physics2D.LinecastAll(laserMuzzle.position, -laserMuzzle.up * 50);

        return hit.Any(x => x.collider.gameObject.name.Equals("Player"));
    }
}
