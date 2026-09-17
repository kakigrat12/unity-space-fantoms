using System.Threading.Tasks;
using Reflex.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace BootStrap
{
    public class BootStrapInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private AssetReference nextSceneLoad;
        
        public async Task InstallBindings(ContainerBuilder containerBuilder)
        {
            await LoadNextScene();
            
            Debug.Log("Starting BootStrap");
        }

        private async Task LoadNextScene()
        {
            var asyncOperation = Addressables.LoadSceneAsync(nextSceneLoad);
            await asyncOperation.Task;
        }
    }
}