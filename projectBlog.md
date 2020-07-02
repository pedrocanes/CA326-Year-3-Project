# CA326 — Project Blog for Core Combat
### Vilandas Sukutis &amp; Pedro Canes

## Tuesday, 16th October.

First meeting with Charlie Daly, with whom the project partners discussed their idea and requested to be supervised by said lecturer. The main takeaway points from this initial meeting were:

- Interesting project idea
- Perhaps project scale/ambition is too big
- Need to decide on a more concrete path the AI should take


## 17th — 19th October.

Having received feedback and a general go-ahead back from their supervisor, the team began to research more into their idea individually, to cover more ground in less time.
 
Similar projects and games we’re examined, such as Civilization V. 
 
Many game design ideas were thrown around. Only those that seemed to-able by the team in the given time were considered and recorded for future reference.


## 22nd — 26th October.

A more specific project idea had been mocked up by the team. The game would aim to provide a similar gaming experience to that of Civilization but in a simpler format, as the project team is not skilled enough, or have enough talent to match the quality of a triple A studio.

A visual design direction has been reached, aiming for a futuristic, ‘Tron’ like atmosphere.

Experienced some doubts about their abilities. Neither member of the team has any experience in C# or Unity Game Engine, so adequate time would need be allocated to learn the fundamentals of both. 

Vilandas focused on the User Experience ideas, while Pedro primarily focused on game play. Some ideas that were recorded for consideration that did not make the cut:

- Local multiplayer
- Online multiplayer
- Up to six concurrent players

While these ideas were exciting, it was decided that they would be too much to handle for the inexperienced team.


## Monday, 12th November.

Team met to finalize the project idea and create the PowerPoint slides for the presentation, due the next day.

Vilandas laid out the main points that we needed to hit in their presentation, while Pedro created the slides themselves.

The presentation was rehearsed a couple of times to make sure they don’t go over the allocated time.


## Tuesday, 13th November. 

The team presented their idea and had it approved. The main takeaways were:

- The project is not about game design, instead focus on programming
- Need to finalize the game design as soon as possible
- Need to decide on the form of AI to implement


## 19th — 23rd November.

Time had been spent finalizing the last remaining game design elements. Game would feature several types of playable units, with special techniques allocated based on types. The players will have to use them to destroy the opponent's core.

A lot of time had been spent trying to find a form of AI that could be used for the enemy player. Struggling to find something that is both suitable for this type of game and the skill of the team. Proving more difficult than originally thought. Considering everything from basic If statements in conjunction with path finding algorithms like Dijkstra's shortest path, to state machines (though they seem uncomfortably difficult). Will get back to this.


## December 2018.

The team felt like they had enough time to implement their game's functionality, so decided to take the month off to focus on assignment deadlines, exam preparations and spend time with their friends and family during the holidays.


## 28th Jan — 1st Feb 2019

Team began the implementation of the game. Decided to individually go off and for one week, work independently of each other to see how far they could get. Afterwords, they could combine their knowledge to create a starting point for the game together.

Vilandas:

- Familiarized himself with Unity by following Unity's official tutorials on creating 'Roll A Ball' and 'Space Shooter' sample games
- Started the real project
- Generated a hexadecimal based grid to act as the game's board
- Struggled to turn the board into a hexadecimal shape without hard coding
- Struggled to transform that grid into a traversable graph
- Struggled with the Unity platform due to unfamiliarity
- Experimented with using clickable buttons to alter the game world

Pedro:

- Jumped into the Unity platform and experimented with his own code to learn the basics of the platform
- Started the real project
- Generated a hexadecimal based grid into the shape of a hexadecimal
- Struggled with transforming that grid into a traversable graph
- Created sample balls that could move around the board
- Created a starter mouse management system


## 4th — 8th February.

Both members met up and explored each other's creations. It was clear that Pedro had more luck with the starting point, so his initial success was used as the launching point for the game. Over the course of the week they:

- Started from scratch
- This time they quickly and efficiently, generated a hexadecimal based grid in the shape of a hexadecimal as well
- Created a sample unit
- Created a basic mouse management system
- Decided to use a 'click on tiles' control system rather than keyboard arrows
- Struggled to create a traversable graph for the game map
- Discovered logical errors. The team had planned to place hidden traps in the game, but realized since they would have use path finding to traverse the board, it may be unfair if the path finding algorithm would accidentally walk your unit over a trap, despite their existing a different path of the same length without a trap. Decided to revise traversal.


## 11th — 15th February.

The team had revised the traversal system. Instead of selecting a unit and then a final destination, the player would themselves have to move each unit, one tile at a time. This creates a fairer experience as each move and mistake is your own.

This meant that the human player would no longer need any path finding, significantly lowering complexity of the program. They decided that each tile should have an X and Y coordinate irrelevant to the world position and would act as a guide to moving units around the board. When standing on any tile, a simple pattern can be used to move the units in a direction.

- Revised traversal system
- No longer needed path finding for the human player, made things easier
- Traversal pattern did not function properly as odd and even rows needed different patterns
- Using a check if row is odd statement, was able to apply the correct pattern
- The board was now traversable with as many units as desired
- Implemented a move from tile to tile animation using math and physics
- Encountered a bug where units could move in the same tile 
- Clicking off of a tile when holding a unit would break the game, crashing it


## 18th — 22nd February.

This week was the hardest so far, both members growing more and more frustrated with each passing day, struggling to implement a neighbor system for the tiles. As well as that, several bugs needed to be fixed from the previous week.

- Failed many times to create a list of neighbors for each tile
- Attempted drawing graphics to aid
- Overthought the neighbor system, much to the frustration yet at the same tile relief, the solution was very simple; use the same system as the traversal by implementing patterns. Neighboring position parameters don't change.
- Created neighbors for each tile
- Tiles at edges would create Null objects, breaking the game when finding neigh ours from said objects 
- Used error handling to catch these and not add Nulls to the neighbor arrays
- Created a function to highlight neighbors (tiles that can be moved to) when selecting a unit
- While at the start it seemed like it worked, it was quickly discovered that if another unit would get near other units, the highlighting system gets overwritten and breaks
- Logic for highlighting needs to he adjusted
- Agreed to use state machines for the AI implementation


## 25th Feb — 1st March.

Met with project supervisor on the 25th of February to go over the current progress. The team had been growing worried and experiencing mild anxiety as things were not going anywhere near as smoothly as they had hoped. At the meeting, the team:

- Showed their progress
- Agreed to scale down the complexity of the game mechanics, making it more manageable
- Discussed potential AI implementation
- Changed AI approach from State Machines and A* to the Minimax algorithm previously learned in Advanced Algorithms and AI search module
- Were advised to implement more OOP concepts, such as Polymorphic

Scaling down the complexity of the project helped to relieve some of the previous concerns held by the students. They were eager to get back to work. With several weeks of experience, they were picking up speed in their programming efficiency. 

Throughout the rest of the week, the team:

- Fixed the neighbor highlighting system by refactoring the previous code, splitting the previously written code into smaller functions
- Implemented polymorphic by creating an Abstract unit class 
- Created a second player, allowing them to have their own units
- Now round system yet, any player could control any unit
- Created more unit types with different attributes
- Due to the lack of time, abandoned styling guide (not important)
- Began writing functions to attack enemy units and core
- Destroying units would crash the game, as when one unit was attacked, all were at the same time as well
- Fixed that by reworking the logic to focus on attacking tiles, rather than units
- Implemented a system that when a tile is attacked, any unit above is destroyed
- This created a problem where friendly units could be destroyed
- Added extra attributes to check for unit teams to prevent said issues
- Implemented a turn system
- Implemented a unit creation system
- Had issues with the player creating units, but they were spawned for the enemy
- Logical tweaks fixed this
- Implemented attacking
- Enough implementation was created for two human players to play each other
- This allowed for User testing
- Allowed three friends to play each other several times (two at a time)
- Carried out some basic unit testing using Unity's assisted tools
- Struggled with understanding how to use it, as it was different from what the students had done before in second year testing with PyUnit
- Created UI elements displaying cores, attributes, energy, health, units and turns
- Created core creation menu

On the 1st of March, they held an online meeting with the project supervisor as he was away from the University, and would not be back until after the project deadline. Main points discussed were:

- Wrote about the progress
- A two player mode of the game was accidentally created, this would be kept
- Decided to allow toggling AI on and off upon request
- Asked about minimax implementation
- Discussed different weight approaches for the algorithm
- Changed core menu to always be on for each player

After a busy week, the team felt like a lot of progress had been made. They were not only growing in efficiency with using Unity's platform but as well as their understanding of the C# language, as well as Object Oriented Programming.


## The Final Week

The final week was hectic, with many frustrations, and emotions running wild. The AI was proving to be a major issue. Main highlights from the week:

- Some functions had to be re-written or adjusted to allow for AI usage
- This broke the movement animation due to the physics used
- Decided to abandon visuals to allow room for game play efficiency instead
- Realized a unit could attack the enemy core from any position, not just when near
- This was due to a logical error, easy fix
- Researched minimax
- Found it difficult to implement
- Most guides suited very simple games, like Tic Tac Toe, Connect 4, etc
- This made it difficult to understand and implement for their own game which was much more complex
- An alternative version of the AI was created as a backup
- Only to be used as a contingency in case minimax failed
- The new backup AI broke the two player mode
- The new backup AI broke the fighting system
- Bother members were frustrated and disappointed with their setbacks
- A very simple AI version was made for the third time
- Fixed two player modes
- Fixed fighting mechanics
- Split up and created the technical and user manuals as well as recorded the demo
- Last attempt to implement minimax, still trying
- If failed, backup AI will be used