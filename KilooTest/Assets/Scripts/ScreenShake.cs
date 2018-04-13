using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    public float Trauma = 0;
    public float Shake = 0;
        public float Decay = 0.01f;
    public float MxOffset = 0.3f;
    Vector3 origPos;
    public bool PerlinEffect = true;
    public bool ToggleDamage = true;
    public void StartShake() {


    }
    float makeRandom() {
        float res = Random.Range(-1,2);
        res += Random.Range(-1, 2) * Random.value;

        return res;

    }
	// Use this for initialization
	void Start () {
        
        for (int i = 0; i < 100; i++)
        {
            float yOffset = MxOffset * Shake * Mathf.PerlinNoise(makeRandom(), makeRandom());
            Debug.Log(yOffset);
        }

        origPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (ToggleDamage)
        {
            Trauma = 0.4f;
        }
        if (Input.GetKeyDown("1"))
        {
            Trauma += 0.2f;
        }

        if (Input.GetKeyDown("2"))
        {
            Trauma += 0.4f;
        }
        
        if (Input.GetKeyDown("3"))
        {
            Trauma += 0.6f;
        }

        Shake = Trauma* Mathf.Exp(3);

        if (Trauma>0)
        {
            Trauma -= Decay;// * Time.deltaTime;
        }
        else
        {
            Trauma = 0;
            transform.position = origPos;
        }
        //Maxoffset * shake * randbetween(-1 +1)
        //This is with the random shit
        float yOffset = MxOffset * Shake * Random.Range(-1, 2);
        float xOffset = MxOffset * Shake * Random.Range(-1, 2);
        if (!PerlinEffect)
        {
        transform.position += new Vector3(xOffset,yOffset, 0);
        }

        // Try with perlin
        //maxOfs* shake *GetPerlinNoise
        float rnd = 1;
        float rnd2 = 1;

        if (Random.Range(0,2) == 0)
        {
            rnd = -1;
        }

        if (Random.Range(0,2) == 0)
        {
            rnd2 = -1;
        }


        yOffset = MxOffset * Shake * Mathf.PerlinNoise(makeRandom(), makeRandom()) *rnd;
        xOffset = MxOffset * Shake * Mathf.PerlinNoise(makeRandom(), makeRandom())* rnd2;

        if (PerlinEffect)
        {

        transform.position += new Vector3(xOffset,yOffset, 0);
        }



    }

    public void ScreenShakeMakesEverythingBetter() {
        Trauma += 0.2f;

    }
}
