@ECHO OFF

for %%I in (.) do set CurrDirName=%%~nxI

:choice
set /P c=Deploy %CurrDirName%?[Y/N]
if /I "%c%" EQU "Y" goto :somewhere
if /I "%c%" EQU "N" goto :somewhere_else
goto :choice


:somewhere

echo Building Release.CryptoCityWallet.API ...
dotnet publish CryptoCityWallet.sln -o C:\Projects\Published\Release.CryptoCityWallet\CryptoCityWallet.Api.Published


echo Building Release.CryptoCityWallet.FrontEnd ...
dotnet publish CryptoCityWallet.FrontEnd.sln -o C:\Projects\Published\Release.CryptoCityWallet\CryptoCityWallet.FrontEnd.Published


echo Deploying to git ...
cd C:\Projects\Published\Release.CryptoCityWallet
git add *.*
git commit -m "One Click Deploy"


git push

echo Change directory to project folder..
cd C:\Projects\Net Core\CryptoCityWallet


echo Deploying to server: Portal
plink ubuntu@54.169.98.94 -m oneclick.portal.sh -batch


echo Deploying to server: API
plink -pw 208BNwk%H66s$$PsBw#3 ph-dev@13.251.181.208 -m oneclick.api.sh -batch


echo Deployment done. Have a good day :)

pause
exit

:somewhere_else

echo Deployment Canceled
pause
exit