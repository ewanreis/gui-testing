using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelManagerScript : MonoBehaviour
{
    public GameObject startButton;
    // Start is called before the first frame update
    void Start()
    {
        startButton.GetComponent<Button>().Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
