# CA326-Year-3-Project
CA326 Year 3 Project: Turn-based strategy game developed in C# using Unity Engine

**Members:</br>
-Pedro Canes</br>
-Vilandas Sukutis**


# CA326 User Manual - Core Combat
### Vilandas Sukutis & Pedro Marques Canes

## 1. Introduction

Is strategy something you crave for? 

Do you enjoy challenges?

If your answer for both of those two questions was Yes, then get ready to dive into a brand new immersive and challenging strategy game.

Welcome to Core Combat.

Get a friend and challenge them to this new amazing challenge.


Core Combat is a turn-based strategy video game, which revolves around the idea of building a strong army of units that will be able to attack your opponent’s core, while at the same time, defend your own core. Both players will have their own core to defend, both of which will be placed on opposite sides of the hexagonal board. Once one of the cores gets hit 3 times, the game will be over, and the winner will be the player with the surviving core. In order to attack the opponent’s core, both players will be able to summon different units. Each unit will have different building times and moves allowed per turn. Once a unit reaches the enemy core and attacks it, the Core will be deducted a life. And if you do not have anyone to play against, you can try your best against the computer, which will be an even greater challenge. Have fun!


## 2. System Requirements

The following requirements are advised when running the game:

- Operating System: Windows 7 SP+1, macOS 10.11+, Ubuntu 12.04+, SteamOS+.
- GPU: DX10 (shader model 4.0) capabilities.
- CPU: SSE2 instruction set support.
- 50 MB Hard Drive space.	
- Mouse.

These are the minimal requirements for a smooth running of the game.

To run the game, simply open the application file and the game will start.


## 3. Game Objects

Core Combat has various object present in the game. Here you will find a run down of all the units present in the game.


![P1C][diagram1]

[diagram1]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/1.png "Player 1 Core"

1. Player 1 Core – Once touched 3 times, Player 2 wins


![P2C][diagram2]

[diagram2]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/2.png "Player 2 Core"

2. Player 2 Core – Once touched 3 times, Player 1 wins


![WA][diagram3]

[diagram3]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/3.png "Wall"

3.Wall – Immovable obstacle, spawned at random


![GU1][diagram4]

[diagram4]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/4.png "Green Unit 1"


![GU2][diagram5]

[diagram5]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/5.png "Green Unit 2"

4. Green Unit – Takes one turn to build and can move 2 tiles per turn.


![RU1][diagram6]

[diagram6]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/6.png "Red Unit 1"


![RU2][diagram7]

[diagram7]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/7.png "Red Unit 2"

5. Red Unit – Takes two turns to build and can move 3 tiles per turn.


![BU1][diagram8]

[diagram8]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/8.png "Blue Unit 1"


![BU2][diagram9]

[diagram9]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/9.png "Blue Unit 2"

6. Blue Unit – Takes five turns to build and can move 5 tiles per turn.


## 4. How to Play

### 4.1. Creating a Unit

The first step towards winning the game is the creation of the units. The player will need units to play the game. In order to create a unit, there is three things the players need to make sure. Firstly, it must be the player’s turn when starting the creation of a unit. Secondly, there cannot be a unit in the unit spawning position (tile in front of the core). If there is any unit on that tile, the creation of a unit will not be possible. Thirdly, there cannot be any unit in creation. Creating a unit is only possible when no unit is being created. Once the player presses the unit button, the player will have to wait until the unit is on the board before creating a new one.

![PM][diagram10]

[diagram10]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/10.png "Player Menu"

If the creation of a unit is indeed possible, the player will have to choose which unit to spawn. Each unit has a different energy value and more importantly, each unit has a different creation time. Therefore, a player will have to think about which unit is the best option at the time of creation. Creating a unit at the wrong time can turn out detrimental. For example, if there is an enemy unit near your core, creating a blue unit will leave your core unprotected for 5 turns, which will give plenty of time for the opponent to strike.
Creating a unit is one of the most important actions to make, therefore, a lot of thought and planning must be done beforehand.


### 4.2. Moving a Unit

Moving your units is the basis of the game. The player needs to move their units in order to reach the enemy core and therefore win the game. The moving system in Core Combat is very simple. Once you click on a unit, the tiles which the player can move the unit to, will turn blue. Clicking on one of the blue tiles will move the unit to the tile and expend one energy use. If the tile under the unit is green, it means the unit has energy left to use, otherwise the tile will turn red.

![UM][diagram11]

[diagram11]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/11.png "Unit Move"

![UM2][diagram12]

[diagram12]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/12.png "Unit Move2"

The player is allowed to move all their units on the board per turn until the units run out of energy. Once the energy is depleted, the player will have to wait until their next turn to move the units again. The units’ energy will refill at the start of each turn. The player can only move their units on their turn.

### 4.3. Attacking a Unit/Core

Attacking enemy objects is also another important aspect of the game. Throughout the game, the player will face enemy units. When one of the units is within range of an enemy unit, the player can opt to attack the enemy unit. If the player hesitates, it might result in the enemy attacking the unit, removing the unit from the board. Attacking an enemy unit will expend one of the unit’s energy levels.

![UA][diagram13]

[diagram13]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/13.png "Unit attack"

![UA2][diagram14]

[diagram14]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/14.png "Unit attack2"

Deciding to attack an enemy unit requires a lot of thought and planning. The player will have to make sure the unit has enough energy before opting to get close to the enemy unit, otherwise, the enemy unit will be able to easily reach the player’s unit and attack it on the next turn. To attack an enemy unit, the player will have to place their unit one tile away from the enemy unit, and if there is one or more energy left, the player can click on the enemy unit, removing it from the game, and using one unit energy level.

Attacking an enemy core works the same way. Once one of the player’s units is one tile away from the enemy core and still has one energy level left, the player will be able to strike the enemy core and remove one of its lives.

![UAC][diagram15]

[diagram15]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/15.png "Unit attack core"


## 5. User Interface

The user interface in Core Combat is very straight forward. Here you will find a run down of all the User Interface elements:

![PM2][diagram16]

[diagram16]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/16.png "Player Menu"

1. Player Menu – The player menu shows how many lives the player’s core has (top 3 squares). The menu also includes the buttons that will start the creation of each of the units. If the creation is not possible, the buttons will not be interactable. Beside the buttons, there is the number of turns taken before the unit appears on the board


![TP][diagram17]

[diagram17]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/17.png "Turn Panel"

2. Turn Panel – Shows who’s turn it is.


![ET][diagram18]

[diagram18]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/18.png "end turn"

3. End Turn button - Button that will end the player’s turn and start the opponent’s turn.


![EP][diagram19]

[diagram19]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/19.png "energy panel"

4.	Energy Panel – Shows the energy of a chosen unit. (Click on a unit to show this panel)


![EH][diagram20]

[diagram20]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/20.png "exit help"

5. Exit and Help Buttons – Clicking on the Exit button will ask for confirmation and if given will stop the Application. Help Button will show a help panel that gives a short explanation of the game.


![GO][diagram21]

[diagram21]: https://github.com/pedrocanes/CA326-Year-3-Project/tree/master/images/usermanual/21.png "game over"

6.	Game Over Panel – Once one of the players wins, the panel will show who the winner is.


## 6. Versus Computer

If you are looking for a challenge, consider giving our A.I. computer a chance to defeat you. A button on the side of the screen will enable player vs computer. Enabling this feature will make it so the Computer moves their own pieces and will always try to find the best possible move against the player. This will be a real challenge that only the most skilled will be able to overcome. If you think you have got it in you, feel free to give it a shot.
