**Blockcraft**


A Minecraft-inspired voxel game built in Unity using the Standard 3D pipeline.
Overview
Blockcraft is a voxel-based game inspired by Minecraft, built from scratch in Unity using the Standard 3D pipeline. This project focuses on core gameplay features such as player movement, terrain generation using Perlin noise, and optional interactions with moving platforms. These foundations are designed to be expanded into a full-scale voxel world, supporting exploration, building, and environment interaction.

Features Implemented
1. Player Movement
The player character has a first-person view and is controlled using the keyboard for movement (WASD) and mouse for looking around.
The player can jump and move across the world, with basic collision detection and ground checking to prevent jumping in mid-air.
Camera rotation allows the player to look up and down as well as rotate around the Y-axis for a smooth first-person experience.
Movement controls are fluid and responsive, offering a natural exploration experience for the player.
2. Terrain Generation
Terrain is generated procedurally using Perlin noise, mimicking natural landscapes with rolling hills and varied heights.
The generated terrain consists of block-based structures (voxels), where each block is a simple cube prefab that can be customized.
The terrain's dimensions are defined by configurable parameters such as chunk width, length, and height, with a maximum surface height for realism.
The terrain generation script uses a random seed to ensure each world generated is unique, offering endless variation.
Performance optimization includes limiting block instantiation to only blocks beneath or at the surface height, avoiding unnecessary computations.
3. Moving Platforms (Optional)
The project includes an optional feature where the player can interact with moving platforms or objects.
When the player steps onto a moving platform, they are attached to the platform, allowing them to move along with it.
When the player steps off the platform, they are detached, returning to independent movement.
This mechanic can be extended to vehicles, elevators, or any other moving objects in the game world.
Project Structure
Assets/Scripts: Contains all the C# scripts that handle core gameplay mechanics such as player movement, terrain generation, and interaction with objects.
Assets/Prefabs: Contains reusable prefabs like the block used for terrain generation.
Assets/Materials: Holds materials used for visual customization of the environment, such as block colors and textures.
How to Run
Clone the repository to your local machine:

bash
Copy code
git clone https://github.com/your-username/Blockcraft.git
Open the project in Unity. Ensure you're using Unity 2021.3.x LTS (or a compatible version) with the 3D Standard template.

Once the project is open, hit Play to test the player movement and terrain generation.

Next Steps & Planned Features
Block Destruction and Placement: Enable players to interact with the terrain by destroying and placing blocks to build structures.
Expanded Terrain Features: Add biomes, caves, trees, and water to create a more dynamic and diverse world.
Day/Night Cycle: Introduce a day-night system that affects lighting and gameplay.
Multiplayer Support: Allow multiple players to join the same world and collaborate or compete in building and exploring.
