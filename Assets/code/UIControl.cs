using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public List<GameObject> icons;
    public List<Vector3> positions;
    public Canvas parentCanvas;

    public Vector3 scael;
    
    public int[] orderValue;
    
    private List<GameObject> living;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scael = new Vector3(0.3f, 0.3f, 0.3f);
        living = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {   
        orderValue = gameFlow.orderValue;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClearNotepad();
            PopulateOrder(orderValue);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            ClearNotepad();
        }
    }

    public void PopulateOrder(int[] order)
    {
        int iconNumber = 0;
        
        for (int i = 0; i < order.Length; i++)
        {
            for (int j = 0; j < order[i]; j++)
            {
                //GameObject.Instantiate(icons[i], positions[iconNumber], Quaternion.identity);
                GameObject temp = GameObject.Instantiate(icons[i]);
                temp.transform.SetParent(parentCanvas.transform);
                temp.transform.localPosition = positions[iconNumber];
                temp.transform.localScale = scael;
                living.Add(temp);
                iconNumber++;
            }
        }
    }

    public void ClearNotepad()
    {
        for (int i = living.Count - 1; i >= 0; i--)
        {
            Destroy(living[i]);
        }
        
        living.Clear();
    }
}
