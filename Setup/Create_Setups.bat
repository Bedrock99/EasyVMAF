@echo off
echo Kompiliere...
"C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\devenv.exe" "../EasyVMAF.sln" /Rebuild "Release"
echo Erstelle Setup...
"C:\Program Files (x86)\Inno Setup 6\ISCC.exe" "Setup.iss"
echo Erstelle Portable zip...
"C:\Program Files\WinRAR\WinRAR.exe" a -afzip -r -ep1 ".\Output\Easy_VMAF_Portable.zip" "..\EasyVMAF\bin\Release\*.exe"
pause