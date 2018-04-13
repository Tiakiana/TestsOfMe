using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour {
    public float Speed;
    float lastSpeed;
    public Transform Target;
    int currentTarget = -1;
	// Use this for initialization
	
    void GetNextTarget() {
        if (Target)
        {
        UiController.instance.SetUIText(GameWorld.instance.waypointPath[currentTarget].GetDescription());

        }
        currentTarget++;
        if (currentTarget == GameWorld.instance.waypointPath.Count)
        {

            transform.position = GameWorld.instance.waypointPath[0].transform.position;
            currentTarget = 0;
            UiController.instance.SetUIText(GameWorld.instance.waypointPath[currentTarget].GetDescription());

        }
        Target = GameWorld.instance.waypointPath[currentTarget].transform;

    }

    public void SetSpeed(float spd) {

        Speed = spd;
    }

    public void StopAgent() {
        lastSpeed = Speed;
        Speed = 0;

    }

    public void StartAgent() {
        Speed = lastSpeed;
    }

    public void RestartAgent() {
        transform.position = GameWorld.instance.waypointPath[0].transform.position;
        currentTarget = 0;
        Target = GameWorld.instance.waypointPath[0].transform;
    }

    // Update is called once per frame

    void Start()
    {
        lastSpeed = Speed;
        GetNextTarget();
        transform.position = GameWorld.instance.waypointPath[currentTarget].transform.position;
    }

    void Update () {
        if (Target)
        {

        transform.position = Vector3.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position,Target.position)<0.01f)
        {
            GetNextTarget();
        }

	}
}
