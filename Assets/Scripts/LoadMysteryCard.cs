using UnityEngine;
using System.Collections;

public class LoadMysteryCard : MonoBehaviour
{
    void Start()
    {
        LoadCard();
    }

    public void LoadCard()
    {
        Deserializer<MysteryCard> loadMysteryCard = new Deserializer<MysteryCard>();

        loadMysteryCard.Deserialization("Bigfoot");
    }
}
