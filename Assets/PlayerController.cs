using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform rayStart;
    private bool walkingRight = false;
    private Rigidbody rb;
    private GameManager gameManager;
    public GameObject crystalEffect;


    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();   
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }else
        {
            animator.SetTrigger("GameStarted");
        }
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            SwitchOrientation();
        }

        RaycastHit hit;

        if(!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            animator.SetTrigger("Falling");
        }
        else
        {
            animator.SetTrigger("NotFallingAnymore");
        }

        if(transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    public void SwitchOrientation()
    {
        if (!gameManager.gameStarted)
        {
            return;
        }

        walkingRight = !walkingRight;

        if (walkingRight)
        {
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 45, 0);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "crystal")
        {
            gameManager.IncreaseScore();
            GameObject effect = Instantiate(crystalEffect,rayStart.transform.position, Quaternion.identity);
            Destroy(effect,2);
            Destroy(other.gameObject);


        }
    }
}
