using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;
    private Vector3 playerOffset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        playerOffset = transform.position - target.position;
        
    }

    private void LateUpdate()
    {
        if (target != null) {
            transform.position = target.position + playerOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
