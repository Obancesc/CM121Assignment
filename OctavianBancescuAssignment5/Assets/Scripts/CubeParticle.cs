using UnityEngine;

public class CubeParticle : MonoBehaviour
{
    public GameObject Door1;

    private void OnTriggerEnter(Collider other)
    {
            var exp = GetComponent<ParticleSystem>();
            exp.Play();
            Door1.GetComponent<Animator>().Play("Open");

            Destroy(gameObject, exp.duration);
    }
}
