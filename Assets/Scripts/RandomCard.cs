using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomCard : MonoBehaviour
{
    //[SerializeField] Sprite[] suit;
    //[SerializeField] GameObject card;
    [SerializeField] GameObject[] destroy;
    [SerializeField] GameObject[] selected;
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
            if(cards.Count > 10)
            {
                PickCard();
                Debug.Log("Card Drawn");
            }else if (cards.Count <= 10)
            {
                discardToDraw();
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
        for (int i = 0; i <= 4; i++)
        {
            destroy[i] = Instantiate(cards[i], transform.position + new Vector3(i*2,0,0), Quaternion.identity);
            selected[i] = cards[i];
            cards.Remove(selected[i]);
            discards.Insert(0, selected[i]);
        }
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
