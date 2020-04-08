color 3
git lfs install
@echo off

IF EXIST "C:\Program Files\Unity\Editor\Data\Tools\UnityYAMLMerge.exe" (
	git config --global merge.tool unityyamlmerge
	git config --global mergetool.unityyamlmerge.cmd "'C:\Program Files\Unity\Editor\Data\Tools\UnityYAMLMerge.exe' merge -p \"\$BASE\" \"\$REMOTE\" \"\$LOCAL\" \"\$MERGED\""
	echo 'Updated merge tool to UnityYAMLMerge'
	color 2
) ELSE (
	echo 'Could not find UnityYAMLMerge at default location.'
	color 4
)
pause