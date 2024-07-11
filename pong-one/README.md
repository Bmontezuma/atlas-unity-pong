l# ***PONG 1***
# Pong Game

## Table of Contents
- [Introduction](#introduction)
- [How to Play](#how-to-play)
- [Game Setup](#game-setup)
- [Small History of Pong](#small-history-of-pong)
- [Acknowledgements](#acknowledgements)
- [Resources Used](#resources-used)

## Introduction
Welcome to the Pong Game! This is a modern recreation of the classic arcade game Pong, which you can play solo against an AI or with a friend in multiplayer mode. Follow the instructions below to get started and enjoy the game!

## How to Play
### Controls
- **Player One**:
  - Move Up: `W`
  - Move Down: `S`
- **Player Two**:
  - Move Up: `Up Arrow`
  - Move Down: `Down Arrow`

### Objective
- The objective is to score points by getting the ball past your opponent's paddle. The first player to reach 11 points wins the game.

### Scoring
- Each time the ball passes your opponent's paddle, you score a point.
- The score is displayed at the top of the screen.

## Game Setup
### Prerequisites
- Unity 2020.3 or later

### Instructions
1. **Clone the Repository**:
    ```sh
    git clone https://github.com/yourusername/atlas-unity-pong.git
    cd atlas-unity-pong
    ```

2. **Open the Project in Unity**:
    - Open Unity Hub.
    - Click on "Add" and select the `atlas-unity-pong` directory.
    - Open the project.

3. **Setup Player One Paddle**:
    - Create a new GameObject named `Player One`.
    - Set its Tag to `Paddle`.
    - Set Position to `X: 150, Y: 0, Z: 0`.
    - Set RectTransform Width to `40` and Height to `200`.
    - Set Anchors Min and Max to `X: 0, Y: 0.5`.
    - Set Pivot to `X: 0.5, Y: 0.5`.
    - Add a `BoxCollider2D` component, set Size to `X: 40, Y: 200`, and enable `IsTrigger`.
    - Add an `Image` component and set Color to `White`.
    - Attach the `Paddle.cs` and `Player.cs` scripts.
    - Set `upKey` to `W` and `downKey` to `S`.

4. **Setup Player Two Paddle**:
    - Create a new GameObject named `Player Two`.
    - Set its Tag to `Paddle`.
    - Set Position to `X: -150, Y: 0, Z: 0`.
    - Set RectTransform Width to `40` and Height to `200`.
    - Set Anchors Min and Max to `X: 1, Y: 0.5`.
    - Set Pivot to `X: 0.5, Y: 0.5`.
    - Add a `BoxCollider2D` component, set Size to `X: 40, Y: 200`, and enable `IsTrigger`.
    - Add an `Image` component and set Color to `White`.
    - Attach the `Paddle.cs` and `Player.cs` scripts.
    - Set `upKey` to `UpArrow` and `downKey` to `DownArrow`.

5. **Setup the Ball**:
    - Create a new GameObject named `Ball`.
    - Add a `SpriteRenderer` component and assign a ball sprite.
    - Add a `Rigidbody2D` component, set body type to `Dynamic`.
    - Add a `CircleCollider2D` component.
    - Attach the `Ball.cs` script.

6. **Setup Scoring**:
    - Create a UI Text (TMP) GameObject named `LeftScore` for Player One's score.
    - Set Position to `X: -100, Y: -100, Z: 0`.
    - Set Width to `150` and Height to `150`.
    - Set Anchors Min and Max to `X: 0.5, Y: 1`.
    - Enable Auto Size and set Font Size Min to `18` and Max to `250`.
    - Duplicate `LeftScore` to create `RightScore` for Player Two's score, set Position to `X: 100, Y: -100, Z: 0`.
    - Create a `GameManager.cs` script to handle the scoring logic and attach it to an empty GameObject named `GameManager`.
    - Assign `LeftScore` and `RightScore` TextMeshProUGUI components to the `GameManager` script.

7. **Setup AI Player**:
    - Create an AI prefab named `AIPlayer`.
    - Add the `AIPlayer.cs` script to the prefab.
    - Attach the `AIPlayer` prefab to `Player Two`.

8. **Create and Apply Physics Material**:
    - In the `Materials` folder, create a `Physics Material 2D` named `PaddlePhysics`.
    - Set `Bounciness` to `1` and `Friction` to `1`.
    - Apply `PaddlePhysics` to both `Player One` and `Player Two`'s `BoxCollider2D` components.

### Small History of Pong
Pong is one of the earliest arcade video games, created by Atari and released in 1972. It was a simple tennis simulation game that became incredibly popular and is often credited with launching the video game industry. The gameplay involved two paddles and a ball, with players scoring points by getting the ball past their opponent's paddle. Pong's success led to numerous clones and adaptations, solidifying its place in gaming history as a pioneering classic.

### Acknowledgements
- Special thanks to Atari for creating the original Pong game.
- Thanks to all the contributors and developers who made this modern adaptation possible.

### Resources Used
- **Unity**: [Unity](https://unity.com/)
- **TextMeshPro**: [TextMeshPro](https://docs.unity3d.com/Manual/com.unity.textmeshpro.html)
- **Sound Effects**: [Zapsplat](https://www.zapsplat.com), [Freesound](https://www.freesound.org), [MixKit](https://www.mixkit.co), [Storyblocks](https://www.storyblocks.com)
- **Game Assets**: Custom-made sprites and assets.

Enjoy playing the game and feel free to contribute to the project!

