using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class AudioCP : MonoBehaviour
{

    [SerializeField] AudioSource footstepsAudioSources = null;
    [Header("Audio clips")]
    [SerializeField] AudioClip[] softSteps = null;
    [SerializeField] AudioClip[] hardSteps = null;

    [Header("Steps")]
    [SerializeField] float timer = 0.5f;

    //private float stepsTimer;

    //public void PlaySteps(GroundType groundType, float speedNormalized)
    //{

      //  if (groundType == groundType.Nome)
        //    return;
        //stepsTimer += Time.fixedDeltaTime * speedNormalized;
        //if (stepsTimer > timer)
        //{
          //  var steps = groundType == groundType.Hard ? hardSteps : softSteps;
            //int index = Random.Range(0, steps.Length);
            //footstepsAudioSources.PlayOneShot(steps[index]);
            //stepsTimer = 0;
        }

    //}
//
//}