using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    [SerializeField] AudioClip coinSFX;
    [SerializeField] AudioClip powerupDoubleJump;
    [SerializeField] AudioClip powerupShield;
    [SerializeField] AudioClip ShieldBreak;
    [SerializeField] AudioClip DoubleJump;
    [SerializeField] AudioClip Jump;
    [SerializeField] AudioClip Land;
    [SerializeField] AudioClip GameOverHit;

    public void PlaySFX(string clipToPlay)
    {
        //if(clipToPlay == "Coin")
        //{
        //    audioSource.clip = coinSFX;
        //}

        switch(clipToPlay)
        {
            case "Coin":audioSource.clip = coinSFX;
            break;
            case "powerupDoubleJump":
                audioSource.clip = powerupDoubleJump;
                break;
            case "powerupShield":
                audioSource.clip = powerupShield;
                break;
            case "ShieldBreak":
                audioSource.clip = ShieldBreak;
                break;

            case "DoubleJump":
                audioSource.clip = DoubleJump;
                break;

            case "Jump":
                audioSource.clip = Jump;
                break;

            case "Land":
                audioSource.clip = Land;
                break;

            case "GameOverHit":
                audioSource.clip = GameOverHit;
                break;



        }
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
