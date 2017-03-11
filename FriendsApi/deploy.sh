#!/bin/sh
WORKDIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"

dotnet publish --configuration Release --framework netcoreapp1.0 -o dist

cd $WORKDIR/dist
zip $WORKDIR/site.zip *
cd $WORKDIR

zip dist.zip site.zip aws-windows-deployment-manifest.json
eb deploy $1

rm -rf ./dist ./dist.zip ./site.zip