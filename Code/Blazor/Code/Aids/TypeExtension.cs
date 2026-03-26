using System;

namespace Abc.Aids;

public static class TypeExtension
{
    public static bool isBool(this Type t)
    {
        return toUnderlying(t) == typeof(bool);
    }

    private static Type toUnderlying(Type t) =>
        t is null ? null : Nullable.GetUnderlyingType(t) ?? t;

    public static bool isString(this Type t) => t == typeof(string);
    public static bool isDate(this Type t) => t == typeof(DateTime) || t == typeof(DateOnly);
    public static bool isNumeric(this Type t)
    {
        t = toUnderlying(t);
        return t == typeof(byte) || t == typeof(sbyte) 
            || t == typeof(short) || t == typeof(ushort) 
            || t == typeof(int) || t == typeof(uint) 
            || t == typeof(long) || t == typeof(ulong) 
            || t == typeof(float) || t == typeof(double) 
            || t == typeof(decimal);
    }

}
