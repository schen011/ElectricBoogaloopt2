using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlay : MonoBehaviour
{

// expose reference to the happy particle system, makes it null since it already is null

    [SerializeField] ParticleSystem HappyParticles = null; // boxes to hold particles
    [SerializeField] ParticleSystem AngyParticles = null;

   

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.O)) // if happy play the particle

        {

            HappyCollect();
            Debug.Log("wow");

        }

        else if (Input.GetKeyDown(KeyCode.J)) // if angry play the particle
        {

            AngyCollect();
            Debug.Log("grrr");

        }

    }

    /// methods that play the particles
    public void HappyCollect()
    {
    
        HappyParticles.Play();


    }

    public void AngyCollect()
    {

        AngyParticles.Play();

    }

}
