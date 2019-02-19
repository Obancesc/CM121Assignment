using UnityEngine;

public class BasicMovementTestnotfinal : MonoBehaviour
{
    Rigidbody rigid;
    public int count = 0;
    public GameObject cameraone;
    public GameObject cameratwo;
    public GameObject camerafour;
    public Transform player;
    public GameObject doorone;

    public float forwardSpeed = 4.0F;
    public float backwardSpeed = 2.5F;
    public float rotateSpeed = 2.5F;
    public float animSpeed = 1.5F;

    private Vector3 velo;
    private Animator anim;
    public Animator dooranim;
    private AnimatorStateInfo currentState;

    static int locoState = Animator.StringToHash("Base Layer.Locomotion");

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        cameraone.SetActive(true);
        cameratwo.SetActive(false);
        camerafour.SetActive(false);

        anim = GetComponent<Animator>();
       // Application.LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        anim.SetFloat("Speed", v);
        anim.SetFloat("Direction", h);
        anim.speed = animSpeed;
        //currentState = anim.GetCurrentAnimatorStateInfo(0);

        velo = new Vector3(0, 0, v);
        velo = transform.TransformDirection(velo);
        if (v > 0.1)
        {
            velo *= forwardSpeed;
        }
        else if (v < -0.1)
        {
            velo *= backwardSpeed;
        }

        transform.localPosition += velo * Time.fixedDeltaTime;
        transform.Rotate(0, h * rotateSpeed, 0);

        if(count == 3)
        {
            Application.LoadLevel(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "DoorTrigger")
        {
            Debug.Log("We hit the square thingy: new room, new camera");
            cameraone.SetActive(false);
            camerafour.SetActive(false);
            cameratwo.SetActive(true);
        }

        if(other.gameObject.name == "DoorTrigger2")
        {
            Debug.Log("We hit the square thingy: Back to room one");
            cameratwo.SetActive(false);
            cameraone.SetActive(true);
        }

        if(other.gameObject.name == "DoorTrigger3")
        {
            Debug.Log("New room, same me");
            cameratwo.SetActive(false);
            camerafour.SetActive(true);
        }

        if(other.gameObject.name == "Cube")
        {
            count++;

            Debug.Log("Unity-chan, you got the cube thingy");
        }

        if(other.gameObject.name == "Cube2")
        {
            count++;
            Debug.Log("Unity-chan got the second cube thingy");
        }

        if(other.gameObject.name == "Cube3")
        {
            count++;
            Debug.Log("Game Over. Time for Main Menu");
        }
    }
}
