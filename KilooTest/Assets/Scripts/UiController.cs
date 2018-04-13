using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour {
    public static UiController instance;
    public Text UIText;
    public InputField InpField;
    public Agent agent;
    void Awake() {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

        InpField.onValueChanged.AddListener(delegate { ChangeText(); });
    }

    /*
     *    mainInputField.onValueChange.AddListener(delegate {ValueChangeCheck(); });
    }

    // Invoked when the value of the text field changes.
    public void ValueChangeCheck()
    {
        Debug.Log("Value Changed");
    }
     * 
     * 
     * */

    void ChangeText() {
        if (InpField.text != "Enter Speed")
        {
            float speed;
            bool isNnumber = float.TryParse(InpField.text, out speed);

            if (isNnumber)
            {
                agent.SetSpeed(speed);
            }
            else
            {
                InpField.text = "Enter Speed";
            }
        }
    }
	// Use this for initialization
	void Start () {
        agent = GameObject.Find("AgentMan").GetComponent<Agent>();
	}

    public void SetUIText(string txt) {
        UIText.text = txt;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
