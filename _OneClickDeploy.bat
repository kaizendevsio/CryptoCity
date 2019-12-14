@ECHO OFF

for %%I in (.) do set CurrDirName=%%~nxI

:choice
set /P c=Deploy %CurrDirName%?[Y/N]
if /I "%c%" EQU "Y" goto :somewhere
if /I "%c%" EQU "N" goto :somewhere_else
goto :choice


:somewhere
cls
echo Building Release.CryptoCityWallet.API ...
dotnet publish CryptoCityWallet.sln -o C:\Projects\Published\Release.CryptoCityWallet\CryptoCityWallet.Api.Published

cls
echo Building Release.CryptoCityWallet.FrontEnd ...
dotnet publish CryptoCityWallet.FrontEnd.sln -o C:\Projects\Published\Release.CryptoCityWallet\CryptoCityWallet.FrontEnd.Published

cls
echo Deploying to git ...
cd C:\Projects\Published\Release.CryptoCityWallet
git add *.*
git commit -m "One Click Deploy"

cls
git push

echo Change directory to project folder..
cd C:\Projects\Net Core\CryptoCityWallet

cls
echo Deploying to server: Portal
plink ubuntu@18.219.116.44 -m oneclick.portal.sh -batch

cls
echo Deploying to server: API
plink ubuntu@18.216.120.230 -m oneclick.api.sh -batch

cls
echo Deployment done. Have a good day :)

pause
exit

:somewhere_else

echo Deployment Canceled
pause
exit