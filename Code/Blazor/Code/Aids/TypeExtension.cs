using System;

namespace Abc.Aids;

public static class TypeExtension
{
    public static bool isBool(this Type t) => t == typeof(bool);
    public static bool isString(this Type t) => t == typeof(string);
    public static bool isDate(this Type t) => t == typeof(DateTime) || t == typeof(DateOnly);
    public static bool isNumeric(this Type t)
    {
        if(t == null) return false;
        t = Nullable.GetUnderlyingType(t) ?? t;

        return t == typeof(byte) || t == typeof(sbyte) 
            || t == typeof(short) || t == typeof(ushort) 
            || t == typeof(int) || t == typeof(uint) 
            || t == typeof(long) || t == typeof(ulong) 
            || t == typeof(float) || t == typeof(double) 
            || t == typeof(decimal);
    }

}
