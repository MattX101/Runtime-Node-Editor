using RuntimeNodeEditor.UI.Canvas.Node;
using Utils.StringParameterExtractor;
using UnityEngine;
using System;
using System.Reflection;

namespace RuntimeNodeEditor.Factory
{
    internal static class Factory
    {
        private const string AssemblyName = "RNE.Template.UI";
        private const string NodeNamespace = "RNE.Template.UI.Node.";

        internal static NodeUI CreateNode(string id, Vector3 position)
        {
            // Removes parameters from id else 'not null' error is thrown
            string typeId = StringParameterExtractor.ExtractBase(id);

            if (typeId.Length > byte.MaxValue)
            {
                Debug.LogError("Name of node cannot exceed 255 characters!");

                return null;
            }

            Assembly assembly = Assembly.Load(AssemblyName);
            Type type = assembly.GetType(NodeNamespace + typeId);

            if (type == null)
                throw new ArgumentNullException(nameof(type));

            GameObject nodeUIObject = new GameObject();
            NodeUI nodeUI = (NodeUI)nodeUIObject.AddComponent(type);
            nodeUI.Init(id);
            nodeUI.RootPosition = position;

            return nodeUI;
        }
    }
}