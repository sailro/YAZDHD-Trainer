@echo off
if "%1"=="" GOTO usage
smi eject -p YAZD_HD -a %1 -n YAZDHD.Trainer -c Loader -m Unload
goto end

:usage
echo usage: unload [address of the assembly to eject]

:end
