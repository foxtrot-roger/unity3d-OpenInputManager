using System.Collections.Generic;

namespace OpenInputManager
{
    public static class InputManagerExtenstion
    {
        public static InputInfo FindByName(this List<InputInfo> axes, string axisName)
        {
            return axes?.Find(o => o.Name == axisName);
        }
        public static InputInfo GetOrCreate(this List<InputInfo> axes, string axisName)
        {
            var axis = axes.FindByName(axisName);
            if (axis == null)
            {
                axis = new InputInfo { Name = axisName };
                axes.Add(axis);
            }

            return axis;
        }
    }
}
