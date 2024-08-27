using RuntimeNodeEditor.Nodes.Pointer;
using RuntimeNodeEditor.Nodes.Pointer.Value;
using RuntimeNodeEditor.Functions.UI.Elements;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Nodes.Node
{
    public class Node : MonoBehaviour
    {
        private bool _wasExecuted;
        public bool endNode = false;

        public readonly List<InputPointer> inputs = new();
        public readonly List<OutputPointer> outputs = new();

        public NodeUIElements Elements;

        public void AddPointer(InputPointer inputPointer, ValueType valueType, Pointer.Type.PointerType pointerType = Pointer.Type.PointerType.Variable)
        {
            inputPointer.node = this;
            inputPointer.valueType = valueType;
            inputPointer.pointerType = pointerType;

            inputs.Add(inputPointer);
        }
        public void AddPointer(OutputPointer outputPointer, ValueType valueType, Pointer.Type.PointerType pointerType = Pointer.Type.PointerType.Variable)
        {
            outputPointer.node = this;
            outputPointer.valueType = valueType;
            outputPointer.pointerType = pointerType;

            outputs.Add(outputPointer);
        }

        public void DeletePointerConnections()
        {
            foreach (InputPointer input in inputs)
            {
                if (input.TryGetComponent(out SingleConnectionInputPointer single))
                {
                    single.DeleteConnection();
                }
                else if (input.TryGetComponent(out MultiConnectionInputPointer multi))
                {
                    multi.DeleteConnections();
                }
                else
                {
                    continue;
                }
            }

            foreach (OutputPointer output in outputs)
                output.DeleteConnections();
        }

        public int MoveUp()
        {
            if (endNode)
            {
                Execute();
                return 0;
            }

            if (outputs == null)
                return 0;

            foreach (var input in outputs.Where(output => output.connectedInputPointers != null).SelectMany(output => output.connectedInputPointers))
                input.node.MoveUp();

            return 1;
        }

        protected virtual void CodeToExecute() { }
        public void Execute()
        {
            if (!_wasExecuted)
            {
                Debug.Log("Executing node: " + gameObject.name + " " + gameObject.GetHashCode());

                CodeToExecute();
                _wasExecuted = true;
            }
            
            GetData();
        }

        protected virtual void DataToGetAndSet() { }
        private void GetData()
        {
            Debug.Log("Get data of node: " + gameObject.name + " " + gameObject.GetHashCode());

            DataToGetAndSet();
        }

        protected virtual void CodeToReset() { }
        public void Reset()
        {
            Debug.Log("Reseting node: " + gameObject.name + " " + gameObject.GetHashCode());

            CodeToReset();
            _wasExecuted = false;
        }

        protected SingleConnectionInputPointer GetSingle(int i) => inputs[i].TryGetComponent(out SingleConnectionInputPointer input) ? input : null;
        protected MultiConnectionInputPointer GetMulti(int i) => inputs[i].TryGetComponent(out MultiConnectionInputPointer input) ? input : null;

        public bool IsValid(SingleConnectionInputPointer single) => !single && single.hasConnection;
        protected bool IsConnected(SingleConnectionInputPointer single) => single.hasConnection;
    }
}
