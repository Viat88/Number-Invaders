# Number-Invaders
Final project of IHM


The game start and create 6 aliens, children of Aliens Group (on which we can modify the number of alien). Each one is an alien with a number which can be devided by randomly 2,3 or 5.
A side is chosen (West, East, North or South): it's from this side that aliens will come. Then, a percent of the length (of a side) is randomly chosen to know exactly from where it comes.

Aliens cross the game area and slowly turn round and round, then, when it reaches the end of the map (bigger than the game area), it chooses again a side and a percent of the lenght.

AlienManager has a coroutine that allows aliens to shoot: we only have to define the time between 2 succesives shot and how many aliens shoot at the same time. Then, during the game, 
AlienManager chooses randomly aliens that will shoot and they shoot orthogonally to the aliens group's direction. Aliens missile are destroyed when they reached the end of the map.

3 guns are displayed on the game area: gun 2,3 and 5. Each one can be taken: player has just to wait 2 secondes on it. If he wants to take an other one, he just has to do the same thing 
with the new gun (the old one will be put down).

When a alien's missile touch a gun hold by one of both players, players lost one of the 3 hearts displayed in the middle of the game area (there is not a end game screen yet).

