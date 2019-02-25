using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    Dictionary<string, GameObject> pan;
    Stack<GameObject> acivePanels;
    bool isActive = false;
    bool wasButtonDown = false;


    // Start is called before the first frame update
    void Start()
    {
        pan = new Dictionary<string, GameObject>();
        acivePanels = new Stack<GameObject>();
        foreach (GameObject p in panels)
        {
            pan.Add(p.name, p);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Cancel"))
        {
            if (!wasButtonDown)
            {
                if (!isActive)
                {
                    isActive = true;
                    acivePanels.Push(pan["Main"]);
                    acivePanels.Peek().SetActive(true);
                }
                else
                {
                    ReturnToPrevPanel();
                }
            }
            wasButtonDown = true;
        }
        else
        {
            wasButtonDown = false;
        }
    }

    public void SelectPanel(string s)
    {

        acivePanels.Peek().SetActive(false);
        acivePanels.Push(pan[s]);
        acivePanels.Peek().SetActive(true);
    }

    public void ReturnToPrevPanel()
    {

        if (!acivePanels.Peek().Equals(pan["Main"]))
        {
            acivePanels.Pop().SetActive(false);
            acivePanels.Peek().SetActive(true);
        }
        else
        {
            isActive = false;
            acivePanels.Pop().SetActive(false);
        }
    }


}
