using System;
using UnityEngine;

namespace RuntimeNodeEditor.UI.Canvas.Node.Components
{
    internal static class NodeUIFactory
    {
        public const string nodeNamespace = "RuntimeNodeEditor.UI.Canvas.Node.";
        
        public static NodeUI CreateNode(string id, Vector3 position)
        {
            if (id.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return null;
            }

            Type type = Type.GetType(nodeNamespace + id);
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            GameObject nodeUIObject = new GameObject();
            NodeUI nodeUI = (NodeUI)nodeUIObject.AddComponent(type);
            nodeUI.Init(id);
            nodeUI.rootRect.localPosition = position;

            return nodeUI;
        }

    }
}