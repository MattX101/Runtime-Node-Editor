using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Vector3FlatArrayBuilderNode : Node
    {
        protected override void CodeToExecute()
        {
            MultiConnectionInputPointer multi = GetMulti(0);
            if (IsValid(multi))
            {
                Vector3ArrayOutputPointer outputArray = outputs[0].GetComponent<Vector3ArrayOutputPointer>();
                outputArray.values = new Vector3[GetArrayLength(multi)];

                for (int pointerIndex = 0, arrayIndex = 0; pointerIndex < multi.connectedOutputPointers.Count; pointerIndex++)
                {
                    if (multi.connectedOutputPointers[pointerIndex].pointerType == Pointer.Type.PointerType.Array)
                    {
                        Vector3ArrayOutputPointer array = multi.connectedOutputPointers[pointerIndex].GetComponent<Vector3ArrayOutputPointer>();

                        if (array.values == null)
                            continue;

                        for (int valuesIndex = 0; valuesIndex < array.values.Length; valuesIndex++, arrayIndex++)
                            outputArray.values[arrayIndex] = array.values[valuesIndex];

                        continue;
                    }

                    outputArray.values[arrayIndex] = PointerValue.GetVector3(multi.connectedOutputPointers[pointerIndex]);
                    arrayIndex++;
                }
            }
        }

        private int GetArrayLength(MultiConnectionInputPointer multi)
        {
            int arrayLength = 0;

            for (int pointerIndex = 0; pointerIndex < multi.connectedOutputPointers.Count; pointerIndex++)
            {
                multi.connectedOutputPointers[pointerIndex].node.Execute();

                if (multi.connectedOutputPointers[pointerIndex].pointerType == Pointer.Type.PointerType.Array)
                {
                    Vector3ArrayOutputPointer array = multi.connectedOutputPointers[pointerIndex].GetComponent<Vector3ArrayOutputPointer>();
                    array.node.Execute();

                    arrayLength += array.values == null ? 0 : array.values.Length;
                    continue;
                }

                arrayLength++;
            }

            return arrayLength;
        }
    }
}
