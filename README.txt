Proposal Requirements & References

Josh Morgan (100924998)
Michael Mouro (100823687)
Oscar Espinola (100817015)

*
*
*

Josh - outlines, shadows, lighting, particles, shader, toggle list, depth of field
	For the depth of field effect, utilizing the depth buffer, we can add a level of blurriness to each pixel on the screen depending on the depth/distance from the camera. We create many passes within the shader itself for things like blur radius and bokeh, and create render textures for them in a script attached to the camera which allows us to render them on the the view of the scene. As for toggling on and off effects, we used the built-in togglers in Unity and attached custom functions to each one. These functions use bools to check if it is currently toggled on (true) or off (false), if false, the function sets it to true and modifies variables for the effect (e.g. setting the _ShowOutline variable to 0 or 1 for toggling outlines).

Michael - Bloom, Lens Flare
Oscar - Models Decals

Screenshots/Images folder: FrogPicnicDELUCE > Images (same location as ReadMe)

Video Link: https://www.youtube.com/watch?v=Jkof4hEcaYI

Final Project Demonstration Video Link: https://youtu.be/6INitEMroBY

Team formation & planning screenshots can be found here: https://docs.google.com/document/d/1PO57fDkeeQ-HeJ8dZkNXrY54fm0o2wiFCfQuHo3J5T0/edit?usp=sharing

Cartoon Shader Image: https://roystan.net/articles/toon-shader/

-REFRENCE VIDEOS USED-

https://www.youtube.com/watch?v=SlTkBe4YNbo
https://www.youtube.com/watch?v=ujRshSd31Zc
https://www.youtube.com/watch?v=D9PDDOl6KS4