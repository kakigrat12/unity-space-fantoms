# Space Fantoms — Unity/C# Systems Showcase

Space Fantoms is a compact Unity prototype presented as a code-first portfolio project. Its authored C# concentrates on two systems: a decomposed first-person character controller and procedural room assembly.

## Engineering highlights

- **Composable character controller.** Movement, gravity, jumping, camera rotation, cursor state, and raw input are separated into focused components instead of being accumulated in one player script.
- **Input abstractions.** Walking, jumping, mouse movement, and cursor actions are expressed through interfaces, leaving gameplay components independent of a particular input implementation.
- **Central motion boundary.** `CharacterMover` owns Unity's `CharacterController` integration while movement states contribute velocity, keeping engine calls localized.
- **Data-driven tuning.** Static input and physics settings isolate movement constants from behavior.
- **Procedural room joining.** The room spawner aligns modular passages by calculating a matching rotation and translated position, tracks open passages, randomizes candidate rooms, and rejects occupied placements with oriented bounds checks.
- **Composition through installers.** Bootstrap and installer classes connect controller parts through explicit registrations.

## Suggested code tour

| Area | Representative code | What it demonstrates |
|---|---|---|
| Motion boundary | [`CharacterMover.cs`](Assets/_Scripts/Character%20Controller/CharacterMover.cs) | Focused engine adapter and shared velocity state |
| Movement states | [`CharacterMovement.cs`](Assets/_Scripts/Character%20Controller/CharacterMovement.cs), [`CharacterJump.cs`](Assets/_Scripts/Character%20Controller/CharacterJump.cs), [`Gravity.cs`](Assets/_Scripts/Character%20Controller/Gravity.cs) | Responsibility-based controller decomposition |
| Input ports | [`Character Inputs`](Assets/_Scripts/Character%20Controller/Character%20Inputs), [`Character Camera Inputs`](Assets/_Scripts/Character%20Controller/Character%20Camera%20Inputs) | Interface-driven input implementations |
| Camera | [`CharacterCamera.cs`](Assets/_Scripts/Character%20Controller/CharacterCamera.cs) | Camera behavior separated from locomotion |
| Procedural layout | [`Spawner.cs`](Assets/_Scripts/Spawn/Rooms/Spawner.cs), [`SpawnedRoom.cs`](Assets/_Scripts/Spawn/Rooms/SpawnedRoom.cs) | Passage alignment, randomized search, spatial rejection |
| Composition | [`BootStrapInstaller.cs`](Assets/_Scripts/BootStrap/BootStrapInstaller.cs), [`CharacterInstaller.cs`](Assets/_Scripts/GameLoading/CharacterInstaller.cs) | Explicit system wiring |

## Repository scope

This is a source showcase rather than a playable Unity distribution. Serialized scenes, prefabs, art, `.meta` files, plugins, and vendor source are intentionally excluded. See [`SOURCE_SCOPE.md`](SOURCE_SCOPE.md).

The original project targets Unity `2022.3.10f1`; its package manifest is retained for dependency context.

