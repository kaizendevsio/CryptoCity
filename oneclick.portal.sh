#!/bin/bash
clear
#echo "Stopping API Server ..."
#sudo systemctl stop MinnyCasinoAffiliateWebApi.service
#sudo systemctl status MinnyCasinoAffiliateWebApi.service

echo "Stopping Front-End Server ..."
sudo systemctl stop MinnyCasinoAffiliateWebPortal.service
#sudo systemctl status MinnyCasinoAffiliateWebPortal.service

clear
echo "Git Hard Reset.."
echo ""

echo "Removing existing directories: API / Portal"
sudo rm -r webapp_netcore

echo "Git Hard Reset.."
echo ""
echo "Git cloning: release-master"

sudo git clone https://github.com/kaizendevsio/Release.MinnyCasinoAffiliate.git webapp_netcore

echo "Git clone successful.."

#echo "Starting API Server ..."
#sudo systemctl start MinnyCasinoAffiliateWebApi.service
#sudo systemctl status MinnyCasinoAffiliateWebApi.service

echo "Starting Front-End Server ..."
sudo systemctl start MinnyCasinoAffiliateWebPortal.service
#sudo systemctl status MinnyCasinoAffiliateWebPortal.service

clear
echo "Deployment Done. Have a good day :)"