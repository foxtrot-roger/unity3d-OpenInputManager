using UnityEditor;

namespace OpenInputManager.Internals
{
    public static class Mapper
    {
        public static IMapper<SerializedObject, InputManager> CreateUnityToModelMapper()
        {
            return new InputManagerMapping.UnityToModelMapper(
                new InputConfigurationMapping.UnityToModelMapper());
        }

        public static IMapper<InputManager, SerializedObject> CreateModelToUnityMapper()
        {
            return new InputManagerMapping.ModelToUnityMapper(
                new InputConfigurationMapping.ModelToUnityMapper());
        }
    }
}
