using UnityEngine;
using UnityEngine.InputSystem;

public class RoadManager : MonoBehaviour
{
    public GameObject roadPart;
    public Vector3 lastPosition;
    public float offSet = -0.4227404f;
    float fixedY = 0f;
    private int roadCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
    }

    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoad", 1f, 0.3f);

    }
    void Start()
    {

    }

    public void CreateNewRoad()
    {

        print(lastPosition);
        Vector3 spawnPos = Vector3.zero;
        float chance = Random.Range(0, 100);

        if (chance < 50)
        {
            spawnPos = new Vector3(lastPosition.x + offSet, fixedY, lastPosition.z + offSet);
        }
        else
        {
            spawnPos = new Vector3(lastPosition.x - offSet, fixedY, lastPosition.z + offSet);

        }

        GameObject newRoad = Instantiate(roadPart, spawnPos, Quaternion.Euler(0, 45, 0));
        lastPosition = newRoad.transform.position ;
        roadCount++;
        if (roadCount %  5 == 0)
        {
            newRoad.transform.GetChild(0).gameObject.SetActive(true);


        }


    }
}
