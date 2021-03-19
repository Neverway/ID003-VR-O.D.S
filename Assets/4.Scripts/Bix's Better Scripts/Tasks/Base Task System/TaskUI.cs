using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskUI : MonoBehaviour
{
    public TaskManager manager;
    public Transform parent;
    public GameObject TextPrefab;
    public float checkDelay= 1f;
    private List<Text> TaskTexts = new List<Text>();
    void Start()
    {
        for (int i = 0; i < manager.Tasks.Length;i++)
        {
            GameObject curText = Instantiate(TextPrefab, parent);
            curText.GetComponent<Text>().text = manager.Tasks[i].GetComponent<TaskControl>().TaskName;
            curText.GetComponent<Text>().color = Color.red;
            TaskTexts.Add(curText.GetComponent<Text>());
            StartCoroutine("checkTask");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator checkTask()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkDelay);
            for (int i = 0; i < manager.Tasks.Length;i++)
            {
                if (manager.Tasks[i].GetComponent<TaskControl>().Completed)
                {
                    TaskTexts[i].color = Color.green;
                }
                else
                {
                    TaskTexts[i].color = Color.red;
                }
            }
        }

    }
}
