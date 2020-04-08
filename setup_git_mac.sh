#!/bin/bash
git lfs install

if [ -e '/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge' ]
then
	git config --global merge.tool unityyamlmerge
	git config --global mergetool.unityyamlmerge.cmd "'C:\Program Files\Unity\Editor\Data\Tools\UnityYAMLMerge.exe' merge -p \"\$BASE\" \"\$REMOTE\" \"\$LOCAL\" \"\$MERGED\""
	echo 'Updated merge tool to UnityYAMLMerge'
else
    echo 'Could not find UnityYAMLMerge at default location.'
fi

read -n1 -rsp $'Press any key to continue or Ctrl+C to exit...\n'