# Number-Invaders
Final project of IHM


The game start with a Start Scene on which there is two button, which are "Play Game" and "Parameters". 
To select one of them, at least one player is needed to stay above for few seconds and the button will become white to inform the player that he is selecting this one.

Players can directly play the game but they can before change some parameters

/////// PARAMETERS 

9 different parameters can be changed:

- if aliens can move/ shoot missile/ shoot bombs by checking or not a box

- the number of aliens (step: 1)/ the maximum number of factor that number of aliens can have (step: 1)/ the maximum of a number of an alien (step: 25)/ the minimum shoot speed needed to shoot 
  (step: 25)/ the minimum shoot lenght needed to shoot (step: 1), by clicking on minus or plus button. (It will increase/ decrease by the step)

- the factor we want: from 2 to 9, number of aliens will be the multiplication of these numbers and guns will have these numbers. Players can only select 3 different numbers and at least 1. 
  To select or deselect one, player only have to stay above few seconds. A number selected will have its box in white.

/////// MAIN GAME
 
Inside the Main Game Scene they are aliens that will cross the map. A light will flash from the side they are coming from. 

/// ALIEN'S NUMBER
Each alien has a number which can be written as x = (n^i)*(m^j)*(l^k) with 1=< i+j+k <= N0 with N0 the maximum number of factor that number of aliens can have, n/m/l the three factors selected
and x < maximum of a number of an alien

/// ALIEN'S SHOOT
Aliens will then shoot missile orthogonally to their movement's direction at regular time interval we can set. 
Aliens will also shoot 4 bombs (we can set the number) that will do a parabolic movement before explosing on the floor where there was red target. Again, it does it at regular time interval
that we can set in Alien Group > Shoot Missile > Time between aliens shoot.
 
/// GUNS
3 guns will be displayed on the game area and each one will have one of the numbers selected, if they are less than 3 numbers, there will be less than 3 guns.
Each player can take a gun: he only has to stay above few seconds and he will hear a sound meaning the gun is taken.
A player holding a gun can shoot a laser by doing a line (as if you were playing at a palet air hockey) that has to be enough fast and long (two parameters we can set in Parameters)

/// ALIENS DESTRUCTION
If a laser touches an alien, the alien's number is divided by the number of the gun which has shot the laser (if only it's possible): for example, if the alien's number is 20 and it's
touched by a laser of number 5, it will go to 4 but nothing happen with a laser of gun 3. In all cases, a sound is played and the missile is destroyed.

When the alien's number goes to 1, the alien is destroyed and a sound is played. When all aliens are destroyed, a Victory Scene is played with a victory sound. In this scene, there is just
a button to go to the Title Menu.

All alien's missile and players' laser are destroyed when they go outside of the game area.

/// PLAYERS LIFES
3 grey hearts are displayed on the game area, they represent the players health (3 for both together). When a gun holded by a player is touched by a alien's missile or the shock wave of a 
alien's bomb, a sound is played and players loose a life and touched player is invicible during few seconds (the gun is flashing to aware him he is invincible).

When players have no more life, a Game Over Scene and sound are played. In this scene again, there is only one button to go the Title Menu.

/// ALIENS INVINCIBILITY
When the half of aliens are destroyed, they will be invincible (a protection around them is shown) so player' gun laser will be useless. To destroy this protection, players will have to use
a gun turret diplayed in the center of the map. As long as a player stay on it, the gun turret will shoot automatically in the direction of the other player. Hence, players have to be 
coordinated to know who takes the gun and to shoot in the good direction. 

After destroying the invincibility, players can use again their ray guns.
