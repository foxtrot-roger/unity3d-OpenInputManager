using UnityEditor;

namespace OpenInputManager
{
    public static class AssetDatabaseHelper
    {
        public static SerializedObject LoadSerializedObjectAtPath(string settingsAssetPath)
        { return new SerializedObject(AssetDatabase.LoadAllAssetsAtPath(settingsAssetPath)[0]); }
    }
}
