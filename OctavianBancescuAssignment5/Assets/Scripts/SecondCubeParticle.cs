using UnityEngine;

public class SecondCubeParticle : MonoBehaviour
{
    public GameObject doorObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "unitychan")
        {
            var exp = GetComponent<ParticleSystem>();
            exp.Play();
            doorObj.GetComponent<Animator>().Play("Open");

            Destroy(gameObject, exp.duration);
        }
    }
}
