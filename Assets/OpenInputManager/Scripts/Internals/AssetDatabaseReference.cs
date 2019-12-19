using System;
using UnityEditor;

namespace OpenInputManager.Internals
{
    public class AssetDatabaseReference : IAssetReference<UnityEngine.Object>
    {
        public readonly string AssetPath;

        public AssetDatabaseReference(string assetPath)
        {
            AssetPath = assetPath;
        }

        public UnityEngine.Object LoadAsset()
        {
            var objects = AssetDatabase.LoadAllAssetsAtPath(AssetPath);

            if (objects.Length == 0)
                throw new ArgumentException("No asset found at path '" + AssetPath + "'.");

            if (objects.Length > 1)
                throw new ArgumentException("More than one asset found at path '" + AssetPath + "'.");

            else
                return objects[0];
        }

        public override string ToString()
        {
            return "AssetDatabase:" + AssetPath;
        }
    }
}