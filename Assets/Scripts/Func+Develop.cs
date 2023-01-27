using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class Func
{
    #region Print log func
    [System.Diagnostics.Conditional("DEBUG_MODE")]
   public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif // DEBUG_MODE
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Log(object message, Object context)
    {
#if DEBUG_MODE
        Debug.Log(message, context);
#endif // DEBUG_MODE
    }
    #endregion // Print log func

    #region Assert for debug
    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition, object message)
    {
#if DEBUG_MODE
        Debug.Assert(condition, message);
#endif // DEBUG_MODE
    }
    #endregion // Assert for debug

    #region vaild Func
    public static bool IsValid<T>(this T component_)
    {
       bool isVaild = component_.Equals(null) == false;
        return isVaild;
    }
    #endregion // vaile Func
}
