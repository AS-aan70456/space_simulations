using System;

namespace space_simulations.Utilities{
    static class ArrayEditor{
        static public T[] addObject<T>(T[] ArrayObject, T newObject){
            T[] newArrayObject = new T[ArrayObject.Length + 1];

            for (int i = 0; i < ArrayObject.Length; i++)
                newArrayObject[i] = ArrayObject[i];

            newArrayObject[ArrayObject.Length + 1] = newObject;
            return newArrayObject;
        }
        static public T[] removeObject<T>(T[] ArrayObject, int index){
            T[] newArrayObject = new T[ArrayObject.Length - 1];

            for (int i = 0; i < index; i++)
                newArrayObject[i] = ArrayObject[i];

            for (int i = index + 1; i < ArrayObject.Length; i++)
                newArrayObject[i - 1] = ArrayObject[i];

            return newArrayObject;
        }
    }
}
