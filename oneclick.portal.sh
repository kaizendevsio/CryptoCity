#!/bin/bash
clear
#echo "Stopping API Server ..."
#sudo systemctl stop CryptoCityWalletWebApi.service
#sudo systemctl status CryptoCityWalletWebApi.service

echo "Stopping Front-End Server ..."
sudo systemctl stop CryptoCityWalletWebPortal.service
#sudo systemctl status CryptoCityWalletWebPortal.service

clear
echo "Git Hard Reset.."
echo ""

echo "Removing existing directories: API / Portal"
sudo rm -r webapp_netcore

echo "Git Hard Reset.."
echo ""
echo "Git cloning: release-master"

sudo git clone https://github.com/kaizendevsio/Release.CryptoCityWallet.git webapp_netcore

echo "Git clone successful.."

#echo "Starting API Server ..."
#sudo systemctl start CryptoCityWalletWebApi.service
#sudo systemctl status CryptoCityWalletWebApi.service

echo "Starting Front-End Server ..."
sudo systemctl start CryptoCityWalletWebPortal.service
#sudo systemctl status CryptoCityWalletWebPortal.service

clear
echo "Deployment Done. Have a good day :)"