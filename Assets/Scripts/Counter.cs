using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    int steps=0;
    List<GameObject> doors = new List<GameObject>();
    public delegate void ThirdStepDelegate();
    public event ThirdStepDelegate ThirdStepEvent;
    public void Step()
    {
        steps++;
        if(steps==3 && ThirdStepEvent!=null)
        {
            steps = 0;
            ThirdStepEvent.Invoke();
        }
        TextMeshProUGUI text = gameObject.GetComponent<TextMeshProUGUI>();
        text.text = "Steps: " + steps;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
