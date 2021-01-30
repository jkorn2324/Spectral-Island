using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Game Event (String)", menuName = "Events/Game Event (String)")]
public class StringEvent : GenericEvent<string>
{
    public static StringEvent operator+(StringEvent @event, System.Action<string> @func)
    {
        @event._event += @func;
        return @event;
    }

    public static StringEvent operator-(StringEvent @event, System.Action<string> @func)
    {
        @event._event -= @func;
        return @event;
    }
}
