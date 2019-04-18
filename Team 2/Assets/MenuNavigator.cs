using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuNavigator : MonoBehaviour
{
    [SerializeField] GameObject[] panels;
    Dictionary<string, GameObject> pan;
    Stack<GameObject> activePanels;
    bool isActive = false;
    bool wasButtonDown = false;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
        pan = new Dictionary<string, GameObject>();
        activePanels = new Stack<GameObject>();
        foreach (GameObject p in panels)
        {
            pan.Add(p.name, p);
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Escape"))
        {
            if (activePanels.Count > 0)
            {
                if (manager.shopHandler.IsShopping)
                    manager.shopHandler.IsShopping = false;
                ReturnToPrevPanel();
            }
            else
            {
                activePanels.Push(pan["Main"]);
                activePanels.Peek().SetActive(true);
            }
        }
        else if (Input.GetButtonDown("Inventory"))
        {
            activePanels.Push(pan["Inventory"]);
            activePanels.Peek().SetActive(true);
        }
        else if (Input.GetButtonUp("Inventory"))
        {
            activePanels.Peek().SetActive(false);
            activePanels.Pop();

        }


    }

    public void SelectPanel(string s)
    {
        if (activePanels.Count > 0)
        {
            activePanels.Peek().SetActive(false);
        }
        activePanels.Push(pan[s]);
        activePanels.Peek().SetActive(true);
    }

    public void ReturnToPrevPanel()
    {
        if (activePanels.Count > 1)
        {
            activePanels.Pop().SetActive(false);
            activePanels.Peek().SetActive(true);
        }
        else
        {
            activePanels.Pop().SetActive(false);
        }
    }

    public void D(string s)
    {
        int c = 0;
        for(int i=0;i<s.Length;i++)
        {
            int j = 1;
            while(checkPal(s.Substring(i,j)))
            {
                c++;
                j++;
            }
        }

    }
    private bool checkPal(string s)
    {
        string tempC = s.Substring(0, 1);
        for(int i=0;i<s.Length/2;i++)
        {
            if(!(s.Substring(i,1)==s.Substring(s.Length-1-i,1)))
            {
                return false;
            }
        }
        return true;
    }



}
