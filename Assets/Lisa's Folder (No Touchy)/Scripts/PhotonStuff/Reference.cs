using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reference
{
    public AudioController audioController;

    public byte Id { get; set; }

    public static object Deserialize(byte[] data)
    {
        var result = new Reference();
        result.Id = data[0];
        return result;
    }

    public static byte[] Serialize(object customType)
    {
        var c = (Reference)customType;
        return new byte[] { c.Id };
    }
}
