﻿using UnityEngine;
using System.Collections;

public class EnemyHurt : MonoBehaviour
{
    public int enemyHealth = 5;

    Animator animator;

    AudioSource[] audioSources;

    AudioClip laserImpactSound;

    AudioClip explosionSound;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSources = GetComponents<AudioSource>();
        laserImpactSound = audioSources[0].clip;
        explosionSound = audioSources[1].clip;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("ShipBullet"))
        {
            enemyHealth -= 1;
            animator.SetTrigger("Damaged");
            audioSources[0].PlayOneShot(laserImpactSound);
            if (enemyHealth == 0)
            {
                ShipShoot.multiplierTimer = 4.0f;
                AudioSource.PlayClipAtPoint(laserImpactSound,
                new Vector2(0, 0));
                AudioSource.PlayClipAtPoint(explosionSound, new Vector2(0, 0));
                Destroy(gameObject);
                if (ShipShoot.multiplier < ShipShoot.maxMultiplier)
                {
                    ShipShoot.multiplier++;
                }
            }
        }
    }
}