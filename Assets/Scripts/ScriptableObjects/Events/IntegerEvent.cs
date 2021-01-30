using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event (Integer)", menuName = "Events/Game Event (Integer)")]
public class IntegerEvent : GenericEvent<int>
{
    public static IntegerEvent operator +(IntegerEvent @event, System.Action<int> @func)
    {
        @event._event += @func;
        return @event;
    }

    public static IntegerEvent operator -(IntegerEvent @event, System.Action<int> @func)
    {
        @event._event -= @func;
        return @event;
    }
}
