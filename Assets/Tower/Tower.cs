using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay;

    void Start()
    {
        StartCoroutine(Build());
    }

    public bool CreateTower(Tower tower, Vector3 position)
    {
        Bnak bnak = FindObjectOfType<Bnak>();

        if(bnak == null) { return false; }

        if(bnak.CurrentBalance >= cost)
        {
            Instantiate(tower.gameObject, position, Quaternion.identity);
            bnak.Withdraw(cost);
            return true;
        }

        return false;
    }
    IEnumerator Build()
    {
        
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);

        }
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach (Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }

        }

    }
}
