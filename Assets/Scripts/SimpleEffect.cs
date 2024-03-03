using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class SimpleEffect : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DieOnTimer(GetComponent<ParticleSystem>().main.startLifetime.constant));
    }

    IEnumerator DieOnTimer(float timer)
    {
        yield return new WaitForSeconds(timer);
        Destroy(gameObject);
    }
}
