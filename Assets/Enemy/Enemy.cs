using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 25;
    [SerializeField] int goldPenalty = 25;

    Bnak bnak;
    // Start is called before the first frame update
    void Start()
    {
        bnak = FindObjectOfType<Bnak>();
    }
    public void RewardGold()
    {
        if(bnak == null) { return; }
        bnak.Deposit(goldReward);
    }
    public void StealGold()
    {
        if (bnak == null) { return; }
        bnak.Withdraw(goldReward);
    }
}
