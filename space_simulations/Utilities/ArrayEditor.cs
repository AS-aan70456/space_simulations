using System;

namespace space_simulations.Utilities{
    static class ArrayEditor{
        static public void addObject<T>(ref T[] ArrayObject, T newObject, int index){
            T[] newArrayObject = new T[ArrayObject.Length + 1];

            for (int i = 0; i < index; i++)
                newArrayObject[i] = ArrayObject[i];

            for (int i = index; i < ArrayObject.Length; i++)
                newArrayObject[i + 1] = ArrayObject[i];

            newArrayObject[index] = newObject;
            ArrayObject = newArrayObject;
        }
        static public void removeObject<T>(ref T[] ArrayObject, int index){
            T[] newArrayObject = new T[ArrayObject.Length - 1];

            for (int i = 0; i < index; i++)
                newArrayObject[i] = ArrayObject[i];

            for (int i = index + 1; i < ArrayObject.Length; i++)
                newArrayObject[i - 1] = ArrayObject[i];

            ArrayObject = newArrayObject;
        }
    }
}
