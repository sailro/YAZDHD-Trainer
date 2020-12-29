# Yet Another Zombie Defense HD-Trainer

This is an attempt -for educational purposes only- to alter a Unity game at runtime without patching the binaries (so without using [Cecil](https://github.com/jbevain/cecil) nor [Reflexil](https://github.com/sailro/reflexil)).
To achieve that, we use [SharpMonoInjector](https://github.com/warbler/SharpMonoInjector), able to:
- dynamically attach to a process
- call suitable methods to load an assembly in the Game AppDomain
- call managed methods in the assembly.

So we have a very simple trainer for the excellent [Yet Another Zombie Defense HD](https://store.steampowered.com/app/674750/Yet_Another_Zombie_Defense_HD) game. 

How to use the trainer:
- Start the game 
- Run load.bat to inject the trainer into the process (you do not need to copy files in a specific location).
- Use keypad * to trigger god mode
- Use keypad / to buy all weapons (999999 available+ammo)
- Use keypad + to add 999999 skill points (use it when the skill menu appears)
- Use keypad - to add 999999 $
- Run unload.bat to disable the trainer.

You can compile everything or simply use the [demo release](https://github.com/sailro/YAZDHD-Trainer/releases).

Have fun !
