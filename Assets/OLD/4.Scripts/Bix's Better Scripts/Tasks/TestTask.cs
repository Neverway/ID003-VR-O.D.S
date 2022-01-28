using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTask : MonoBehaviour
{
    
    public void Complete()
    {
        Debug.Log("Task Complete");
        GetComponent<TaskControl>().Completed = true;
    }
    public void Failed()
    {
        Debug.Log("Task Failed");

        GetComponent<TaskControl>().Completed = false;
    }
}
