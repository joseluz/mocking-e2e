#!/bin/bash

mongoimport --uri "mongodb://admin:doNotTellAnyone@localhost:27017/?authSource=admin&readPreference=primary&appname=mystoreapp&directConnection=true&ssl=false" --db mystoreappdb --collection Products --type json --file /products.json --jsonArray

echo "Mongo import task is complete"
