using System.Reflection;
using System.Resources;

namespace Hid.Checkpoint.DataAccess.Ef.Resources;

public static class ResourcesAccess
{
    private static ResourceManager? _resourceManager;

    public static ResourceManager ResourceManager
    {
        get
        {
            return _resourceManager ??= new ResourceManager("Hid.Checkpoint.DataAccess.Ef.Resources.resources", Assembly.GetExecutingAssembly());
        }
    }

    public static string Countries => ResourceManager.GetString("countries");
}
