HDRP Error:
----------

1. Compiling issue when importing the HDRP.

Ans:	Uninstall the HDRP and Core RP & Shader Graph and reinstall the HDRP from resource manager 
		and the other will be automatically installed. if not you can install them to the latest version, which must be same version of the 	     hdrp.

		For Example if the installed version of HDRP is 5.13.0 then the CORE RP & Shader Graph should be also version 5.13.0.

Note: if you have LWRP unstall it as both the HDRP and LWRP are not compatible with each other and will create compiling issue. 
	  Always use any one & check the Core RP 7 & Shader graph vesion mathing their version.
	  

Hybrid Renderer Error:
---------------------

1. Gameobject is visible in the Scene and not visible or not rendered when the game starts and converted to Entity,

Ans: 	Check in the Package Manager whether the Hybrid Renderer is installed as the Entity Framework uses it than the inbuit render like HDRP or LWRP or default one.	
