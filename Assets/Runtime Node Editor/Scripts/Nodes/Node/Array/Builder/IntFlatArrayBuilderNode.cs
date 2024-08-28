using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class IntFlatArrayBuilderNode : Node
    {
        protected override void CodeToExecute()
        {
            MultiConnectionInputPointer multi = GetMulti(0);
            if (IsValid(multi))
            {
                IntArrayOutputPointer outputArray = outputs[0].GetComponent<IntArrayOutputPointer>();
                outputArray.values = new int[GetArrayLength(multi)];

                for (int pointerIndex = 0, arrayIndex = 0; pointerIndex < multi.connectedOutputPointers.Count; pointerIndex++)
                {
                    if (multi.connectedOutputPointers[pointerIndex].pointerType == Pointer.Type.PointerType.Array)
                    {
                        IntArrayOutputPointer array = multi.connectedOutputPointers[pointerIndex].GetComponent<IntArrayOutputPointer>();

                        if (array.values == null)
                            continue;

                        for (int valuesIndex = 0; valuesIndex < array.values.Length; valuesIndex++, arrayIndex++)
                            outputArray.values[arrayIndex] = array.values[valuesIndex];

                        continue;
                    }

                    outputArray.values[arrayIndex] = PointerValue.GetInt(multi.connectedOutputPointers[pointerIndex]);
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
                    IntArrayOutputPointer array = multi.connectedOutputPointers[pointerIndex].GetComponent<IntArrayOutputPointer>();
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
