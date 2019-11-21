using UnityEditor;

namespace OpenInputManager
{
    public static class Mapper
    {
        public static IMapper<SerializedObject, InputManagerSettings> CreateUnityToModelMapper()
        {
            return new InputManagerSettingsMapping.UnityToModelMapper(
                new InputSettingsMapping.UnityToModelMapper());
        }
        public static IMapper<InputManagerSettings, SerializedObject> CreateModelToUnityMapper()
        {
            return new InputManagerSettingsMapping.ModelToUnityMapper(
                new InputSettingsMapping.ModelToUnityMapper());
        }

    }
}
