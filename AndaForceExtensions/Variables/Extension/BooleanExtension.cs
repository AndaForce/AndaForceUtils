using System;

namespace AndaForceUtils.Variables.Extension
{
    public static class BooleanExtension
    {
        public static String ToHumanString(this bool value)
        {
            return value
                ? "Yes"
                : "No";
        }
    }
}