using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
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
}
