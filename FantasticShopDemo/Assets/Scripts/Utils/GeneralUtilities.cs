using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GeneralUtilities
{
    public static T Get<T>(ScriptableObject item)
    {
        if (item is T interfaceType)
        {
            
            return interfaceType;
        }
        return default(T);
    }
}
