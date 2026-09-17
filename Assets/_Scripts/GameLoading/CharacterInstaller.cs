using System;
using System.Threading.Tasks;
using Character_Controller;
using Reflex.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace GameLoading
{
    public class CharacterInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private AssetReference playerPrefab;

        public async Task InstallBindings(ContainerBuilder containerBuilder)
        {
            var player = await CreatePlayer();
            Debug.Log("Player created");
            containerBuilder.AddSingleton(player);
        }

        private async Task<IPlayer> CreatePlayer()
        {
            var handler = Addressables.LoadAssetAsync<GameObject>(playerPrefab);
            await handler.Task;

            if (handler.Status == AsyncOperationStatus.Succeeded)
            {
                var playerObject = Instantiate(handler.Result);
                var playerMover = playerObject.GetComponent<IPlayer>();
                if (playerMover != null)
                {
                    return playerMover;
                }
            }

            throw new Exception("Failed to load player");
        }
    }
}