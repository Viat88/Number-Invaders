# Number-Invaders
Final project of IHM


The game start with a Start Scene on which there is only one button, for the moment, which is "Play Game". Players need only one of them to be over it (for several seconds) in order to start. 
(Button will get a darker color when he detect a player above)

Then it goes on the Main Game Scene in which there is aliens that will cross the map (number of aliens can be set in "Aliens Group > Alien Manager> Alien Number"). A light will flash from 
the side they are coming from. 
Each alien has a number which can be written as (2^i)*(3^j)*(5^k) with 1=< i+j+k <= N0 with N0 a number we can set (here it's 5)

Aliens will then shoot missile orthogonally to their movement's direction at regular time interval we can set. 
Aliens will also shoot 4 bombs (we can set the number) that will do a parabolic movement before explosing on the floor where there was red target. Again, it does it at regular time interval
that we can set.
 
3 guns are displayed on the game area and each has a number: 2, 3 and 5.
Each player can take a gun: he only has to stay above few seconds (a time we can set) and he will hear a sound meaning the gun is taken.
A player holding a gun can shoot a laser by doing a line (as if you were playing at a palet air hockey) that has to be enough fast and long (two parameters we can set and that we try to evaluate
during the last lab but we have to try again)

If a laser touches an alien, the alien's number is divided by the number of the gun which has shot the laser (if only it's possible): for example, if the alien's number is 20 and it's
touched by a laser of number 5, it will go to 4 but nothing happen with a laser of gun 3. In all cases, a sound is played and the missile is destroyed.

When the alien's number goes to 1, the alien is destroyed and a sound is played. When all aliens are destroyed, a Victory Scene is played with a victory sound. In this scene, there is just
a button to go to the Title Menu.

All alien's missile and players' laser are destroyed when they go outside of the game area.

3 green hearts are displayed on the game area, they represent the players health (3 for both together). When a gun holded by a player is touched by a alien's missile or the shock wave of a 
alien's bomb, a sound is played and players loose a life and touched player is invicible during few seconds (the gun is flashing to aware him he is invincible).

When players have no more life, a Game Over Scene and sound are played. In this scene again, there is only one button to go the Title Menu.

When the half of aliens are destroyed, they will be invincible (a protection around them is shown) so player' gun laser will be useless. To destroy this protection, players will have to use
a gun turret diplayed in the center of the map. As long as a player stay on it, the gun turret will shoot automatically in the direction of the other player. Hence, players have to be 
coordinated to know who takes the gun and to shoot in the good direction. (At this time, player on the turret is invicible but maybe we will change that)

After destroying the invincibility, players can use again their ray guns.
