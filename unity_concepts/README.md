# Unity Concepts

This repository contains a Unity project to explore fundamental Unity concepts, including GameObjects, Components, Prefabs, Tags, Layers, and more.

## Learning Objectives

By the end of this project, you should be able to explain the following without external resources:

### General
- **GameObject**: What it is and how it functions as the building block of Unity scenes.
- **Component**: What it is and how it extends the functionality of GameObjects.
- **Prefab**: How it allows reusable GameObject configurations.
- **Tag**: What it is and how to use it for identifying GameObjects.
- **Layer**: What it is and how it organizes and optimizes scene management.
- **Creating GameObjects**: How to create and modify their properties.
- **Creating Prefabs**: How to build reusable Prefab assets.
- **Adding Tags and Layers**: How to assign and manage them effectively.
- **Organizing Projects**: Why clear naming conventions and a well-structured hierarchy are important.
- **Gameplay and Game Mechanics**: Their role in creating interactive experiences.

## Requirements

### General
- Include a `README.md` file in the root of the project folder.
- Use Unity's default `.gitignore` file in the `holbertonschool-unity` directory, ensuring it applies to the entire repository.
- Push the entire `unity_concepts` project folder to the repository, including `.meta` files. Ensure ignored files and folders specified in the `.gitignore` are not pushed.
- Name and organize scenes and project assets (e.g., Materials) as described in the project tasks.
- **No scripts** are allowed in this project.

## Project Overview

This project demonstrates the following Unity concepts across multiple tasks:

1. **Floor Creation**: Building a basic scene with a floor.
2. **GameObjects**: Adding and configuring a sphere to the scene.
3. **Materials**: Creating and applying materials to objects for color.
4. **Physics**: Adding Rigidbody and Physic Materials for dynamic behavior.
5. **Prefabs**: Creating and reusing Prefab instances.
6. **Tags and Layers**: Using tags for object categorization.

Each task builds upon the previous one to showcase practical applications of these Unity features.

## File Structure

```plaintext
holbertonschool-unity/
└── unity_concepts/
    ├── Assets/
    │   ├── Scenes/
    │   │   ├── 0-floor.unity
    │   │   ├── 1-ball.unity
    │   │   ├── 2-colors.unity
    │   │   ├── 3-gravity.unity
    │   │   ├── 4-prefab.unity
    │   │   ├── 5-more_colors.unity
    │   │   └── 6-tags.unity
    │   ├── Materials/
    │   │   ├── floor.mat
    │   │   ├── ball.mat
    │   │   ├── ball-red.mat
    │   │   ├── ball-blue.mat
    │   │   ├── ball-green.mat
    │   │   ├── ball-white.mat
    │   │   └── ball-black.mat
    │   ├── Prefabs/
    │   │   └── Ball.prefab
    │   ├── Physic Materials/
    │   │   └── bounce.physicMaterial
    └── ProjectSettings/
