using UnityEditor;

namespace OpenInputManager
{
    public static class Mapper
    {
        public static IMapper<SerializedObject, InputManager> CreateUnityToModelMapper()
        {
            return new InputManagerMapping.UnityToModelMapper(
                new InputSettingsMapping.UnityToModelMapper());
        }
        public static IMapper<InputManager, SerializedObject> CreateModelToUnityMapper()
        {
            return new InputManagerMapping.ModelToUnityMapper(
                new InputSettingsMapping.ModelToUnityMapper());
        }

    }
}
