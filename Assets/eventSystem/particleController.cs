using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleController : MonoBehaviour
{
    public static particleController instance;

    public GameObject[] particles;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void summonParticle(int particleIndex, Vector2 position, float duration)
    {
        GameObject particle = Instantiate(particles[particleIndex], position, Quaternion.identity);
        Destroy(particle, duration);
    }
}
