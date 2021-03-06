using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerBoxCollider : MonoBehaviour
{
    [SerializeField] private LaunchDagger daggerShooting;

    private bool hasHit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (daggerShooting.flyingTowardsEnemy)
        {
            if (collision.tag == "Player")
                return;

            if (collision.GetComponent<Enemy>() != null && !hasHit)
            {
                collision.GetComponent<Enemy>().health
                    .Damage(new Damage(1, Damage.PLAYER_DAGGER_ATTACK, daggerShooting.flyDirection));
                hasHit = true;
            }
            daggerShooting.flyingTowardsEnemy = false;
            daggerShooting.ResetTimer();
        }
        else if (collision.tag == "Player")
        {
            daggerShooting.DeleteDagger();
        }
    }
}
