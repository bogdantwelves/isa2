using System;

namespace Abc.Aids;

public static class GetRandom{
    private static readonly Random r = Random.Shared;
    public static int Int32(int min = int.MinValue, int max = int.MaxValue) {
        if(min == max) return min;
        if(min > max) (min, max) = (max, min);
        return r.Next(min, max);
    }
    public static long Int64(long min = long.MinValue, long max = long.MaxValue) {
        if(min == max) return min;
        if(min > max) (min, max) = (max, min);
        return r.NextInt64(min, max);
    }
    public static sbyte Int8(sbyte min = sbyte.MinValue, sbyte max = sbyte.MaxValue) {
        if(min == max) return min;
        if(min > max) (min, max) = (max, min);
        return (sbyte)r.Next(min, max);
    }
    public static short Int16(short min = short.MinValue, short max = short.MaxValue) {
        if(min == max) return min;
        if(min > max) (min, max) = (max, min);
        return (short)r.Next(min, max);
    }
    public static double Double(double min = double.MinValue, double max = double.MaxValue) {
        if(min == max) return min;
        if(min > max) (min, max) = (max, min);
        return min + r.NextDouble() * (max - min);
    }
    public static byte UInt8(byte min = byte.MinValue, byte max = byte.MaxValue)
        => (byte) Int32(min, max);
    public static ushort UInt16(ushort min = ushort.MinValue, ushort max = ushort.MaxValue)
        => (ushort) Int32(min, max);
    public static uint UInt32(uint min = uint.MinValue, uint max = uint.MaxValue)
        => (uint) Int64(min, max);
    public static ulong UInt64(ulong min = ulong.MinValue, ulong max = ulong.MaxValue) {
        var minLong = (long) min - long.MaxValue;
        var maxLong = (long) max - long.MaxValue;
        return (ulong) (Int64(minLong, maxLong) + long.MaxValue);
    }
}

