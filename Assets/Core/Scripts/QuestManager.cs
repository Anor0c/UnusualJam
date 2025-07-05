using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public enum Quest
{
    SeLever = 0,
    PrendreCafé = 1,
    BrosserDents = 2,
    Travailler = 3,
    Manger = 4,
    Sport =5, 
    SeDoucher = 6,
    Dormir = 7

}
public class QuestManager : MonoBehaviour
{
    private Quest currentQuest;
    private int currentSubQuest;

    private SortedDictionary<Quest, int> MaxSubquest = new SortedDictionary<Quest, int>(); 

    void Start()
    {
        MaxSubquest.Add(Quest.SeLever, 1); 
        MaxSubquest.Add(Quest.PrendreCafé, 1); 
        MaxSubquest.Add(Quest.BrosserDents, 1); 
        MaxSubquest.Add(Quest.Travailler, 1); 
        MaxSubquest.Add(Quest.Manger, 1); 
        MaxSubquest.Add(Quest.Sport, 1); 
        MaxSubquest.Add(Quest.SeDoucher, 1); 
        MaxSubquest.Add(Quest.Dormir, 1); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
