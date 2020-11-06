using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerable
{
    bool isEmpty { get; set; }
    void Trigger();
}

public class EnemyThrow : MonoBehaviour, ITriggerable
{
    [SerializeField]
    private List<Weapon> weapons = new List<Weapon>();

    [SerializeField]
    private bool randomRotation = true;

    [SerializeField]
    private int amount;

    [SerializeField]
    private float width;

    [SerializeField]
    [Range(0, 0.3f)]
    private float timeDelay = 0.15f;

    public bool isEmpty { get; set; }

    private void Start()
    {
        isEmpty = false;
        amount = Random.Range((int)(amount * 0.50f), (int)((amount) * 1.5f));
    }

    public void Trigger()
    {
        StartCoroutine(SpawnWeapons());
    }

    IEnumerator SpawnWeapons()
    {
        isEmpty = true;
        for (int i = 0; i < amount; i++)
        {
            Weapon weapon = Instantiate(weapons[Random.Range(0, weapons.Count)],
            GetRandomDropPosition(),
            randomRotation ? Quaternion.Euler(transform.rotation.x, transform.rotation.y, Random.Range(130, 210)) : transform.rotation,
            null);
            ChangeSomeCharacteristicsToMakeWeaponFalls(weapon);

            yield return new WaitForSeconds(timeDelay);
        }
    }

    Vector3 GetRandomDropPosition() => 
        new Vector3(
        Random.Range(transform.position.x, transform.position.x + width * 2),
        transform.position.y,
        transform.position.z
    );

    void ChangeSomeCharacteristicsToMakeWeaponFalls(Weapon weapon)
    {
        if(weapon.TryGetComponent(out Rigidbody2D rb))
        {
            rb.mass = 1;
            rb.gravityScale = 1;
        }
    }
}
