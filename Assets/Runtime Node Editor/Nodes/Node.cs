using RuntimeNodeEditor.Node.Pointer;
using RuntimeNodeEditor.Node.UIFunctions.Elements;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RuntimeNodeEditor.Node
{
    public class Node : MonoBehaviour
    {
        private bool _wasExecuted;

        public bool EndNode
        {
            get;
            protected set;
        } = false;

        public readonly List<InputPointer> Inputs = new();
        public readonly List<OutputPointer> Outputs = new();

        public NodeUIElements Elements;

        public virtual void Init()
        {
            //
        }

        public void AddPointer(InputPointer Input, int valueTypeIndex)
        {
            Input.AddInputPointer(this, Input, valueTypeIndex);
        }
        public void AddPointer(OutputPointer Output, int valueTypeIndex)
        {
            Output.AddOutputPointer(this, Output, valueTypeIndex);
        }

        public void DeletePointerConnections()
        {
            foreach (InputPointer Input in Inputs)
                Input.DeleteConnection();

            foreach (OutputPointer Output in Outputs)
                Output.DeleteConnections();
        }

        public int MoveUp()
        {
            if (EndNode)
            {
                Execute();

                return 0;
            }

            if (Outputs == null)
                return 0;

            foreach (InputPointer Input in Outputs.Where(Output => Output.ConnectedInputPointers != null).SelectMany(Output => Output.ConnectedInputPointers))
                Input.Node.MoveUp();

            return 1;
        }

        public int OnValueChangeReset()
        {
            ResetExecution();

            if (EndNode)
            {
                Execute();

                return 0;
            }

            if (Outputs == null)
                return 0;

            foreach (InputPointer Input in Outputs.Where(Output => Output.ConnectedInputPointers != null).SelectMany(Output => Output.ConnectedInputPointers))
                Input.Node.OnValueChangeReset();

            return 1;
        }

        protected virtual void CodeToExecute() { }
        internal void Execute()
        {
            if (!_wasExecuted)
            {
                Debug.Log("Executing node: " + gameObject.name + " " + gameObject.GetHashCode());

                CodeToExecute();
                _wasExecuted = true;
            }

            GetData();
        }

        protected void ExecuteInputConnection(int i)
        {
            if (IsValid(Inputs[i]))
                Inputs[i].ConnectedOutputPointer.Node.Execute();
        }

        protected virtual void DataToGetAndSet() { }
        private void GetData()
        {
            Debug.Log("Get data of node: " + gameObject.name + " " + gameObject.GetHashCode());

            DataToGetAndSet();
        }

        protected virtual void CodeToReset() { }
        internal void Reset()
        {
            Debug.Log("Reseting node: " + gameObject.name + " " + gameObject.GetHashCode());

            CodeToReset();
            ResetExecution();
        }

        internal void ResetExecution()
        {
            _wasExecuted = false;
        }

        public bool IsValid(InputPointer Input)
        {
            return Input && Input.ConnectedOutputPointer;
        }
    }
}
