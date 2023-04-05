Proposal Requirements & References

THE FINAL PROJECT BUILD IS IN FILE FinalProjectBuild under FrogPicnicDeluxe

Josh Morgan (100924998)
Michael Mouro (100823687)
Oscar Espinola (100817015)

*
*
*

Win condition: Hop in pond to proceed to forest, eat 2 sandwhiches to win and eat the worm to lose/get sent back to the pond 

Josh - outlines, shadows, lighting, particles, shader, toggle list, depth of field
	For the depth of field effect, utilizing the depth buffer, we can add a level of blurriness to each pixel on the screen depending on the depth/distance from the camera. We create many passes within the shader itself for things like blur radius and bokeh, and create render textures for them in a script attached to the camera which allows us to render them on the the view of the scene. As for toggling on and off effects, we used the built-in togglers in Unity and attached custom functions to each one. These functions use bools to check if it is currently toggled on (true) or off (false), if false, the function sets it to true and modifies variables for the effect (e.g. setting the _ShowOutline variable to 0 or 1 for toggling outlines).

Michael - Bloom, Lens Flare, Snow Decal, Scrolling Textures, Fog, Glass, Win condition
	For Bloom I used a post processing volume in which I added the bloom override. I adjusted the intensity and threshold as well as added a bit of diffusion. I finally added a yellow colour to the bloom. I honestly feel this fits the game very well and adds a nice aesthetic overall to it. In terms of Lens Flare I also added a Lens Flare prefab. It basically takes a size aka the amount of particles it will use. It references the particles to the texture I give. I then adjust each particles position size and colour until I have a nice mix to create a great looking flare. Next we got the snow decal in combination with the scrolling textures. I wanted to experiment by adding a scrolling texture but didnt know where it would best be applied. I decided to model a couple of trees and asked Oscar to make a repeated snow texture. I then applied the snow texture as a decal and was able to adjust different leave patterns snow with this offset. It honestly worked better than expected. Explained in the video as well but basically it takes the decal and the textures uv and offsets the decal aka the snow dependant on an adjustable slider that the user can adjust in editor. Moving on we got the fog. The fog uses the particle system. Talked about it in the video but the main things to take into account are the particle system has a start and end speed that it loops between dependant on a start rotation curve that I adjusted. We also decided to shape it with a box as it creates more of a volumetirc fog look. I adjusted the strt size scale as well as the shapes scale to create a natural looking spread out fog. Finally we use the color over lifetime to use a gradient editor in which we set to blend mode. We take 3 points. The two furthest points from the center being transparent while the center has an alpha value that can be adjusted. The higher it is the more dense and visible the fog is. Our win condition is fairly simple, you hop in the pond to proceed to the next level. You win by eating two sandwhiches in the forest level and you lose/get sent back by eating a worm. Fairly simple just uses if statements to check if you collided with a trigger and if so it invokes a next scene function/reset scene. Finally I wanna talk about the glass shader that is supposed to be applied to the cups on the picnic blanket for the forest level. It hasnt been fully implemented due to reasons I cant understand, but from my understanding on how it should work is it basically takes the vertices from the cup and put them into clip space instead of world, it then calculated the position within the screen space, then the fragment positions everything on screen and finally we multiply it by a tint which allows us to create a transparent type of effect.

Oscar - Models Decals, new map model, hats & hat swapping, water physics, water texture & shader
	The decals work by adding the transparent image overtop of the existing mesh on an overlay layer. The texture I created is specifically made to repeat seamlessly, so that when it's applied as a decal it will seamlessly repeat over itself so that it becomes nearly impossible to tell when one tile starts and the other ends. 
The water physics works by calculating the position over time using a sine wave calculation. Every update, it calculates the newest iteration and projects that onto the mesh to give the visual effect of the wave using our specified parameters (how fast it updates, how high the waves go, etc). This shader is combined with various other effects in our scene such as the ability to have an outline and a toon shader to match the rest of the scenes visuals. 

Screenshots/Images folder: FrogPicnicDELUCE > Images (same location as ReadMe)

Video Link: https://www.youtube.com/watch?v=Jkof4hEcaYI

Final Project Demonstration Video Link: https://youtu.be/6INitEMroBY

Team formation & planning screenshots can be found here: https://docs.google.com/document/d/1PO57fDkeeQ-HeJ8dZkNXrY54fm0o2wiFCfQuHo3J5T0/edit?usp=sharing

Cartoon Shader Image: https://roystan.net/articles/toon-shader/

Fog Image Texture used: https://github.com/etredal/FogTutorial

-REFRENCE VIDEOS USED-

https://www.youtube.com/watch?v=SlTkBe4YNbo
https://www.youtube.com/watch?v=ujRshSd31Zc
https://www.youtube.com/watch?v=D9PDDOl6KS4
https://www.youtube.com/watch?v=UllkvfMR96s&t=2s