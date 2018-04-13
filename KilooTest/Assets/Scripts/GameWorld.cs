using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameWorld : MonoBehaviour {

    public static GameWorld instance = null;           
    public Transform waypointPrefab;

    [HideInInspector]
    public List<Waypoint> waypointPath = new List<Waypoint>();

    private List<Vector2> finalVector2Path = new List<Vector2>();


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        //Initialize path of Waypoints
        GeneratePath();

        for (int i = 0; i < finalVector2Path.Count; i++)
        {
            Waypoint w = (Instantiate(waypointPrefab, new Vector3(finalVector2Path[i].x, -25, finalVector2Path[i].y), waypointPrefab.rotation) as Transform).GetComponent<Waypoint>();
            waypointPath.Add(w);
        }
    }


    private void GeneratePath()
    {

        //Span around origo
        int span = 10;

        //Choose amount of turnpoints
        int amountOfTurnPoints = Random.Range(span, span);
        List<Vector2> turnpoints = new List<Vector2>();

        //Generate positions for turnpoints
        for (int i = 0; i < amountOfTurnPoints; i++)
        {
            turnpoints.Add(new Vector2(Random.Range((i*2)-span, (i*2)+2-span), Random.Range(-span, span+1)));
        }

        //Sort turnpoints according to x
        Vector2[] sortedVectors = turnpoints.OrderBy(v => v.x).ToArray<Vector2>();

        turnpoints.Clear();
        turnpoints.AddRange(sortedVectors);

        //Add start and end turn points
        turnpoints.Insert(0, new Vector2(-span, turnpoints[0].y));
        turnpoints.Add(new Vector2(span, turnpoints[turnpoints.Count-1].y));

        //Setup starting point
        int x = (int)turnpoints[0].x;
        int y = (int)turnpoints[0].y;

        //Build path of vectors
        for (int i = 0; i < turnpoints.Count; i++)
        {
            while (x != (int)turnpoints[i].x)
            {
                finalVector2Path.Add(new Vector2(x, y));
                x++;
            }
            while (y != (int)turnpoints[i].y)
            {
                finalVector2Path.Add(new Vector2(x, y));
                int dist = ((int)turnpoints[i].y - y);
                y += dist / Mathf.Abs(dist);
            }
        }

        //Add last path vector
        finalVector2Path.Add(new Vector2(x, y));
    }
}
