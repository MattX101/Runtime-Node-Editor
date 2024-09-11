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

        public void AddPointer(InputPointer input, ValueType valueType) => input.AddInputPointer(this, input, valueType);
        public void AddPointer(OutputPointer output, ValueType valueType) => output.AddOutputPointer(this, output, valueType);

        public void DeletePointerConnections()
        {
            foreach (InputPointer input in inputs)
                input.DeleteConnection();

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

            foreach (InputPointer input in outputs.Where(output => output.ConnectedInputPointers != null).SelectMany(output => output.ConnectedInputPointers))
                input.Node.MoveUp();

            return 1;
        }

        public int OnValueChangeReset()
        {
            ResetExecution();

            if (endNode)
            {
                Execute();

                return 0;
            }

            if (outputs == null)
                return 0;

            foreach (InputPointer input in outputs.Where(output => output.ConnectedInputPointers != null).SelectMany(output => output.ConnectedInputPointers))
                input.Node.OnValueChangeReset();

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
        protected void ExecuteConnection(int i)
        {
            if (IsValid(i))
                inputs[i].ConnectedOutputPointer.Node.Execute();
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
            ResetExecution();
        }

        private void ResetExecution() => _wasExecuted = false;

        public bool IsValid(int i) => inputs[i] && inputs[i].ConnectedOutputPointer;
        public bool IsValid(InputPointer input) => input && input.ConnectedOutputPointer;
        protected bool IsConnected(int i) => inputs[i].HasConnection;
    }
}
