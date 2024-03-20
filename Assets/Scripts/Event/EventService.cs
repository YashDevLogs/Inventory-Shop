using UnityEngine;

public class EventService
{
    private static EventService instance;
    public static EventService Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EventService();
            }
            return instance;
        }
    }

    public EventController OnItemBuy { get;  set; }
    public EventController OnItemSell { get; set; }

    public EventController OnItemDescriptionShow { get; private set; }

    public EventService()
    {
        OnItemBuy = new EventController();
        OnItemSell = new EventController();
        OnItemDescriptionShow = new EventController();
        Debug.Log("Event service Initialized");
    }
}