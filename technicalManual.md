# CA326 Technical Specification - Core Combat
### Vilandas Sukutis & Pedro Marques Canes

## 1. Introduction

### 1.1. Overview

The project developed is a single player video game to be developed as a desktop application. Although primarily a single player game, it can also be set to player versus player. The game is a competitive turn-based strategy game, which is based around the idea of protecting a core, while simultaneously trying to destroy the opponent’s core with a set of units at the player’s disposal.

The project’s primary focus was not game design, but rather implementing various algorithms and functions learned by the student into a real-world project. The algorithms and functions are responsible for different features present in the game as well as the Artificial Intelligence used in the game.

The game was developed using the most recent version of Unity 3D, a free game development engine which was used to compile and connect all the scripts written as well as build all the early test versions and ultimately, the finalised version of the game. The Unity engine will compile the script files and render the game’s environment and the User Interface elements. All programming involved in the gameplay’s development and User Interface building will be done by the team from scratch.

The project was primarily written in the C# programming language as it is one of the main languages supported by the Unity 3D engine. This language has an abundance of documentation and help used to support our development.

All the models used in the game were modelled using Cinema 4D and Blender, two 3D modelling software engines. All animations used have been created on the Unity 3D engine, all from scratch.

### 1.2. Business Context

There is a possibility that the game developed could be made into a mobile game, and in case the game is successfully adapted into mobile, it could be deployed to both Apple AppStore and Google Play.

Both platforms allow for indie game developers to apply to have their games up for download. This is not the aim of the project, and it is merely a possibility in the future.

### 1.3. Glossary

- Player Units: A controllable object placed on the board by the player. Each Unit will have different attributes.
- Enemy Units: A controllable object placed on the board either by the second player playing or the Artificial Intelligence player.
- Unity 3D: A free game development engine used in the development of this game.
- Core: A special game piece that once destroyed 3 times, the game ends. Each player will have one core placed at each side of the board. All units appear in front of the core once created.	
- Cinema 4D / Blender: Two 3D modelling software engines responsible for the modelling of the objects used in the game.


## 2. System Architecture

![SA][diagram1]

[diagram1]: https://gitlab.computing.dcu.ie/sukutiv2/2019-ca326-pedroandvelosproject/raw/master/images/technical/1.png "System Architecture"

### 2.1. Overview

The game will ultimately be an executable file that once run will start a game. The game will receive input from the mouse and run the functions necessary for the action to happen. Essentially, the user will click on an object (either game object or User Interface object), which will be accepted by a script, basically telling it what the user wants the object to do. If the script requires a second input from the user (e.g. Moving a unit), it will wait for this second input and then run the necessary function(s). If the script does not require a second input, it will run the function straight away (e.g. clicking on a User Interface button). If the player is playing against the computer (A.I.), the computer’s actions will be decided internally with the use of an Algorithm and run without any input from the user.

### 2.2. Game Engiune

The game engine will compile all the scripts and objects when building the game, which will result in an executable file that will include all the game files (written scripts, algorithms and game objects).

### 2.3. Scripts

The game is mostly run with scripts. Each script equates to a class and all classes will communicate with one another in some way. All scripts have a start and update functions. The start function will be called once when the game is opened. The update function gets called every frame and is responsible for the game’s actions. The main classes are the map class and the mouse manager class. The map class is responsible for generating the map. It has various functions that will generate a hexagonal shaped board of certain width and height (these can be changed in the game files). It will then attribute each tile a certain set of coordinates which will be used for any functions that will involve the movement of units. The mouse manager class is responsible for getting input from the mouse and converting it to input that the game can understand. This is done mostly by converting the places clicked on the screen to coordinates in the game board using ray casts (ray that comes from the mouse onto the 3D world). This will allow the game to recognize when the user is clicking on a unit or on a tile and then perform an action, which will allow the user to move units around or attack enemy units or the enemy core. Another important script will be the game manager class. This will take care of important actions that happen in the game such as creating a unit and changing turn. There are also other scripts responsible for manipulating the Tile objects, the User Interface elements and any animations present.

### 2.4. Units

The game will be based on the movement of units. There will be three units for each player (spheres for player 1, pyramids for player 2/A.I.). Each unit has a different energy value (number of steps each unit can make per turn) as well as a different number of turns it takes to spawn once the create unit function has been run. These units all have different attributes that are in the unit script. The creation of these units is done by the core and the game manager scripts. The movement of these units is done through the mouse manager script. The attacking of units is done through the game manager script. These units will be able to attack enemy units, removing them from the board and they will also be able to attack the enemy core removing themselves from the board once that happens.

### 2.5. Artificial Intelligence

The game has one important script file which is the Artificial Intelligence class. This script will include the algorithm which will be responsible for managing the actions to be taken by the A.I. The algorithm chosen for this project was an algorithm similar to the Minimax algorithm. Once it is the A.I.’s turn, it will read the game, i.e. find the position of any units present on the board, and it will then decide which is the best move it can make. This will include attack the player core whenever possible, try to minimize the player’s number of units present by attacking any nearby player units while at the same time trying to maximize its own units by creating units whenever possible as well as moving any existing units forward. Once all possible actions have been taken, the script will then end its turn.

### 2.6. User Interface

The game contains a simple futuristic themed User Interface. There are various elements present. The main one will be the player menu. This are the menus placed on the top corners of the screen. This will contain the Player name and the buttons that will start the creation of units. There are three buttons, each one for one of the three units. These buttons will only work when it is the specific player’s turn and there are no units currently in the making. If the creation of units is not possible, the buttons’ intractability will be disabled unit it is possible to do so. Once one of the buttons is clicked the process of creating the unit will be started. Another element in the player menu is the core health. There will be one square for each one of the core’s lives and once the core loses one of their lives, one square will disappear. At the top of the screen there will be another U.I. element which will be the turn panel which will indicate who’s turn is it. This will be changed every time the next turn function is run. This function will either be run by clicking on the “End turn” button on the bottom left of the screen or by the A.I. The energy panel will pop up when the player clicks on a unit, and it will display the unit’s current energy value. One of the two buttons on the bottom right of the screen will display a help page that summarizes the game’s objective and the U.I. elements. The other will allow the user to quit the game, which if confirmed, will quit the application. Finally, once the game ends, a panel will pop up on the screen announcing the winner of the game.


## 3. High Level Design

### 3.1. Sequence Diagram

![SD][diagram2]

[diagram2]: https://gitlab.computing.dcu.ie/sukutiv2/2019-ca326-pedroandvelosproject/raw/master/images/technical/2.png "Sequence Diagram"

The sequence the game follows is very repetitive. It all starts with the player creating a unit, which happens through the user interface. Once clicked and after a specific amount of turns, the unit will appear on the board. Once there are unit(s) on the board, the player clicks on one of the units, which happens through the mouse manager script. The player will then click once again on the tile that the unit is supposed to move to. This is once again read through the mouse manager class and the information is passed over to a script. The script will apply to proper functions and the action will happen and the unit is moved. 

### 3.2. Class Diagram

![CD][diagram3]

[diagram3]: https://gitlab.computing.dcu.ie/sukutiv2/2019-ca326-pedroandvelosproject/raw/master/images/technical/3.png "Class Diagram"

The class diagram above displays the most important classes, i.e. their attributes and their functions and how each of them interact with one another. The game controller class will manage both the units (creation and attack) and the core. The core will also affect the Unit class as it physically creates each of them on the board. The mouse manager class will be responsible for the movement of the Unit as well as the reading of each Hex tile. The hex tiles compose the board/map.

### 3.3. Polymorphism

The scripts written for the project use Polymorphism. Essentially, all units are different but share the same object, regardless of which player is playing them and which unit is being used. This was done by creating a Unit abstract class which all units will use.


## 4. Problems

### 4.1. Early Problems

The main problem which the group came across during the early stages of the development was the lack of knowledge about how to actually develop this game. Firstly, neither one of the group members had any experience in using the Unity 3D engine. This was a very new concept to the group and a big early obstacle to move past. Secondly, neither one of the members, once again, had any experience with programming in C#. This was a programming language that neither one of the members had ever used before, and the fact that it is the main language supported by Unity 3D, made the learning of this language mandatory. Thirdly, the Unity 3D engine is not a software present in the computing labs in DCU which made the development of this game even harder.

### 4.1.1. Solution

In order to get accustomed with both Unity 3D and C#, both members accessed online tutorials and guides. With the help of these guides, the group slowly started using these two important components of the project and slowly, the project started being developed. As time went by, more experience and knowledge were gained. Learning a new programming language from scratch turned out to be a big challenge, but as time went by, this slowly became easier. Regarding the lack of the Unity engine in the computing labs, the group had to bring their own machines and use those instead.

### 4.2. Mid-way Problems

The biggest problem the group faced during the development of the project was the frustration of the abundance of bugs and the lack of knowledge to know how to fix them. The frustration was also heightened as the group was too ambitious when coming up with the idea for the project which turned out to be overwhelming. During the development of the project, the biggest challenges faced included:

- Generating the map in a hexagonal shape with hexagon shaped tiles: Unlike squares, hexagons do not match perfectly, hence the coordinate system was flawed.
- Managing to successfully acquire each tile’s neighbouring tiles: Bugs and errors kept coming up when trying to return a list of a tile’s neighbouring tiles.
- Figuring out how to transverse the map: The group attempted to use pathfinding algorithms for the player, but these turned out to be too complex and too unreliable. Bugs kept turning up when the map traversing system was changed.
- Attacking a unit: When attacking a unit, a player could its own units.

### 4.2.1. Solutions

Regarding the very ambitious project, the group decided to lower its expectations, which resulted in the removal of some of the features that looked very complex and extremely hard to achieve within the time period for the project.

Regarding the different bugs that happened within the game, most of them were fixed after some unit testing or by choosing a different way to implement the feature. For example: The map generation problem was fixed after some testing which eventually resulted in the successful generation of a hexagonal board with hexagonal tiles. The neighbouring tiles problem was fixed by changing the way the function worked to a more traditional list building implementation. Traversing the map was ultimately decided to be done by simply holding the coordinates of each tile since the directions that the unit can move in will always be the same distance away in terms of x and y, instead of using pathfinding. When attacking a unit, some modifications had to be done when generation the units to successfully distinguish both players.

### 4.3 Late Problems

Most of the late problems revolved around the implementation of the A.I. This turned out to be the biggest challenge the group faced throughout the whole development which caused a lot of stress and anxiety to both the group members. The use of the minimax algorithm turned out to be harder than predicted, as it is meant for simpler games. However, the game developed was much more complex. The developed algorithm would break often, and various bugs arose.

### 4.3.1. Solution

Ultimately, the group decided to go for an implementation which will try to be offensive by moving forward down the board while destroying any nearby units, minimizing the opponent’s units while maximizing its own units. A.I. was a very overwhelming obstacle and a few alternatives were considered as a back up in case the minimax A.I. did not work.


## 5. Testing

### 5.1. Unit Testing

Unit Testing was carried out throughout the development of the project in order to make sure everything worked as intended. All the components and functions of the software was thoroughly tested using assertion functions and log statements to make sure the successfulness of the components. Unit Testing also helped with the refraction of code to make the scripts look cleaner and easier to understand as well as finding some bugs that were not previously discovered.

### 5.2. User Testing

User Testing was carried out towards the end of the project development. 6 people were approached to answer a survey build on the survey monkey website. The survey included questions such as:

- Was the game easy to understand?
- Was the game fun to play?
- How many bugs/errors did you come across?
- What bugs did you come across?
- What would you change in the game?

Regarding the first question, all the people who answered the survey thought the game was easy to understand with there being a “100% Yes-No” ratio. The feedback gotten from this question allowed the group to be certain the game was easy enough to play.

Regarding the second question, 4 out of 6 people thought the game was fun to play with there being a “66% Yes-No” ratio. This question allowed us to know that improvement can be made to make the game more fun.

Regarding the bugs found, the survey displayed an average of 1.5 bugs during playtime, which was a positive feedback as the group was expecting more. When the survey asked what bugs were encountered, only small easy fixable bugs were encountered, such as the fact that the game would not display the neighbour tiles properly when being on a tile at the edge of the board, and that when moving a unit, sometimes two units could overlap. These bugs were quickly fixed.

When asked what changes could be made to improve the game, various people complained the game was slow and boring and that more variety of units could be added to the game. 

As a group, we are glad the survey displayed a positive feedback towards the game and more importantly, we are glad that it helped the discovery of some bugs previously unknown to us. We can therefore say that the User Testing part of the project was successful.


## 6. Changes made from initial functional specification

The project initially projected by the group turned out to be unrealistic and too complex for the time period and experience the group had. Therefore, certain features projected at the start had to be removed or adapted in order to successfully complete the development of the project.

Cosmetic elements of the game: The game the two group members had in mind at the start included a futuristic theme board and units with various animations and sound effects. This turned out to be unnecessary for the project’s development and hence was dropped in order to save time. Instead, simpler colour schemes and unit models were chosen.

Path Finding for unit movement: Initially, the group aimed to have a fully working path finding algorithm that would be used for the player unit movement. However, this turned out to be much more difficult than expected and the group decided that such a complex approach was unnecessary, therefore, it was decided that moving one tile at a time with a click was easier to implement.

Number of units: This was mainly a game design element that the group had previously thought of adding to the game, but since the aim of the project was programming rather than game design, the members decided that three units would suffice for the game design part of the project.

A.I. using state machines and A* Algorithm: This was an idea that was discarded once discussing it with the project supervisor. It was decided that a Minimax like approach was more suitable for this game.


## 7. Installation Guide

### 7.1. System Requirements

The following requirements are advised when running the game:

- Operating System: Windows 7 SP+1, macOS 10.11+, Ubuntu 12.04+,SteamOS+
- GPU: DX10 (shader model 4.0) capabilities
- CPU: SSE2 instruction set support.

These are the minimal requirements for a smooth running of the game.

### 7.2. How to run the game

Once the game is built and compiled, an executable file is all that is needed in order to play the game, therefore, having Unity installed is not a requirement for the playing of the game. 
In order to play the game, running the supplied executable file will open the game straight away with no installation files needed. 
