using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingText : MonoBehaviour
{
    public Text remaining;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        remaining.GetComponent<Text>().text = TargetBehavior.remaining.ToString();
    }
}
