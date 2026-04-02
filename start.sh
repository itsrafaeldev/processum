#!/bin/bash

echo "Iniciando backend..."
dotnet watch run --urls=http://0.0.0.0:5091 &

echo "Iniciando frontend..."
cd Frontend/processum-frontend
npm install
ng serve --host 0.0.0.0 --poll 2000

wait