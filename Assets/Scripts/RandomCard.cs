using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomCard : MonoBehaviour
{
    //[SerializeField] Sprite[] suit;
    //[SerializeField] GameObject card;
    [SerializeField] List<GameObject> cards = new List<GameObject>();
    [SerializeField] List<GameObject> shuffledList = new List<GameObject>();
    [SerializeField] List<GameObject> discards = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("PickCard", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Shuffle();
            Debug.Log("Cards Shuffled");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(cards.Count > 0)
            {
                PickCard();
                Debug.Log("Card Drawn");
            }
            else 
            {
                Debug.Log("Out of Cards");
            }
            
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            discardToDraw();
        }
    }

    void PickCard()
    {
        GameObject destroy = Instantiate(cards[0], transform.position, Quaternion.identity);
        var selected = cards[0];
        cards.Remove(selected);
        discards.Insert(discards.Count, selected);
        Destroy(destroy, 1f);
    }

    void Shuffle()
    {
        shuffledList = cards.OrderBy(x => Random.value).ToList();
        cards.Clear();
        cards.AddRange(shuffledList);
        shuffledList.Clear();
    }
    
    void discardToDraw()
    {
        cards.AddRange(discards);
        discards.Clear();
    }
}
