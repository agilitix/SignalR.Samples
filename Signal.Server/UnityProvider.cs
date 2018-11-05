using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Unity;

namespace Signal.Server
{
    public class UnityProvider
    {
        public IUnityContainer Container { get; }

        public UnityProvider(string unityConfigFile, string unityContainerName = "")
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap {ExeConfigFilename = unityConfigFile};
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);

            Container = new UnityContainer();
            UnityConfigurationSection unitySection = (UnityConfigurationSection) configuration.GetSection("unity");
            Container.LoadConfiguration(unitySection, unityContainerName);
        }
    }
}
