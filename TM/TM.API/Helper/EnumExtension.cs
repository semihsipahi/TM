﻿namespace TM.API.Helper
{
    public class EnumValue
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }

    public static class EnumExtension
    {
        public static List<EnumValue> GetValues<T>()
        {
            List<EnumValue> values = [];
            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                //For each value of this enumeration, add a new EnumValue instance
                values.Add(new EnumValue()
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Value = (int)itemType
                });
            }
            return values;
        }
    }
}
